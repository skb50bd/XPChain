namespace CryptoApp
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
            this.genSig = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.privateKey = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.publicKey = new System.Windows.Forms.RichTextBox();
            // 
            // genSig
            // 
            this.genSig.Location = new System.Drawing.Point(385, 373);
            this.genSig.Name = "genSig";
            this.genSig.Size = new System.Drawing.Size(199, 58);
            this.genSig.TabIndex = 0;
            this.genSig.Text = "Generate Keys";
            this.genSig.UseVisualStyleBackColor = true;
            this.genSig.Click += new System.EventHandler(this.genSig_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(590, 373);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(199, 58);
            this.back.TabIndex = 0;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Private Key";
            // 
            // privateKey
            // 
            this.privateKey.Location = new System.Drawing.Point(33, 56);
            this.privateKey.Name = "privateKey";
            this.privateKey.Size = new System.Drawing.Size(719, 96);
            this.privateKey.TabIndex = 2;
            this.privateKey.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Public Key";
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(33, 199);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(719, 96);
            this.publicKey.TabIndex = 2;
            this.publicKey.Text = "";
            // 
            // GenerateKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.privateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genSig);
            this.Controls.Add(this.back);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.publicKey);
            this.Name = "GenerateKeys";
            this.Text = "GenerateKeys";

        }

        #endregion

        private System.Windows.Forms.Button genSig;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox privateKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox publicKey;
    }
}