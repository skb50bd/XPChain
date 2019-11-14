namespace CryptoApp
{
    partial class VerifySignature
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
            this.label1 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.publicKey = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.signature = new System.Windows.Forms.RichTextBox();
            this.verifySig = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message";
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(18, 40);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(767, 96);
            this.message.TabIndex = 1;
            this.message.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Public Key";
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(18, 293);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(767, 96);
            this.publicKey.TabIndex = 1;
            this.publicKey.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Signature";
            // 
            // signature
            // 
            this.signature.Location = new System.Drawing.Point(18, 169);
            this.signature.Name = "signature";
            this.signature.Size = new System.Drawing.Size(767, 96);
            this.signature.TabIndex = 1;
            this.signature.Text = "";
            // 
            // verifySig
            // 
            this.verifySig.Location = new System.Drawing.Point(357, 412);
            this.verifySig.Name = "verifySig";
            this.verifySig.Size = new System.Drawing.Size(211, 57);
            this.verifySig.TabIndex = 2;
            this.verifySig.Text = "Verify Signature";
            this.verifySig.UseVisualStyleBackColor = true;
            this.verifySig.Click += new System.EventHandler(this.verifySig_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(574, 412);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(211, 57);
            this.back.TabIndex = 2;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // VerifySignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 481);
            this.Controls.Add(this.verifySig);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.signature);
            this.Controls.Add(this.back);
            this.Name = "VerifySignature";
            this.Text = "VerifySignature";

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox publicKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox signature;
        private System.Windows.Forms.Button verifySig;
        private System.Windows.Forms.Button back;
    }
}