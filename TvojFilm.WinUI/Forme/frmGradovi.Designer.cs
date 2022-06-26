namespace TvojFilm.WinUI.Forme
{
    partial class frmGradovi
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
            this.dgvGradovi = new System.Windows.Forms.DataGridView();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drzava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDrzava = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradovi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGradovi
            // 
            this.dgvGradovi.AllowUserToAddRows = false;
            this.dgvGradovi.AllowUserToDeleteRows = false;
            this.dgvGradovi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(36)))), ((int)(((byte)(64)))));
            this.dgvGradovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grad,
            this.Drzava,
            this.Uredi,
            this.Ukloni});
            this.dgvGradovi.Location = new System.Drawing.Point(13, 98);
            this.dgvGradovi.Name = "dgvGradovi";
            this.dgvGradovi.ReadOnly = true;
            this.dgvGradovi.RowTemplate.Height = 25;
            this.dgvGradovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGradovi.Size = new System.Drawing.Size(443, 241);
            this.dgvGradovi.TabIndex = 0;
            this.dgvGradovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradovi_CellContentClick);
            // 
            // Grad
            // 
            this.Grad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Grad.DataPropertyName = "Naziv";
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            // 
            // Drzava
            // 
            this.Drzava.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Drzava.DataPropertyName = "Drzava";
            this.Drzava.HeaderText = "Drzava";
            this.Drzava.Name = "Drzava";
            this.Drzava.ReadOnly = true;
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
            this.Ukloni.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ukloni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ukloni.Text = "Ukloni";
            this.Ukloni.UseColumnTextForButtonValue = true;
            this.Ukloni.Width = 66;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDrzava);
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNaziv);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga gradova:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Država:";
            // 
            // tbDrzava
            // 
            this.tbDrzava.Location = new System.Drawing.Point(155, 51);
            this.tbDrzava.Name = "tbDrzava";
            this.tbDrzava.Size = new System.Drawing.Size(142, 23);
            this.tbDrzava.TabIndex = 6;
            this.tbDrzava.TextChanged += new System.EventHandler(this.tbDrzava_TextChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDodaj.Location = new System.Drawing.Point(303, 51);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(129, 23);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv:";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(6, 51);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(142, 23);
            this.tbNaziv.TabIndex = 0;
            this.tbNaziv.TextChanged += new System.EventHandler(this.tbNaziv_TextChanged);
            // 
            // frmGradovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(469, 350);
            this.Controls.Add(this.dgvGradovi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGradovi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGradovi";
            this.Load += new System.EventHandler(this.frmGradovi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradovi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvGradovi;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox tbDrzava;
        private Button btnDodaj;
        private Label label1;
        private TextBox tbNaziv;
        private DataGridViewTextBoxColumn Grad;
        private DataGridViewTextBoxColumn Drzava;
        private DataGridViewButtonColumn Uredi;
        private DataGridViewButtonColumn Ukloni;
    }
}