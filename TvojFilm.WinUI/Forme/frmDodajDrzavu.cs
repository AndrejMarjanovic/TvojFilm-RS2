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
    public partial class frmDodajDrzavu : Form
    {
        private readonly APIService _drzave = new APIService("Drzave");
        private int? _id = null;
        private DataGridView? _dgvDrzave = null;
        public frmDodajDrzavu(DataGridView? dgvDrzave = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvDrzave = dgvDrzave;
        }

        private async void frmDodajDrzavu_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var drzava = await _drzave.GetById<Model.Drzave>(_id);
                tbDrzava.Text = drzava.Naziv;

            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                DrzaveInsertRequest request = new DrzaveInsertRequest()
                {
                    Naziv = tbDrzava.Text,

                };
                var drzave = await _drzave.Get<List<Model.Drzave>>(null);
                foreach (var i in drzave)
                {
                    if (i.Naziv.ToLower() == tbDrzava.Text.ToLower())
                    {
                        err.SetError(tbDrzava, "Država je već dodana!");
                        return;
                    }
                }


                if (_id.HasValue)
                {
                    await _drzave.Update<Model.Drzave>(_id, request);

                }
                else
                {
                    await _drzave.Insert<Model.Drzave>(request);
                }
                this.Close();
                if (_dgvDrzave != null)
                    _dgvDrzave.DataSource = await _drzave.Get<List<Model.Drzave>>(null);
            }
        }
        private bool Validacija()
        {
            if (string.IsNullOrEmpty(tbDrzava.Text))
            {
                err.SetError(tbDrzava, "Unesite naziv prije spremanja!");
                return false;
            }
            else err.Clear();

            return true;
        }
    }
}
