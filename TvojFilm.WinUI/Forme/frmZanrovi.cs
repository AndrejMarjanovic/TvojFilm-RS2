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
    public partial class frmZanrovi : Form
    {
        private readonly APIService _zanrovi = new APIService("Zanrovi");
        public frmZanrovi()
        {
            InitializeComponent();
            dgvZanrovi.AutoGenerateColumns = false;
        }

        private async void frmZanrovi_Load(object sender, EventArgs e)
        {
            dgvZanrovi.DataSource = await _zanrovi.Get<List<Model.Zanrovi>>(null);
        }

        private async void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new ZanroviSearchRequest()
            {
                Naziv = tbNaziv.Text
            };

            var result = await _zanrovi.Get<List<Model.Zanrovi>>(search);
            dgvZanrovi.DataSource = result;
        }

        private async void dgvZanrovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvZanrovi.SelectedRows[0].DataBoundItem as Model.Zanrovi;

            if (e.ColumnIndex == 2)
            {

                DialogResult result = MessageBox.Show("Potvrdite uklanjanje žanra: " + item.Naziv + ".", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _zanrovi.Delete<Model.Zanrovi>(item.ZanrId);
                    dgvZanrovi.DataSource = await _zanrovi.Get<List<Model.Zanrovi>>(null);

                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            if(e.ColumnIndex==1)
            {
                frmDodajZanr frm = new frmDodajZanr(dgvZanrovi, item.ZanrId);
                frm.ShowDialog();
            }

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajZanr frm = new frmDodajZanr(dgvZanrovi);
            frm.Show();
        }
    }
}
