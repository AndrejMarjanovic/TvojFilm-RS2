namespace TvojFilm.WinUI.Forme
{
    partial class frmDodajDrzavu
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
            this.tbDrzava = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDrzava
            // 
            this.tbDrzava.Location = new System.Drawing.Point(12, 54);
            this.tbDrzava.Name = "tbDrzava";
            this.tbDrzava.Size = new System.Drawing.Size(182, 23);
            this.tbDrzava.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv države:";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(262, 54);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(120, 23);
            this.btnSpremi.TabIndex = 2;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmDodajDrzavu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 96);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDrzava);
            this.Name = "frmDodajDrzavu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDodajDrzavu";
            this.Load += new System.EventHandler(this.frmDodajDrzavu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbDrzava;
        private Label label1;
        private Button btnSpremi;
        private ErrorProvider err;
    }
}