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
    public partial class frmDodajGrad : Form
    {
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _drzave = new APIService("Drzave");
        private int? _id = null;
        private DataGridView? _dgvGradovi = null;
        public frmDodajGrad(DataGridView? dgvGradovi = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvGradovi = dgvGradovi;
        }

        private async void frmDodajGrad_Load(object sender, EventArgs e)
        {
            await UcitajDrzave();
            if (_id.HasValue) //update
            {
                var grad = await _gradovi.GetById<Model.Gradovi>(_id);
                tbNaziv.Text = grad.Naziv;

                foreach (Model.Drzave item in cbDrzave.Items)
                {
                    if (item.DrzavaId == grad.DrzavaId)
                        cbDrzave.SelectedItem = item;

                }

            }
        }
        private async Task UcitajDrzave()
        {
            var result = await _drzave.Get<List<Model.Drzave>>(null);
            result.Insert(0, new Model.Drzave());
            cbDrzave.DisplayMember = "Naziv";
            cbDrzave.ValueMember = "DrzavaId";
            cbDrzave.DataSource = result;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                int drzavaID = (cbDrzave.SelectedItem as Model.Drzave).DrzavaId;
                GradoviInsertRequest request = new GradoviInsertRequest()
                {
                    Naziv = tbNaziv.Text,
                    DrzavaId = (cbDrzave.SelectedItem as Model.Drzave).DrzavaId

                };
                var gradovi = await _gradovi.Get<List<Model.Gradovi>>(null);
                foreach (var i in gradovi)
                {
                    if (i.Naziv.ToLower() == tbNaziv.Text.ToLower() && i.DrzavaId == drzavaID)
                    {
                        err.SetError(tbNaziv, "Istoimeni grad je već dodan za državu " + i.Drzava.Naziv + ".");
                        return;
                    }
                }


                if (_id.HasValue)
                {
                    await _gradovi.Update<Model.Gradovi>(_id, request);

                }
                else
                {
                    await _gradovi.Insert<Model.Gradovi>(request);
                }
                this.Close();
                if (_dgvGradovi != null)
                    _dgvGradovi.DataSource = await _gradovi.Get<List<Model.Gradovi>>(null);
            }
        }
        private bool Validacija()
        {
            if (string.IsNullOrEmpty(tbNaziv.Text))
            {
                err.SetError(tbNaziv, "Unesite naziv!");
                return false;
            }
            else err.Clear();

            if (string.IsNullOrEmpty(cbDrzave.Text))
            {
                err.SetError(cbDrzave, "Obavezno polje!");
                return false;
            }
            else err.Clear();


            return true;
        }
    }
}
