namespace TvojFilm.WinUI.Forme
{
    partial class frmSugestije
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
            this.dgvSugestije = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSugestija = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sugestija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestije)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSugestije
            // 
            this.dgvSugestije.AllowUserToAddRows = false;
            this.dgvSugestije.AllowUserToDeleteRows = false;
            this.dgvSugestije.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.dgvSugestije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugestije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sugestija,
            this.Opis,
            this.Korisnik,
            this.Datum,
            this.Ukloni});
            this.dgvSugestije.Location = new System.Drawing.Point(3, 85);
            this.dgvSugestije.Name = "dgvSugestije";
            this.dgvSugestije.ReadOnly = true;
            this.dgvSugestije.RowTemplate.Height = 25;
            this.dgvSugestije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSugestije.Size = new System.Drawing.Size(567, 254);
            this.dgvSugestije.TabIndex = 0;
            this.dgvSugestije.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSugestije_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSugestija);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga sugestija:";
            // 
            // tbSugestija
            // 
            this.tbSugestija.Location = new System.Drawing.Point(9, 51);
            this.tbSugestija.Name = "tbSugestija";
            this.tbSugestija.Size = new System.Drawing.Size(256, 23);
            this.tbSugestija.TabIndex = 6;
            this.tbSugestija.TextChanged += new System.EventHandler(this.tbSugestija_TextChanged);
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
            // Sugestija
            // 
            this.Sugestija.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sugestija.DataPropertyName = "PrijedlogIme";
            this.Sugestija.HeaderText = "Sugestija";
            this.Sugestija.Name = "Sugestija";
            this.Sugestija.ReadOnly = true;
            this.Sugestija.Width = 79;
            // 
            // Opis
            // 
            this.Opis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // Korisnik
            // 
            this.Korisnik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            this.Korisnik.Width = 74;
            // 
            // Datum
            // 
            this.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Datum.DataPropertyName = "DatumPrijedloga";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 68;
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
            // frmSugestije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(573, 339);
            this.Controls.Add(this.dgvSugestije);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSugestije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSugestije";
            this.Load += new System.EventHandler(this.frmSugestije_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestije)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvSugestije;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox tbSugestija;
        private DataGridViewTextBoxColumn Sugestija;
        private DataGridViewTextBoxColumn Opis;
        private DataGridViewTextBoxColumn Korisnik;
        private DataGridViewTextBoxColumn Datum;
        private DataGridViewButtonColumn Ukloni;
    }
}