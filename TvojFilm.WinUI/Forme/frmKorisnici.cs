using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Model.Requests;
using TvojFilm.WinUI.API;

namespace TvojFilm.WinUI.Forme
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _korisnici = new APIService("Korisnici");
        private readonly APIService _uloge = new APIService("Uloge");
        private readonly APIService _kupovine = new APIService("KupnjaFilmova");
        private readonly APIService _prijedlozi = new APIService("PrijedloziFilmova");
        private readonly APIService _komentari = new APIService("FilmoviKomentari");
        private readonly APIService _ocjene = new APIService("FilmoviOcjene");
        public frmKorisnici()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            await UcitajKorisnike();
            await UcitajUloge();
        }

        private async Task UcitajKorisnike(int ulogaID = 0)
        {
            KorisnikSearchRequest model = new KorisnikSearchRequest();
            if (ulogaID != 0)
            {
                model.UlogaId = ulogaID;

            }

            dgvKorisnici.DataSource = await _korisnici.Get<List<Model.Korisnici>>(model);
        }

        private async Task UcitajUloge()
        {
            var result = await _uloge.Get<List<Model.Uloge>>(null);
            result.Insert(0, new Model.Uloge());
            cmbUloge.DataSource = result;
            cmbUloge.DisplayMember = "Naziv";
            cmbUloge.ValueMember = "UlogaId";
        }
        private async void txtUsername_TextChanged(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                Username = txtUsername.Text
            };

            var result = await _korisnici.Get<List<Model.Korisnici>>(search);
            dgvKorisnici.DataSource = result;
        }

        private async void txtIme_TextChanged(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                Ime = txtIme.Text
            };

            var result = await _korisnici.Get<List<Model.Korisnici>>(search);
            dgvKorisnici.DataSource = result;
        }

        private async void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                Prezime = txtPrezime.Text
            };

            var result = await _korisnici.Get<List<Model.Korisnici>>(search);
            dgvKorisnici.DataSource = result;
        }

        private async void cmbUloge_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ulogaID = (cmbUloge.SelectedItem as Model.Uloge).UlogaId;

            await UcitajKorisnike(ulogaID);
        }

        private async void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvKorisnici.SelectedRows[0].DataBoundItem as Model.Korisnici;

            if (e.ColumnIndex == 9)
            {

                DialogResult result = MessageBox.Show("Jeste li sigurni da želite izbrisati korisnika: " + item.Ime + " " + item.Prezime + "?", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var prijedlog = await _prijedlozi.Get<List<Model.PrijedloziFilmova>>(null);
                    var ocjena = await _ocjene.Get<List<Model.FilmoviOcjene>>(null);
                    var kupovina = await _kupovine.Get<List<Model.KupnjaFilmova>>(null);
                    var komentar = await _komentari.Get<List<Model.FilmoviKomentari>>(null);


                    if (kupovina != null)
                    {
                        foreach (var i in kupovina)
                        {
                            if (i.KorisnikId == item.KorisnikId)
                            {
                                await _kupovine.Delete<Model.KupnjaFilmova>(i.KupnjaId);
                            }
                        }
                    }
                    if (komentar != null)
                    {
                        foreach (var i in komentar)
                        {
                            if (i.KorisnikId == item.KorisnikId)
                            {
                                await _komentari.Delete<Model.FilmoviKomentari>(i.FilmKomentarId);
                            }
                        }
                    }
                    if (ocjena != null)
                    {
                        foreach (var i in ocjena)
                        {
                            if (i.KorisnikId == item.KorisnikId)
                            {
                                await _ocjene.Delete<Model.FilmoviOcjene>(i.FilmOcjenaId);
                            }
                        }
                    }
                    if (prijedlog != null)
                    {
                        foreach (var i in prijedlog)
                        {
                            if (i.KorisnikId == item.KorisnikId)
                            {
                                await _prijedlozi.Delete<Model.PrijedloziFilmova>(i.PrijedlogId);
                            }
                        }
                    }

                    await _korisnici.Delete<Model.Korisnici>(item.KorisnikId);
                    await UcitajKorisnike();

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

                    frmDodajKorisnika frm = new frmDodajKorisnika(dgvKorisnici, item.KorisnikId);
                    frm.ShowDialog();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika frm = new frmDodajKorisnika(dgvKorisnici);
            frm.Show();
        }
    }
}
