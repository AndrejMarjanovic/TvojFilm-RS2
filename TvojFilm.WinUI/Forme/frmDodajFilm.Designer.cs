namespace TvojFilm.WinUI.Forme
{
    partial class frmDodajFilm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbOcjena = new System.Windows.Forms.TextBox();
            this.tbCijena = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.btnSlika = new System.Windows.Forms.Button();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.cbRedatelj = new System.Windows.Forms.ComboBox();
            this.cbGlumac = new System.Windows.Forms.ComboBox();
            this.cbZemlja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRadnja = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSpremi = new System.Windows.Forms.Button();
            this.ofdSlika = new System.Windows.Forms.OpenFileDialog();
            this.tbFilmLink = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOcjena
            // 
            this.tbOcjena.Location = new System.Drawing.Point(306, 219);
            this.tbOcjena.Name = "tbOcjena";
            this.tbOcjena.Size = new System.Drawing.Size(77, 23);
            this.tbOcjena.TabIndex = 45;
            // 
            // tbCijena
            // 
            this.tbCijena.Location = new System.Drawing.Point(445, 219);
            this.tbCijena.Name = "tbCijena";
            this.tbCijena.Size = new System.Drawing.Size(81, 23);
            this.tbCijena.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "Cijena:";
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(358, 174);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(168, 23);
            this.dtp.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 39;
            this.label7.Text = "Ocjena:";
            // 
            // cbZanr
            // 
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Location = new System.Drawing.Point(358, 116);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(168, 23);
            this.cbZanr.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Zamlja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "Žanr:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "Glavna uloga:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Redatelj:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Naziv filma:";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(358, 29);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(168, 23);
            this.tbNaziv.TabIndex = 27;
            // 
            // btnSlika
            // 
            this.btnSlika.Location = new System.Drawing.Point(57, 211);
            this.btnSlika.Name = "btnSlika";
            this.btnSlika.Size = new System.Drawing.Size(106, 23);
            this.btnSlika.TabIndex = 25;
            this.btnSlika.Text = "Dodaj sliku";
            this.btnSlika.UseVisualStyleBackColor = true;
            this.btnSlika.Click += new System.EventHandler(this.btnSlika_Click);
            // 
            // pbSlika
            // 
            this.pbSlika.Location = new System.Drawing.Point(47, 29);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(128, 168);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 24;
            this.pbSlika.TabStop = false;
            this.pbSlika.Click += new System.EventHandler(this.pbSlika_Click);
            // 
            // cbRedatelj
            // 
            this.cbRedatelj.FormattingEnabled = true;
            this.cbRedatelj.Location = new System.Drawing.Point(358, 58);
            this.cbRedatelj.Name = "cbRedatelj";
            this.cbRedatelj.Size = new System.Drawing.Size(168, 23);
            this.cbRedatelj.TabIndex = 47;
            // 
            // cbGlumac
            // 
            this.cbGlumac.FormattingEnabled = true;
            this.cbGlumac.Location = new System.Drawing.Point(358, 87);
            this.cbGlumac.Name = "cbGlumac";
            this.cbGlumac.Size = new System.Drawing.Size(168, 23);
            this.cbGlumac.TabIndex = 48;
            // 
            // cbZemlja
            // 
            this.cbZemlja.FormattingEnabled = true;
            this.cbZemlja.Location = new System.Drawing.Point(358, 145);
            this.cbZemlja.Name = "cbZemlja";
            this.cbZemlja.Size = new System.Drawing.Size(168, 23);
            this.cbZemlja.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "Datum:";
            // 
            // tbRadnja
            // 
            this.tbRadnja.Location = new System.Drawing.Point(327, 285);
            this.tbRadnja.Name = "tbRadnja";
            this.tbRadnja.Size = new System.Drawing.Size(199, 59);
            this.tbRadnja.TabIndex = 52;
            this.tbRadnja.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 53;
            this.label8.Text = "Radnja:";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(404, 374);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(122, 23);
            this.btnSpremi.TabIndex = 54;
            this.btnSpremi.Text = "Spremi promjene";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // ofdSlika
            // 
            this.ofdSlika.FileName = "openFileDialog1";
            // 
            // tbFilmLink
            // 
            this.tbFilmLink.Location = new System.Drawing.Point(30, 321);
            this.tbFilmLink.Name = "tbFilmLink";
            this.tbFilmLink.Size = new System.Drawing.Size(168, 23);
            this.tbFilmLink.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 56;
            this.label10.Text = "Film link (YouTube):";
            // 
            // frmDodajFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 410);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbFilmLink);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbRadnja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbZemlja);
            this.Controls.Add(this.cbGlumac);
            this.Controls.Add(this.cbRedatelj);
            this.Controls.Add(this.tbOcjena);
            this.Controls.Add(this.tbCijena);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbZanr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNaziv);
            this.Controls.Add(this.btnSlika);
            this.Controls.Add(this.pbSlika);
            this.Name = "frmDodajFilm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDodajFilm";
            this.Load += new System.EventHandler(this.frmDodajFilm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbOcjena;
        private TextBox tbCijena;
        private Label label9;
        private DateTimePicker dtp;
        private Label label7;
        private ComboBox cbZanr;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox tbNaziv;
        private Button btnSlika;
        private PictureBox pbSlika;
        private ComboBox cbRedatelj;
        private ComboBox cbGlumac;
        private ComboBox cbZemlja;
        private Label label1;
        private RichTextBox tbRadnja;
        private Label label8;
        private ErrorProvider err;
        private Button btnSpremi;
        private OpenFileDialog ofdSlika;
        private Label label10;
        private TextBox tbFilmLink;
    }
}