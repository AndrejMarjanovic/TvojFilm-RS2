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
    public partial class frmDodajZanr : Form
    {
        private readonly APIService _zanrovi = new APIService("Zanrovi");
        private int? _id = null;
        private DataGridView? _dgvZanrovi = null;
        public frmDodajZanr(DataGridView? dgvZanrovi = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvZanrovi = dgvZanrovi;
        }

        private async void frmDodajZanr_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var zanr = await _zanrovi.GetById<Model.Zanrovi>(_id);
                tbNaziv.Text = zanr.Naziv;

            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                ZanroviInsertRequest request = new ZanroviInsertRequest()
                {
                    Naziv = tbNaziv.Text,

                };
                var zanrovi = await _zanrovi.Get<List<Model.Zanrovi>>(null);
                foreach (var item in zanrovi)
                {
                    if (item.Naziv.ToLower() == tbNaziv.Text.ToLower())
                    {
                        err.SetError(tbNaziv, "Ovaj žanr je već dodan.");
                        return;
                    }
                }


                if (_id.HasValue)
                {
                    await _zanrovi.Update<Model.Zanrovi>(_id, request);

                }
                else
                {
                    await _zanrovi.Insert<Model.Zanrovi>(request);
                }
                this.Close();
                if (_dgvZanrovi != null)
                    _dgvZanrovi.DataSource = await _zanrovi.Get<List<Model.Zanrovi>>(null);
            }
        }

        private bool Validacija()
        {

            if (string.IsNullOrEmpty(tbNaziv.Text))
            {
                err.SetError(tbNaziv, "Unesite naziv.");
                return false;
            }
            else err.Clear();

            return true;
        }
    }
}
