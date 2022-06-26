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
    public partial class frmRedatelji : Form
    {
        private readonly APIService _redatelji = new APIService("Redatelji");
        public frmRedatelji()
        {
            InitializeComponent();
            dgvRedatelji.AutoGenerateColumns = false;
        }

        private async void frmRedatelji_Load(object sender, EventArgs e)
        {
            dgvRedatelji.DataSource = await _redatelji.Get<List<Model.Redatelji>>(null);
        }

        private async void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new RedateljiSearchRequest()
            {
                Ime = tbNaziv.Text
            };

            var result = await _redatelji.Get<List<Model.Redatelji>>(search);
            dgvRedatelji.DataSource = result;
        }

        private async void tbPrezime_TextChanged(object sender, EventArgs e)
        {
            var search = new RedateljiSearchRequest()
            {
                Prezime = tbPrezime.Text
            };

            var result = await _redatelji.Get<List<Model.Redatelji>>(search);
            dgvRedatelji.DataSource = result;
        }

        private async void dgvRedatelji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvRedatelji.SelectedRows[0].DataBoundItem as Model.Redatelji;

            if (e.ColumnIndex == 4)
            {
                DialogResult result = MessageBox.Show("Potvrdite brisanje redatelja: " + item.Ime + " " + item.Prezime + ".", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _redatelji.Delete<Model.Redatelji>(item.RedateljId);
                    dgvRedatelji.DataSource = await _redatelji.Get<List<Model.Redatelji>>(null);
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
                    frmDodajRedatelja frm = new frmDodajRedatelja(dgvRedatelji, item.RedateljId);
                    frm.ShowDialog();
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajRedatelja frm = new frmDodajRedatelja(dgvRedatelji);
            frm.Show();
        }
    }
}
