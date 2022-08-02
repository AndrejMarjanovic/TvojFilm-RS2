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
    public partial class frmLogin : Form
    {
        private readonly APIService _korisnici = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;

                try
                {

                    List<Model.Korisnici> listKorisnici = await _korisnici.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { Username = APIService.Username }) ;
                    APIService.LogiraniKorisnik = listKorisnici.Where(x => x.Username == APIService.Username).FirstOrDefault();
                    if (APIService.LogiraniKorisnik!=null)
                    {
                        if (APIService.LogiraniKorisnik.Uloga.Naziv == "Administrator")
                        {
                            await _korisnici.Get<dynamic>(null);

                            mdiMain frm = new mdiMain();
                            DialogResult = DialogResult.OK;
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nemate Pravo Pristupa!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Niste autentificirani!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Niste autentificirani!", "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }

            }
        }

        private bool Validacija()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                err.SetError(txtUsername, "Obavezno polje!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                err.SetError(txtPassword, "Obavezno polje!");
                return false;
            }
            else err.Clear();



            return true;
        }
    }
}
