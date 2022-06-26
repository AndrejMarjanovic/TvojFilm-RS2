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
    public partial class frmDrzave : Form
    {
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _filmovi = new APIService("Filmovi");

        public frmDrzave()
        {
            InitializeComponent();
            dgvDrzave.AutoGenerateColumns = false;
        }

        private async void frmDrzave_Load(object sender, EventArgs e)
        {
            dgvDrzave.DataSource = await _drzave.Get<List<Model.Drzave>>(null);

        }

        private async void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new DrzaveSearchRequest()
            {
                Naziv = tbNaziv.Text
            };

            var result = await _drzave.Get<List<Model.Drzave>>(search);
            dgvDrzave.DataSource = result;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajDrzavu frm = new frmDodajDrzavu(dgvDrzave);
            frm.Show();
        }

        private async void dgvDrzave_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvDrzave.SelectedRows[0].DataBoundItem as Model.Drzave;
            var gradovi = await _gradovi.Get<List<Model.Gradovi>>(null);
            var filmovi = await _filmovi.Get<List<Model.Filmovi>>(null);

            if (e.ColumnIndex == 2)
            {
                foreach (var i in gradovi)
                {
                    if (i.DrzavaId == item.DrzavaId)
                    {
                        MessageBox.Show("U bazi postoje gradovi za ovu državu, uklonite ih prije brisanja države!");
                        return;
                    }
                }
                foreach (var i in filmovi)
                {
                    if (i.DrzavaId == item.DrzavaId)
                    {
                        MessageBox.Show("U bazi postoje filmovi iz ove državu, uklonite ih prije brisanja države!");
                        return;
                    }
                }
                DialogResult result = MessageBox.Show("Potvrdite brisanje države: " + item.Naziv + ".", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    await _drzave.Delete<Model.Drzave>(item.DrzavaId);
                    dgvDrzave.DataSource = await _drzave.Get<List<Model.Drzave>>(null);

                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }

            if (e.ColumnIndex == 1)
            {
                if (item != null)
                {

                    frmDodajDrzavu frm = new frmDodajDrzavu(dgvDrzave, item.DrzavaId);
                    frm.ShowDialog();

                }
            }
        }
    }
}
