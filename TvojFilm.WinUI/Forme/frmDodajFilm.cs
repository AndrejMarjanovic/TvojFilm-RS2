using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TvojFilm.Model.Requests;
using TvojFilm.WinUI.API;

namespace TvojFilm.WinUI.Forme
{
    public partial class frmDodajFilm : Form
    {
        private readonly APIService _zanrovi = new APIService("Zanrovi");
        private readonly APIService _redatelji = new APIService("Redatelji");
        private readonly APIService _glumci = new APIService("Glumci");
        private readonly APIService _filmovi = new APIService("Filmovi");
        private readonly APIService _zemlje = new APIService("Drzave");
        private int? _id = null;
        private byte[] videoFile = null;
        private DataGridView? _dgvFilmovi = null;
        public frmDodajFilm(DataGridView? dgvFilmovi = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _dgvFilmovi = dgvFilmovi;
        }

        private async void frmDodajFilm_Load(object sender, EventArgs e)
        {
            await UcitajZanrove();
            await UcitajRedatelje();
            await UcitajZemlje();
            await UcitajGlumce();

            if (_id.HasValue) 
            {
                var film = await _filmovi.GetById<Model.Filmovi>(_id);
                tbNaziv.Text = film.NazivFilma;
                tbCijena.Text = film.Cijena.ToString();
                tbOcjena.Text = film.Ocjena.ToString();
                tbRadnja.Text = film.Opis;
                dtp.Value = film.Godina;
                tbFilmLink.Text = film.FilmLink;

                if (film.Poster.Length > 0)
                {
                    pbSlika.Image = ImgHelper.FromByteToImage(film.Poster);
                }

                foreach (Model.Redatelji item in cbRedatelj.Items)
                {
                    if (item.RedateljId == film.RedateljId)
                        cbRedatelj.SelectedItem = item;
                }
                foreach (Model.Glumci item in cbGlumac.Items)
                {
                    if (item.GlumacId == film.GlumacId)
                        cbGlumac.SelectedItem = item;
                }
                foreach (Model.Zanrovi item in cbZanr.Items)
                {
                    if (item.ZanrId == film.ZanrId)
                        cbZanr.SelectedItem = item;
                }
                foreach (Model.Drzave item in cbZemlja.Items)
                {
                    if (item.DrzavaId == film.DrzavaId)
                        cbZemlja.SelectedItem = item;
                }
            }
        }

        private async Task UcitajZanrove()
        {
            var result = await _zanrovi.Get<List<Model.Zanrovi>>(null);
            result.Insert(0, new Model.Zanrovi());
            cbZanr.DataSource = result;
            cbZanr.DisplayMember = "Naziv";
            cbZanr.ValueMember = "ZanrId";
        }
        private async Task UcitajRedatelje()
        {
            var result = await _redatelji.Get<List<Model.Redatelji>>(null);
            result.Insert(0, new Model.Redatelji());
            cbRedatelj.DataSource = result;
            cbRedatelj.DisplayMember = "ImePrezime";
            cbRedatelj.ValueMember = "RedateljId";
        }
        private async Task UcitajGlumce()
        {
            var result = await _glumci.Get<List<Model.Glumci>>(null);
            result.Insert(0, new Model.Glumci());
            cbGlumac.DataSource = result;
            cbGlumac.DisplayMember = "ImePrezime";
            cbGlumac.ValueMember = "GlumacId";
        }
        private async Task UcitajZemlje()
        {
            var result = await _zemlje.Get<List<Model.Drzave>>(null);
            result.Insert(0, new Model.Drzave());
            cbZemlja.DataSource = result;
            cbZemlja.DisplayMember = "Naziv";
            cbZemlja.ValueMember = "DrzavaId";
        }

        private void btnSlika_Click(object sender, EventArgs e)
        {
            if (ofdSlika.ShowDialog() == DialogResult.OK)
            {
                string putanja = ofdSlika.FileName;
                Image slika = Image.FromFile(putanja);
                pbSlika.Image = slika;
            }
        }

