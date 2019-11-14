namespace CryptoToolApp
{
    partial class Home
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
            this.genKey = new System.Windows.Forms.Button();
            this.genSig = new System.Windows.Forms.Button();
            this.verifySig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // genKey
            // 
            this.genKey.Location = new System.Drawing.Point(70, 214);
            this.genKey.Name = "genKey";
            this.genKey.Size = new System.Drawing.Size(251, 49);
            this.genKey.TabIndex = 0;
            this.genKey.Text = "Generate Public-Private Key Pair";
            this.genKey.UseVisualStyleBackColor = true;
            this.genKey.Click += new System.EventHandler(this.genKey_Click);
            // 
            // genSig
            // 
            this.genSig.Location = new System.Drawing.Point(70, 293);
            this.genSig.Name = "genSig";
            this.genSig.Size = new System.Drawing.Size(251, 49);
            this.genSig.TabIndex = 1;
            this.genSig.Text = "Generate Signature";
            this.genSig.UseVisualStyleBackColor = true;
            this.genSig.Click += new System.EventHandler(this.genSig_Click);
            // 
            // verifySig
            // 
            this.verifySig.Location = new System.Drawing.Point(70, 368);
            this.verifySig.Name = "verifySig";
            this.verifySig.Size = new System.Drawing.Size(251, 49);
            this.verifySig.TabIndex = 2;
            this.verifySig.Text = "Verify Signature";
            this.verifySig.UseVisualStyleBackColor = true;
            this.verifySig.Click += new System.EventHandler(this.verifySig_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 450);
            this.Controls.Add(this.verifySig);
            this.Controls.Add(this.genSig);
            this.Controls.Add(this.genKey);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button genKey;
        private System.Windows.Forms.Button genSig;
        private System.Windows.Forms.Button verifySig;
    }
}