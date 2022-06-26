namespace TvojFilm.WinUI.Forme
{
    partial class frmDrzave
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.dgvDrzave = new System.Windows.Forms.DataGridView();
            this.Drzava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrzave)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNaziv);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga država:";
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
            this.tbNaziv.Size = new System.Drawing.Size(172, 23);
            this.tbNaziv.TabIndex = 0;
            this.tbNaziv.TextChanged += new System.EventHandler(this.tbNaziv_TextChanged);
            // 
            // dgvDrzave
            // 
            this.dgvDrzave.AllowUserToAddRows = false;
            this.dgvDrzave.AllowUserToDeleteRows = false;
            this.dgvDrzave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(34)))), ((int)(((byte)(61)))));
            this.dgvDrzave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrzave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Drzava,
            this.Uredi,
            this.Ukloni});
            this.dgvDrzave.Location = new System.Drawing.Point(12, 98);
            this.dgvDrzave.Name = "dgvDrzave";
            this.dgvDrzave.ReadOnly = true;
            this.dgvDrzave.RowTemplate.Height = 25;
            this.dgvDrzave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrzave.Size = new System.Drawing.Size(443, 241);
            this.dgvDrzave.TabIndex = 0;
            this.dgvDrzave.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrzave_CellContentClick);
            // 
            // Drzava
            // 
            this.Drzava.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Drzava.DataPropertyName = "Naziv";
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
            // frmDrzave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(53)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(467, 350);
            this.Controls.Add(this.dgvDrzave);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDrzave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDrzave";
            this.Load += new System.EventHandler(this.frmDrzave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrzave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnDodaj;
        private Label label1;
        private TextBox tbNaziv;
        private DataGridView dgvDrzave;
        private DataGridViewTextBoxColumn Drzava;
        private DataGridViewButtonColumn Uredi;
        private DataGridViewButtonColumn Ukloni;
    }
}