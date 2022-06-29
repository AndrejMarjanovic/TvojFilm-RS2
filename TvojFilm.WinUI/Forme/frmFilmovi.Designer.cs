namespace TvojFilm.WinUI.Forme
{
    partial class frmFilmovi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.tbGulmac = new System.Windows.Forms.TextBox();
            this.tbRedatelj = new System.Windows.Forms.TextBox();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.dgvFilmovi = new System.Windows.Forms.DataGridView();
            this.NazivFilma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Redatelj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Glumac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Godina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drzava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zanr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ocjena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmovi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.cbZanr);
            this.groupBox1.Controls.Add(this.tbGulmac);
            this.groupBox1.Controls.Add(this.tbRedatelj);
            this.groupBox1.Controls.Add(this.tbNaziv);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga filmova po:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(564, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pretraga po žanru:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ime glumca:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ime redatelja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv filma:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDodaj.Location = new System.Drawing.Point(742, 50);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(130, 23);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj novi";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // cbZanr
            // 
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Location = new System.Drawing.Point(564, 51);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(172, 23);
            this.cbZanr.TabIndex = 3;
            this.cbZanr.SelectedIndexChanged += new System.EventHandler(this.cbZanr_SelectedIndexChanged);
            // 
            // tbGulmac
            // 
            this.tbGulmac.Location = new System.Drawing.Point(376, 50);
            this.tbGulmac.Name = "tbGulmac";
            this.tbGulmac.Size = new System.Drawing.Size(182, 23);
            this.tbGulmac.TabIndex = 2;
            this.tbGulmac.TextChanged += new System.EventHandler(this.tbGulmac_TextChanged);
            // 
            // tbRedatelj
            // 
            this.tbRedatelj.Location = new System.Drawing.Point(190, 50);
            this.tbRedatelj.Name = "tbRedatelj";
            this.tbRedatelj.Size = new System.Drawing.Size(180, 23);
            this.tbRedatelj.TabIndex = 1;
            this.tbRedatelj.TextChanged += new System.EventHandler(this.tbRedatelj_TextChanged);
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(6, 51);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(178, 23);
            this.tbNaziv.TabIndex = 0;
            this.tbNaziv.TextChanged += new System.EventHandler(this.tbNaziv_TextChanged);
            // 
            // dgvFilmovi
            // 
            this.dgvFilmovi.AllowUserToAddRows = false;
            this.dgvFilmovi.AllowUserToDeleteRows = false;
            this.dgvFilmovi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dgvFilmovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NazivFilma,
            this.Redatelj,
            this.Glumac,
            this.Godina,
            this.Drzava,
            this.Zanr,
            this.Ocjena,
            this.Cijena,
            this.Uredi,
            this.Ukloni});
            this.dgvFilmovi.Location = new System.Drawing.Point(12, 98);
            this.dgvFilmovi.Name = "dgvFilmovi";
            this.dgvFilmovi.ReadOnly = true;
            this.dgvFilmovi.RowTemplate.Height = 25;
            this.dgvFilmovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilmovi.Size = new System.Drawing.Size(878, 340);
            this.dgvFilmovi.TabIndex = 0;
            this.dgvFilmovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilmovi_CellContentClick);
            // 
            // NazivFilma
            // 
            this.NazivFilma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NazivFilma.DataPropertyName = "NazivFilma";
            this.NazivFilma.HeaderText = "Naziv filma";
            this.NazivFilma.Name = "NazivFilma";
            this.NazivFilma.ReadOnly = true;
            // 
            // Redatelj
            // 
            this.Redatelj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Redatelj.DataPropertyName = "Redatelj";
            this.Redatelj.HeaderText = "Ime redatelja";
            this.Redatelj.Name = "Redatelj";
            this.Redatelj.ReadOnly = true;
            // 
            // Glumac
            // 
            this.Glumac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Glumac.DataPropertyName = "Glumac";
            this.Glumac.HeaderText = "Glavna uloga";
            this.Glumac.Name = "Glumac";
            this.Glumac.ReadOnly = true;
            // 
            // Godina
            // 
            this.Godina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Godina.DataPropertyName = "Godina";
            this.Godina.HeaderText = "Datum";
            this.Godina.Name = "Godina";
            this.Godina.ReadOnly = true;
            // 
            // Drzava
            // 
            this.Drzava.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Drzava.DataPropertyName = "Drzava";
            this.Drzava.HeaderText = "Zemlja";
            this.Drzava.Name = "Drzava";
            this.Drzava.ReadOnly = true;
            // 
            // Zanr
            // 
            this.Zanr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Zanr.DataPropertyName = "Zanr";
            this.Zanr.HeaderText = "Žanr";
            this.Zanr.Name = "Zanr";
            this.Zanr.ReadOnly = true;
            // 
            // Ocjena
            // 
            this.Ocjena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ocjena.DataPropertyName = "Ocjena";
            this.Ocjena.HeaderText = "Ocjena";
            this.Ocjena.Name = "Ocjena";
            this.Ocjena.ReadOnly = true;
            this.Ocjena.Width = 69;
            // 
            // Cijena
            // 
            this.Cijena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Width = 65;
            // 
            // Uredi
            // 
            this.Uredi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Uredi.HeaderText = "Uredi";
            this.Uredi.Name = "Uredi";
            this.Uredi.ReadOnly = true;
            this.Uredi.Text = "Uredi";
            this.Uredi.UseColumnTextForButtonValue = true;
            this.Uredi.Width = 41;
            // 
            // Ukloni
            // 
            this.Ukloni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ukloni.HeaderText = "Ukloni";
            this.Ukloni.Name = "Ukloni";
            this.Ukloni.ReadOnly = true;
            this.Ukloni.Text = "Ukloni";
            this.Ukloni.UseColumnTextForButtonValue = true;
            this.Ukloni.Width = 47;
            // 
            // frmFilmovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(897, 449);
            this.Controls.Add(this.dgvFilmovi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFilmovi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFilmovi";
            this.Load += new System.EventHandler(this.frmFilmovi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmovi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDodaj;
        private ComboBox cbZanr;
        private TextBox tbGulmac;
        private TextBox tbRedatelj;
        private TextBox tbNaziv;
        private DataGridView dgvFilmovi;
        private DataGridViewTextBoxColumn NazivFilma;
        private DataGridViewTextBoxColumn Redatelj;
        private DataGridViewTextBoxColumn Glumac;
        private DataGridViewTextBoxColumn Godina;
        private DataGridViewTextBoxColumn Drzava;
        private DataGridViewTextBoxColumn Zanr;
        private DataGridViewTextBoxColumn Ocjena;
        private DataGridViewTextBoxColumn Cijena;
        private DataGridViewButtonColumn Uredi;
        private DataGridViewButtonColumn Ukloni;
    }
}