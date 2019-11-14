namespace CryptoToolApp
{
    partial class GenerateKeys
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
            this.genkeys = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // genkeys
            // 
            this.genkeys.Location = new System.Drawing.Point(385, 370);
            this.genkeys.Name = "genkeys";
            this.genkeys.Size = new System.Drawing.Size(195, 51);
            this.genkeys.TabIndex = 0;
            this.genkeys.Text = "Generate Keys";
            this.genkeys.UseVisualStyleBackColor = true;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(593, 370);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(195, 51);
            this.back.TabIndex = 1;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // GenerateKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.genkeys);
            this.Name = "GenerateKeys";
            this.Text = "GenerateKeys";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button genkeys;
        private System.Windows.Forms.Button back;
    }
}