using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvojFilm.WinUI.Forme;

namespace TvojFilm.WinUI.Forme
{
    public partial class mdiMain : Form
    {
        private int childFormNumber = 0;

        public mdiMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.Show();
        }

        private void filmoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFilmovi frm = new frmFilmovi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void redateljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRedatelji frm = new frmRedatelji();
            frm.MdiParent = this;
            frm.Show();
        }

        private void glumciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGlumci frm = new frmGlumci();
            frm.MdiParent = this;
            frm.Show();
        }

        private void odjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Close();
            frm.Show();
        }

        private void državeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrzave frm = new frmDrzave();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradovi frm = new frmGradovi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void žanroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZanrovi frm = new frmZanrovi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void komentariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKomentari frm = new frmKomentari();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sugestijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSugestije frm = new frmSugestije();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mdiMain_Load(object sender, EventArgs e)
        {

        }
    }
}
