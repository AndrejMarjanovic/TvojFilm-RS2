using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvojFilm.Model.Requests;
using TvojFilm.WinUI.API;

namespace TvojFilm.WinUI.Forme
{
    public partial class frmDodajKorisnika : Form
    {
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _uloge = new APIService("Uloge");
        private readonly APIService _korisnici = new APIService("Korisnici");
        private int? _id = null;
        private DataGridView? _dgvKorisnici = null;
        public frmDodajKorisnika(DataGridView? dgvKorisnici = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvKorisnici = dgvKorisnici;
        }

        private async Task UcitajPodatke()
        {
            await UcitajGradove();
            await UcitajUloge();
        }
        private async void frmDodajKorisnika_Load(object sender, EventArgs e)
        {
            await UcitajPodatke();
            if (_id.HasValue && _id == APIService.LogiraniKorisnik!.KorisnikId)
            {
                var korisnici = await _korisnici.GetById<Model.Korisnici>(_id);
                tbIme.Text = korisnici.Ime;
                tbPrezime.Text = korisnici.Prezime;
                tbUsername.Text = korisnici.Username;
                tbEmail.Text = korisnici.Email;
                tbBroj.Text = korisnici.Telefon;
                dtp.Value = korisnici.DatumRodjenja;

                foreach (Model.Gradovi item in cbGrad.Items)
                {
                    if (item.GradId == korisnici.GradId)
                        cbGrad.SelectedItem = item;
                }
                foreach (Model.Uloge item in cbUloga.Items)
                {
                    if (item.UlogaId == korisnici.UlogaId)
                        cbUloga.SelectedItem = item;
                }
            }
            else if (_id.HasValue && _id != APIService.LogiraniKorisnik!.KorisnikId)
            {
                var korisnici = await _korisnici.GetById<Model.Korisnici>(_id);
                tbIme.Text = korisnici.Ime;
                tbIme.Enabled = false;
                tbPrezime.Text = korisnici.Prezime;
                tbPrezime.Enabled = false;
                tbUsername.Text = korisnici.Username;
                tbUsername.Enabled = false;
                tbEmail.Text = korisnici.Email;
                tbEmail.Enabled = false;
                tbBroj.Text = korisnici.Telefon;
                tbBroj.Enabled = false;
                dtp.Value = korisnici.DatumRodjenja;
                dtp.Enabled = false;

                tbPass.Hide();
                tbPotvrda.Hide();
                label9.Hide();
                label10.Hide();

                foreach (Model.Gradovi item in cbGrad.Items)
                {
                    if (item.GradId == korisnici.GradId)
                        cbGrad.SelectedItem = item;
                        cbGrad.Enabled = false;
                }
                foreach (Model.Uloge item in cbUloga.Items)
                {
                    if (item.UlogaId == korisnici.UlogaId)
                        cbUloga.SelectedItem = item;
                }
            }
        }

        private async Task UcitajUloge()
        {
            var result = await _uloge.Get<List<Model.Uloge>>(null);
            result.Insert(0, new Model.Uloge());
            cbUloga.DataSource = result;
            cbUloga.DisplayMember = "Naziv";
            cbUloga.ValueMember = "UlogaId";
        }

        private async Task UcitajGradove()
        {
            var result = await _gradovi.Get<List<Model.Gradovi>>(null);
            result.Insert(0, new Model.Gradovi());
            cbGrad.DataSource = result;
            cbGrad.DisplayMember = "Naziv";
            cbGrad.ValueMember = "GradId";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (await Validacija())
            {

                KorisnikInsertRequest request = new KorisnikInsertRequest()
                {
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    Username = tbUsername.Text,
                    Email = tbEmail.Text,
                    Telefon = tbBroj.Text,
                    Password = tbPass.Text,
                    PasswordConfirm = tbPotvrda.Text,
                    DatumRodjenja = DateTime.Parse(dtp.Value.ToShortDateString()),
                    GradId = (cbGrad.SelectedItem as Model.Gradovi).GradId,
                    UlogaId = (cbUloga.SelectedItem as Model.Uloge).UlogaId

                };
                var korisnici = await _korisnici.Get<List<Model.Korisnici>>(null);

                if (_id.HasValue)
                {
                    await _korisnici.Update<Model.Korisnici>(_id, request);
                }
                else
                {
                    await _korisnici.Insert<Model.Korisnici>(request);
                }
                if (_id.HasValue)
                {
                    MessageBox.Show("Uspješno ste izvršili promjene!");
                    this.Close();
                    if (_dgvKorisnici != null)
                        _dgvKorisnici.DataSource = await _korisnici.Get<List<Model.Korisnici>>(null);
                }
                else
                {
                    MessageBox.Show("Dodan novi korisnik!");
                    this.Close();
                    if (_dgvKorisnici != null)
                        _dgvKorisnici.DataSource = await _korisnici.Get<List<Model.Korisnici>>(null);
                }

            }
        }

        private async Task<bool> Validacija()
        {
            var result = await _korisnici.Get<List<Model.Korisnici>>(null);
            int id = _id ?? 0;

            if (string.IsNullOrEmpty(tbIme.Text))
            {
                err.SetError(tbIme, "Niste unijeli ime!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(tbPrezime.Text))
            {
                err.SetError(tbPrezime, "Niste unijeli prezime!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(cbGrad.Text))
            {
                err.SetError(cbGrad, "Odaberite grad!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(cbUloga.Text))
            {
                err.SetError(cbUloga, "Odaberite ulogu!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                err.SetError(tbEmail, "Unesite email adresu!");
                return false;
            }
            else if (!Regex.IsMatch(tbEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                err.SetError(tbEmail, "Nepodržan format email-a");
                return false;
            }
            else
            {
                foreach (var item in result)
                    if (item.Email == tbEmail.Text && item.KorisnikId != id)
                    {
                        err.SetError(tbEmail, "Email adresa se već koristi!");
                        return false;
                    }
            }

            if (string.IsNullOrEmpty(tbBroj.Text))
            {
                err.SetError(tbBroj, "Unesite broj telefona!");
                return false;
            }
            else if (!Regex.IsMatch(tbBroj.Text, @"(?<cRegexGroupsName>\d{9})$"))
            {
                err.SetError(tbBroj, "Unesite broj u formatu od 9 brojeva");
                return false;
            }
            else
            {
                foreach (var item in result)
                    if (item.Telefon == tbBroj.Text && item.KorisnikId != id)
                    {
                        err.SetError(tbBroj, "Unijeli ste registrirani broj!");
                        return false;
                    }
            }
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                err.SetError(tbUsername, "Unesite korisničko ime!");
                return false;
            }
            else
            {
                foreach (var item in result)
                    if (item.Username == tbUsername.Text && item.KorisnikId != id)
                    {
                        err.SetError(tbUsername, "Korisničko ime je zauzeto!");
                        return false;
                    }
            }
            if (string.IsNullOrWhiteSpace(tbPass.Text))
            {
                if (_id.HasValue && _id!=APIService.LogiraniKorisnik!.GradId)
                {
                    err.SetError(tbPass, null);
                    err.SetError(tbPotvrda, null);
                    return true;
                }
                else
                {
                    err.SetError(tbPass, "Unesite lozinku!");
                    err.SetError(tbPotvrda, "Potvrdite lozinku!");
                    return false;
                }
            }
            else if (tbPass.Text != tbPotvrda.Text)
            {
                err.SetError(tbPass, "Lozinke se ne poklapaju!");
                err.SetError(tbPotvrda, "Lozinke se ne poklapaju!");
                return false;
            }
            else err.Clear();

            return true;
        }


    }
}
