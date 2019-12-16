using Crypto;

using System;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class GenerateSignature : Form
    {
        public GenerateSignature(Form home)
        {
            InitializeComponent();
            Owner = home;
            ControlBox = false;

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void GenKeys_Click(object sender, EventArgs e)
        {
            var data = message.Text;
            var privateKey = privateKeyText.Text;

            var sign = SignatureProvider.GetSignature(data, privateKey);

            signatureText.Text = sign;
        }
    }
}
