using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvojFilm.WinUI.Report;

namespace TvojFilm.WinUI.Forme
{
    public partial class frmReport : Form
    {
        private dtoFilmovi dtoFilmovi;

        public frmReport()
        {
            InitializeComponent();
        }

        public frmReport(dtoFilmovi dtoFilmovi) : this()
        {
            this.dtoFilmovi = dtoFilmovi;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            var tblFilmovi = new dsReport.FilmoviDataTable();

            for (int i = 0; i < dtoFilmovi.Filmovi.Count; i++)
            {
                var red = tblFilmovi.NewFilmoviRow();
                var filmovi = dtoFilmovi.Filmovi[i];

                red.Rb = i + 1;
                red.NazivFilma = filmovi.NazivFilma;
                red.ImeRedatelja = filmovi.Redatelj.ImePrezime;
                red.GlavniGlumac = filmovi.Glumac.ImePrezime;
                red.Zemlja = filmovi.Drzava.Naziv;
                red.Zanr = filmovi.Zanr.Naziv;
                red.Ocjena = filmovi.Ocjena;
                red.Datum = filmovi.Godina.ToString("dd.MM.yyyy");
                tblFilmovi.AddFilmoviRow(red);
            }

            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "dsFilmovi";
            dataSource.Value = tblFilmovi;

            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.ReportEmbeddedResource = "TvojFilm.WinUI.Report.Report.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
