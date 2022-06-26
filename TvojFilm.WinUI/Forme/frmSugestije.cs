using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvojFilm.Model.Requests;
using TvojFilm.WinUI.API;

namespace TvojFilm.WinUI.Forme
{
    public partial class frmSugestije : Form
    {
        private readonly APIService _sugestija = new APIService("PrijedloziFilmova");
        public frmSugestije()
        {
            InitializeComponent();
            dgvSugestije.AutoGenerateColumns = false;
        }

        private async void frmSugestije_Load(object sender, EventArgs e)
        {
            await UcitajPrijedloge();
        }
        private async Task UcitajPrijedloge()
        {
            dgvSugestije.DataSource = await _sugestija.Get<List<Model.PrijedloziFilmova>>(null);
        }

        private async void dgvSugestije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvSugestije.SelectedRows[0].DataBoundItem as Model.PrijedloziFilmova;

            if (e.ColumnIndex == 3)
            {
                var sugestija = await _sugestija.GetById<Model.PrijedloziFilmova>(item.PrijedlogId);

                if (sugestija.Odgovoren == false)
                {
                    sugestija.Odgovoren = true;
                    sugestija.Opis = "Odobrili smo vašu sugestiju filma. Možete ga očekivati na servisu uskoro!";
                    sugestija.Pregledan = false;
                    await _sugestija.Update<PrijedloziFilmovaInsertRequest>(item.PrijedlogId, sugestija);

                    MessageBox.Show("Korisnik " + item.Korisnik.Username.ToUpper() + " je obaviješten o odobrenju.");

                    await UcitajPrijedloge();
                }
            }

            if (e.ColumnIndex == 4)
            {
                DialogResult result = MessageBox.Show("Potvrdite uklanjanje prijedloga: ", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _sugestija.Delete<Model.FilmoviKomentari>(item.PrijedlogId);
                    await UcitajPrijedloge();

                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

        private async void tbSugestija_TextChanged(object sender, EventArgs e)
        {
            var search = new PrijedloziFilmovaSearchRequest()
            {
                PrijedlogIme = tbSugestija.Text
            };

            var result = await _sugestija.Get<List<Model.PrijedloziFilmova>>(search);
            dgvSugestije.DataSource = result;
        }
    }
}
