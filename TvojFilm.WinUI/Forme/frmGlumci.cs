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
    public partial class frmGlumci : Form
    {
        private readonly APIService _glumci = new APIService("Glumci");
        public frmGlumci()
        {
            InitializeComponent();
            dgvGlumci.AutoGenerateColumns = false;
        }

        private async void frmGlumci_Load(object sender, EventArgs e)
        {
            dgvGlumci.DataSource = await _glumci.Get<List<Model.Glumci>>(null);
        }

        private async void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new GlumciSearchRequest()
            {
                Ime = tbNaziv.Text
            };

            var result = await _glumci.Get<List<Model.Glumci>>(search);
            dgvGlumci.DataSource = result;

        }

        private async void tbPrezime_TextChanged(object sender, EventArgs e)
        {
            var search = new GlumciSearchRequest()
            {
                Prezime = tbPrezime.Text
            };

            var result = await _glumci.Get<List<Model.Glumci>>(search);
            dgvGlumci.DataSource = result;
        }

        private async void dgvGlumci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvGlumci.SelectedRows[0].DataBoundItem as Model.Glumci;

            if (e.ColumnIndex == 4)
            {
                DialogResult result = MessageBox.Show("Potvrdite brisanje glumca: " + item.Ime + " " + item.Prezime + ".", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _glumci.Delete<Model.Glumci>(item.GlumacId);
                    dgvGlumci.DataSource = await _glumci.Get<List<Model.Glumci>>(null);
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (e.ColumnIndex == 3)
            {
                if (item != null)
                {
                    frmDodajGlumca frm = new frmDodajGlumca(dgvGlumci, item.GlumacId);
                    frm.ShowDialog();
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajGlumca frm = new frmDodajGlumca(dgvGlumci);
            frm.ShowDialog();
        }
    }
}
