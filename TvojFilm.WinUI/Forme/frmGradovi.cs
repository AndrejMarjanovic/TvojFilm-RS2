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
    public partial class frmGradovi : Form
    {
        private readonly APIService _korisnici = new APIService("Korisnici");
        private readonly APIService _gradovi = new APIService("Gradovi");
        public frmGradovi()
        {
            InitializeComponent();
            dgvGradovi.AutoGenerateColumns = false;
        }

        private async void frmGradovi_Load(object sender, EventArgs e)
        {
            dgvGradovi.DataSource = await _gradovi.Get<List<Model.Gradovi>>(null);
        }

        private async void dgvGradovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvGradovi.SelectedRows[0].DataBoundItem as Model.Gradovi;

            var korisnici = await _korisnici.Get<List<Model.Korisnici>>(null);


            if (e.ColumnIndex == 3)
            {
                foreach (var i in korisnici)
                {
                    if (i.GradId == item.GradId)
                    {
                        MessageBox.Show("U bazi postoji jedan ili više korisnika baziranih u ovom gradu, uklonite ih prije brisanja grada!");
                        return;
                    }
                }

                DialogResult result = MessageBox.Show("Potvrdite brisanje grada: " + item.Naziv + ".", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _gradovi.Delete<Model.Gradovi>(item.GradId);
                    dgvGradovi.DataSource = await _gradovi.Get<List<Model.Gradovi>>(null);


                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (item != null)
                {

                    frmDodajGrad frm = new frmDodajGrad(dgvGradovi, item.GradId);
                    frm.ShowDialog();

                }
            }
        }

        private async void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new GradoviSearchRequest()
            {
                Naziv = tbNaziv.Text
            };

            var result = await _gradovi.Get<List<Model.Gradovi>>(search);
            dgvGradovi.DataSource = result;
        }

        private async void tbDrzava_TextChanged(object sender, EventArgs e)
        {
            var search = new GradoviSearchRequest()
            {
                Drzava = tbDrzava.Text
            };

            var result = await _gradovi.Get<List<Model.Gradovi>>(search);
            dgvGradovi.DataSource = result;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajGrad frm = new frmDodajGrad(dgvGradovi);
            frm.Show();
        }
    }
}
