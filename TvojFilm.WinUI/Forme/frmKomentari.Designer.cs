namespace TvojFilm.WinUI.Forme
{
    partial class frmKomentari
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
            this.dgvKomentari = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKomentar = new System.Windows.Forms.TextBox();
            this.Komentar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Film = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKomentari)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKomentari
            // 
            this.dgvKomentari.AllowUserToAddRows = false;
            this.dgvKomentari.AllowUserToDeleteRows = false;
            this.dgvKomentari.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.dgvKomentari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKomentari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Komentar,
            this.Korisnik,
            this.Film,
            this.Datum,
            this.Ukloni});
            this.dgvKomentari.Location = new System.Drawing.Point(12, 93);
            this.dgvKomentari.Name = "dgvKomentari";
            this.dgvKomentari.ReadOnly = true;
            this.dgvKomentari.RowTemplate.Height = 25;
            this.dgvKomentari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKomentari.Size = new System.Drawing.Size(567, 254);
            this.dgvKomentari.TabIndex = 0;
            this.dgvKomentari.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKomentari_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbKomentar);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga komentara:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ključne riječi:";
            // 
            // tbKomentar
            // 
            this.tbKomentar.Location = new System.Drawing.Point(6, 51);
            this.tbKomentar.Name = "tbKomentar";
            this.tbKomentar.Size = new System.Drawing.Size(270, 23);
            this.tbKomentar.TabIndex = 0;
            this.tbKomentar.TextChanged += new System.EventHandler(this.tbKomentar_TextChanged);
            // 
            // Komentar
            // 
            this.Komentar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Komentar.DataPropertyName = "Komentar";
            this.Komentar.HeaderText = "Komentar";
            this.Komentar.Name = "Komentar";
            this.Komentar.ReadOnly = true;
            // 
            // Korisnik
            // 
            this.Korisnik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            // 
            // Film
            // 
            this.Film.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Film.DataPropertyName = "Film";
            this.Film.HeaderText = "Film";
            this.Film.Name = "Film";
            this.Film.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "DatumKomentara";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
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
            // frmKomentari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(591, 359);
            this.Controls.Add(this.dgvKomentari);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmKomentari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKomentari";
            this.Load += new System.EventHandler(this.frmKomentari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKomentari)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvKomentari;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox tbKomentar;
        private DataGridViewTextBoxColumn Komentar;
        private DataGridViewTextBoxColumn Korisnik;
        private DataGridViewTextBoxColumn Film;
        private DataGridViewTextBoxColumn Datum;
        private DataGridViewButtonColumn Ukloni;
    }
}