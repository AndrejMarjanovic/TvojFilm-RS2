namespace TvojFilm.WinUI.Forme
{
    partial class frmRedatelji
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
            this.dgvRedatelji = new System.Windows.Forms.DataGridView();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRodjenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedatelji)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRedatelji
            // 
            this.dgvRedatelji.AllowUserToAddRows = false;
            this.dgvRedatelji.AllowUserToDeleteRows = false;
            this.dgvRedatelji.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dgvRedatelji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRedatelji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Prezime,
            this.DatumRodjenja,
            this.Uredi,
            this.Ukloni});
            this.dgvRedatelji.Location = new System.Drawing.Point(12, 98);
            this.dgvRedatelji.Name = "dgvRedatelji";
            this.dgvRedatelji.ReadOnly = true;
            this.dgvRedatelji.RowTemplate.Height = 25;
            this.dgvRedatelji.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRedatelji.Size = new System.Drawing.Size(509, 241);
            this.dgvRedatelji.TabIndex = 0;
            this.dgvRedatelji.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRedatelji_CellContentClick);
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // DatumRodjenja
            // 
            this.DatumRodjenja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumRodjenja.DataPropertyName = "DatumRodjenja";
            this.DatumRodjenja.HeaderText = "Datum rođenja";
            this.DatumRodjenja.Name = "DatumRodjenja";
            this.DatumRodjenja.ReadOnly = true;
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
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(6, 51);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(161, 23);
            this.tbNaziv.TabIndex = 0;
            this.tbNaziv.TextChanged += new System.EventHandler(this.tbNaziv_TextChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDodaj.Location = new System.Drawing.Point(374, 51);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(129, 23);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj novi";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ime:";
            // 
            // tbPrezime
            // 
            this.tbPrezime.Location = new System.Drawing.Point(173, 51);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Size = new System.Drawing.Size(165, 23);
            this.tbPrezime.TabIndex = 6;
            this.tbPrezime.TextChanged += new System.EventHandler(this.tbPrezime_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPrezime);
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNaziv);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga redatelja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prezime:";
            // 
            // frmRedatelji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(536, 351);
            this.Controls.Add(this.dgvRedatelji);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRedatelji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRedatelji";
            this.Load += new System.EventHandler(this.frmRedatelji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedatelji)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dgvRedatelji;
        private TextBox tbNaziv;
        private Button btnDodaj;
        private Label label1;
        private TextBox tbPrezime;
        private GroupBox groupBox1;
        private Label label2;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn DatumRodjenja;
        private DataGridViewButtonColumn Uredi;
        private DataGridViewButtonColumn Ukloni;
    }
}