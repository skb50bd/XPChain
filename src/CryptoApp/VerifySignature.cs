using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crypto;

namespace CryptoApp
{
    public partial class VerifySignature : Form
    {
        public VerifySignature(Home home)
        {
            InitializeComponent();
            this.Owner = home;
            this.ControlBox = false;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void verifySig_Click(object sender, EventArgs e)
        {
            var data = message.Text;
            var sig = signature.Text;
            var pubKey = publicKey.Text;

            var isValid = SignatureProvider.Verify(data, sig, pubKey);
            if (isValid)
            {
                MessageBox.Show("This is a valid signature");
            }
            else
                MessageBox.Show("This is an invalid signature");
        }
    }
}
