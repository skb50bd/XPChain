namespace CryptoApp
{
    partial class GenerateSignature
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
            this.genKeys = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.RichTextBox();
            this.privateKeyText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.signatureText = new System.Windows.Forms.RichTextBox();
            // 
            // genKeys
            // 
            this.genKeys.Location = new System.Drawing.Point(408, 382);
            this.genKeys.Name = "genKeys";
            this.genKeys.Size = new System.Drawing.Size(183, 49);
            this.genKeys.TabIndex = 0;
            this.genKeys.Text = "Generate Signature";
            this.genKeys.UseVisualStyleBackColor = true;
            this.genKeys.Click += new System.EventHandler(this.genKeys_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(597, 382);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(183, 49);
            this.Back.TabIndex = 0;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(21, 35);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(759, 86);
            this.message.TabIndex = 1;
            this.message.Text = "";
            // 
            // privateKeyText
            // 
            this.privateKeyText.Location = new System.Drawing.Point(21, 142);
            this.privateKeyText.Name = "privateKeyText";
            this.privateKeyText.Size = new System.Drawing.Size(759, 86);
            this.privateKeyText.TabIndex = 1;
            this.privateKeyText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Private Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Signature";
            // 
            // signatureText
            // 
            this.signatureText.Location = new System.Drawing.Point(21, 263);
            this.signatureText.Name = "signatureText";
            this.signatureText.Size = new System.Drawing.Size(759, 86);
            this.signatureText.TabIndex = 1;
            this.signatureText.Text = "";
            // 
            // GenerateSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.genKeys);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.privateKeyText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.signatureText);
            this.Name = "GenerateSignature";
            this.Text = "GenerateSignature";

        }

        #endregion

        private System.Windows.Forms.Button genKeys;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.RichTextBox privateKeyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox signatureText;
    }
}