        private void pbSlika_Click(object sender, EventArgs e)
        {
            if (ofdSlika.ShowDialog() == DialogResult.OK)
            {
                string putanja = ofdSlika.FileName;
                Image slika = Image.FromFile(putanja);
                pbSlika.Image = slika;
            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (await Validacija())
            {
                FilmoviInsertRequest request = new FilmoviInsertRequest()
                {
                    NazivFilma = tbNaziv.Text,
                    Cijena = Double.Parse(tbCijena.Text),
                    Ocjena = Double.Parse(tbOcjena.Text),
                    Opis = tbRadnja.Text,
                    Godina = DateTime.Parse(dtp.Value.ToShortDateString()),

                    FilmLink = tbFilmLink.Text,
                        
                    RedateljId = (cbRedatelj.SelectedItem as Model.Redatelji).RedateljId,
                    GlumacId = (cbGlumac.SelectedItem as Model.Glumci).GlumacId,
                    ZanrId = (cbZanr.SelectedItem as Model.Zanrovi).ZanrId,
                    DrzavaId = (cbZemlja.SelectedItem as Model.Drzave).DrzavaId,

                };

                if (_id.HasValue)
                {

                    if (pbSlika.Image != null)
                        request.Poster = ImgHelper.FromImageToByte(pbSlika.Image);
                    await _filmovi.Update<Model.Filmovi>(_id, request);

                }
                else
                {

                    if (pbSlika.Image != null)
                        request.Poster = ImgHelper.FromImageToByte(pbSlika.Image);
                    else
                        request.Poster = ImgHelper.FromImageToByte(WinUI.Properties.Resources.poster);
                    await _filmovi.Insert<Model.Filmovi>(request);
                }
                MessageBox.Show("Operacija uspješna!");
                this.Close();
                if (_dgvFilmovi != null)
                    _dgvFilmovi.DataSource = await _filmovi.Get<List<Model.Filmovi>>(null);
            }
        }

        private async Task<bool> Validacija()
        {
            if (string.IsNullOrEmpty(tbNaziv.Text))
            {
                err.SetError(tbNaziv, "Unesite naziv filma!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(tbFilmLink.Text))
            {
                err.SetError(tbFilmLink, "Unesite link za film!");
                return false;
            }
            else err.Clear();
            if (!(tbFilmLink.Text.Contains("https://www.youtube.com/watch?") || tbFilmLink.Text.Contains("https://youtu.be/")))
            {
                err.SetError(tbFilmLink, "Unesite validan Youtube link! (https://www.youtube.com/watch?...)");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(cbZanr.Text))
            {
                err.SetError(cbZanr, "Odaberite žanr!");
                return false;
            }
            else err.Clear();
            if (cbRedatelj.SelectedIndex <= 0)
            {
                err.SetError(cbRedatelj, "Odaberite redatelja!");
                return false;
            }
            else err.Clear();
            if (cbGlumac.SelectedIndex <= 0)
            {
                err.SetError(cbGlumac, "Odaberite glavnog glumca!");
                return false;
            }
            else err.Clear();
            if (cbZemlja.SelectedIndex <= 0)
            {
                err.SetError(cbZemlja, "Odaberite državu!");
                return false;
            }
            else err.Clear();
            if (string.IsNullOrEmpty(tbRadnja.Text))
            {
                err.SetError(tbRadnja, "Unesite radnju filma!");
                return false;
            }
            else err.Clear();


            if (string.IsNullOrEmpty(tbCijena.Text))
            {
                err.SetError(tbCijena, "Unesite cijenu filma!");
                return false;
            }
            else err.Clear();
            double dbl;
            if (double.TryParse(tbCijena.Text, out dbl))
            {
                double.Parse(tbCijena.Text);
            }
            else
            {
                err.SetError(tbCijena, "Polje cijena prihvaća samo brojeve!");
                return false;
            }
            if (double.TryParse(tbOcjena.Text, out dbl))
            {
                double.Parse(tbOcjena.Text);
            }
            else
            {
                err.SetError(tbOcjena, "Polje ocjena prihvaća samo brojeve!");
                return false;
            }

            var result = await _filmovi.Get<List<Model.Filmovi>>(null);
            int id = _id ?? 0;

            foreach (var item in result)
            {

                if (item.NazivFilma == tbNaziv.Text && item.RedateljId == (cbRedatelj.SelectedItem as Model.Redatelji).RedateljId && item.FilmId != id)
                {
                    err.SetError(tbNaziv, "Film sa ovim nazivom sa odabranim redateljem već postoji u bazi!");

                    return false;
                }

            }

            return true;
        }


    }
}
