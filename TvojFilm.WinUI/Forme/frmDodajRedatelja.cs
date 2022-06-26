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
    public partial class frmDodajRedatelja : Form
    {
        private readonly APIService _redatelji = new APIService("Redatelji");
        private int? _id = null;
        private DataGridView? _dgvRedatelji = null;
        public frmDodajRedatelja(DataGridView? dgvRedatelji = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvRedatelji = dgvRedatelji;
        }

        private async void frmDodajRedatelja_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var redatelji = await _redatelji.GetById<Model.Redatelji>(_id);
                tbIme.Text = redatelji.Ime;
                tbPrezime.Text = redatelji.Prezime;
                dateTimePicker1.Value = redatelji.DatumRodjenja;
            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                RedateljiInsertRequest request = new RedateljiInsertRequest()
                {
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    DatumRodjenja = DateTime.Parse(dateTimePicker1.Value.ToShortDateString()),
                };
                
                var redatelji = await _redatelji.Get<List<Model.Redatelji>>(null);
                foreach (var item in redatelji)
                {
                    if (item.Ime.ToLower() == tbIme.Text.ToLower() && item.Prezime.ToLower() == tbPrezime.Text.ToLower())
                    {
                        err.SetError(tbIme, "Redatelj s odabranim imenom i prezimenom već postoji!");
                        err.SetError(tbPrezime, "Redatelj s odabranim imenom i prezimenom već postoji!");
                        return;
                    }
                }


                if (_id.HasValue)
                {
                    await _redatelji.Update<Model.Redatelji>(_id, request);
                }
                else
                {
                    await _redatelji.Insert<Model.Redatelji>(request);
                }
                MessageBox.Show("Operacija uspješna!");
                this.Close();
                if (_dgvRedatelji != null)
                    _dgvRedatelji.DataSource = await _redatelji.Get<List<Model.Redatelji>>(null);
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
