namespace TvojFilm.WinUI.Forme
{
    partial class frmDodajGrad
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
            this.btnSpremi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDrzave = new System.Windows.Forms.ComboBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(266, 89);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(120, 23);
            this.btnSpremi.TabIndex = 5;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Naziv države:";
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(12, 45);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(182, 23);
            this.tbNaziv.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Naziv grada:";
            // 
            // cbDrzave
            // 
            this.cbDrzave.FormattingEnabled = true;
            this.cbDrzave.Location = new System.Drawing.Point(204, 45);
            this.cbDrzave.Name = "cbDrzave";
            this.cbDrzave.Size = new System.Drawing.Size(182, 23);
            this.cbDrzave.TabIndex = 7;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmDodajGrad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 123);
            this.Controls.Add(this.cbDrzave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNaziv);
            this.Name = "frmDodajGrad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDodajGrad";
            this.Load += new System.EventHandler(this.frmDodajGrad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSpremi;
        private Label label1;
        private TextBox tbNaziv;
        private Label label2;
        private ComboBox cbDrzave;
        private ErrorProvider err;
    }
}