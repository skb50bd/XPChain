using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crypto;
using System.IO;

namespace CryptoApp
{
    public partial class GenerateSignature : Form
    {
        public GenerateSignature(Home home)
        {
            InitializeComponent();
            this.Owner = home;
            this.ControlBox = false;

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void genKeys_Click(object sender, EventArgs e)
        {
            var data = message.Text;
            var privateKey = privateKeyText.Text;

            var sign = SignatureProvider.GetSignature(data, privateKey);

            signatureText.Text = sign.ToString();
        }
    }
}
