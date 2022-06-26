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
    public partial class frmKomentari : Form
    {
        private readonly APIService _komentari = new APIService("FilmoviKomentari");
        private int? _id = null;
        public frmKomentari(int? id = null)
        {
            InitializeComponent();
            _id = id;
            dgvKomentari.AutoGenerateColumns = false;
        }

        private async void frmKomentari_Load(object sender, EventArgs e)
        {
            await UcitajKomentare();
        }

        private async void tbKomentar_TextChanged(object sender, EventArgs e)
        {
            var search = new FilmoviKomentariSearchRequest()
            {
                Komentar = tbKomentar.Text
            };

            var result = await _komentari.Get<List<Model.FilmoviKomentari>>(search);
            dgvKomentari.DataSource = result;
        }

        private async Task UcitajKomentare()
        {
            FilmoviKomentariSearchRequest model = new FilmoviKomentariSearchRequest();
            if (_id != 0)
            {
                model.FilmId = _id;

            }
            dgvKomentari.DataSource = await _komentari.Get<List<Model.FilmoviKomentari>>(model);
        }

        private async void dgvKomentari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvKomentari.SelectedRows[0].DataBoundItem as Model.FilmoviKomentari;

            if (e.ColumnIndex == 4)
            {
                DialogResult result = MessageBox.Show("Potvrdite brisanje komentara: ", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _komentari.Delete<Model.FilmoviKomentari>(item.FilmKomentarId);
                    await UcitajKomentare();

                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
        }
    }
}
