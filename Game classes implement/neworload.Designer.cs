namespace Game_classes_implement
{
    partial class neworload
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
            this.btnnew = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(65, 26);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(140, 38);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(65, 94);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(140, 36);
            this.btnload.TabIndex = 1;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // neworload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.btnnew);
            this.Name = "neworload";
            this.Text = "neworload";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnload;
    }
}