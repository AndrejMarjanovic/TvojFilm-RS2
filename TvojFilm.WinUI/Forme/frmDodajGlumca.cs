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
    public partial class frmDodajGlumca : Form
    {
        private readonly APIService _glumci = new APIService("Glumci");
        private int? _id = null;
        private DataGridView? _dgvGlumci = null;
        public frmDodajGlumca(DataGridView? dgvGlumci = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvGlumci = dgvGlumci;
        }

        private async void frmDodajGlumca_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var glumci = await _glumci.GetById<Model.Glumci>(_id);
                tbIme.Text = glumci.Ime;
                tbPrezime.Text = glumci.Prezime;
                dateTimePicker1.Value = glumci.DatumRodjenja;
            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                GlumciInsertRequest request = new GlumciInsertRequest()
                {
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    DatumRodjenja = DateTime.Parse(dateTimePicker1.Value.ToShortDateString()),
                };

                var glumci = await _glumci.Get<List<Model.Glumci>>(null);
                foreach (var item in glumci)
                {
                    if (item.Ime.ToLower() == tbIme.Text.ToLower() && item.Prezime.ToLower() == tbPrezime.Text.ToLower())
                    {
                        err.SetError(tbIme, "Glumac s odabranim imenom i prezimenom već postoji!");
                        err.SetError(tbPrezime, "Glumac s odabranim imenom i prezimenom već postoji!");
                        return;
                    }
                }


                if (_id.HasValue)
                {
                    await _glumci.Update<Model.Glumci>(_id, request);
                }
                else
                {
                    await _glumci.Insert<Model.Glumci>(request);
                }
                MessageBox.Show("Operacija uspješna!");
                this.Close();
                if (_dgvGlumci != null)
                    _dgvGlumci.DataSource = await _glumci.Get<List<Model.Glumci>>(null);
            }
        }

        private bool Validacija()
        {
            if (string.IsNullOrEmpty(tbIme.Text))
            {
                err.SetError(tbIme, "Unesite ime!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(tbPrezime.Text))
            {
                err.SetError(tbPrezime, "Unesite prezime!");
                return false;
            }
            else err.Clear();

            return true;
        }
    }
}
