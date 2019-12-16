namespace CryptoApp
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
            this.VerifySig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            // 
            // genKey
            // 
            this.genKey.Location = new System.Drawing.Point(58, 112);
            this.genKey.Name = "genKey";
            this.genKey.Size = new System.Drawing.Size(242, 55);
            this.genKey.TabIndex = 0;
            this.genKey.Text = "Generate Public-Private Key Pair";
            this.genKey.UseVisualStyleBackColor = true;
            this.genKey.Click += new System.EventHandler(this.GenKey_Click);
            // 
            // genSig
            // 
            this.genSig.Location = new System.Drawing.Point(58, 173);
            this.genSig.Name = "genSig";
            this.genSig.Size = new System.Drawing.Size(242, 55);
            this.genSig.TabIndex = 0;
            this.genSig.Text = "Generate Signature";
            this.genSig.UseVisualStyleBackColor = true;
            this.genSig.Click += new System.EventHandler(this.GenSig_Click);
            // 
            // VerifySig
            // 
            this.VerifySig.Location = new System.Drawing.Point(58, 234);
            this.VerifySig.Name = "VerifySig";
            this.VerifySig.Size = new System.Drawing.Size(242, 55);
            this.VerifySig.TabIndex = 0;
            this.VerifySig.Text = "Verify Signature";
            this.VerifySig.UseVisualStyleBackColor = true;
            this.VerifySig.Click += new System.EventHandler(this.VerifySig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to XPChain Crypto Tool";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genKey);
            this.Controls.Add(this.genSig);
            this.Controls.Add(this.VerifySig);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";

        }

        #endregion

        private System.Windows.Forms.Button genKey;
        private System.Windows.Forms.Button genSig;
        private System.Windows.Forms.Button VerifySig;
        private System.Windows.Forms.Label label1;
    }
}