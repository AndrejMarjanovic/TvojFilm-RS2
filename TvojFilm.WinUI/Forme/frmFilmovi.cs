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
using TvojFilm;

namespace TvojFilm.WinUI.Forme
{
    public partial class frmFilmovi : Form
    {
        private readonly APIService _zanrovi = new APIService("Zanrovi");
        private readonly APIService _filmovi = new APIService("Filmovi");
        public frmFilmovi()
        {
            InitializeComponent();
            dgvFilmovi.AutoGenerateColumns = false;
        }

        private async void frmFilmovi_Load(object sender, EventArgs e)
        {
            await UcitajFilmove();
            await UcitajZanrove();
            dgvFilmovi.DataSource = await _filmovi.Get<List<Model.Filmovi>>(null);
        }

        private async Task UcitajZanrove()
        {
            var result = await _zanrovi.Get<List<Model.Zanrovi>>(null);
            result.Insert(0, new Model.Zanrovi());
            cbZanr.DataSource = result;
            cbZanr.DisplayMember = "Naziv";
            cbZanr.ValueMember = "ZanrId";
        }

        private async Task UcitajFilmove(int zanrID = 0)
        {
            FilmoviSearchRequest model = new FilmoviSearchRequest();
            if (zanrID != 0)
            {
                model.ZanrId = zanrID;

            }

            dgvFilmovi.DataSource = await _filmovi.Get<List<Model.Filmovi>>(model);
        }

        private async void tbNaziv_TextChanged(object sender, EventArgs e)
        {
            var search = new FilmoviSearchRequest()
            {
                NazivFilma = tbNaziv.Text
            };

            var result = await _filmovi.Get<List<Model.Filmovi>>(search);
            dgvFilmovi.DataSource = result;
        }

        private async void tbRedatelj_TextChanged(object sender, EventArgs e)
        {
            var search = new FilmoviSearchRequest()
            {
                Redatelj = tbRedatelj.Text
            };

            var result = await _filmovi.Get<List<Model.Filmovi>>(search);
            dgvFilmovi.DataSource = result;
        }

        private async void tbGulmac_TextChanged(object sender, EventArgs e)
        {
            var search = new FilmoviSearchRequest()
            {
                Glumac = tbGulmac.Text
            };

            var result = await _filmovi.Get<List<Model.Filmovi>>(search);
            dgvFilmovi.DataSource = result;
        }

        private async void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int zanrID = (cbZanr.SelectedItem as Model.Zanrovi).ZanrId;

            await UcitajFilmove(zanrID);
        }

        private async void dgvFilmovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvFilmovi.SelectedRows[0].DataBoundItem as Model.Filmovi;

            if (e.ColumnIndex == 9)
            {
                DialogResult result = MessageBox.Show("Potvrdite brisanje odabranog filma:  " + item.NazivFilma + ".", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _filmovi.Delete<Model.Filmovi>(item.FilmId);
                    dgvFilmovi.DataSource = await _filmovi.Get<List<Model.Filmovi>>(null);
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (e.ColumnIndex == 8)
            {
                if (item != null)
                {
                    frmDodajFilm frm = new frmDodajFilm(dgvFilmovi, item.FilmId);
                    frm.ShowDialog();
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDodajFilm frm = new frmDodajFilm(dgvFilmovi);
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var dtoFilmovi = new dtoFilmovi()
            {
                Filmovi = dgvFilmovi.DataSource as List<Model.Filmovi>
            };
            frmReport frmR = new frmReport(dtoFilmovi);
            frmR.ShowDialog();
        }
    }

    public class dtoFilmovi
    {
        public List<Model.Filmovi> Filmovi { get; set; }
    }
}
