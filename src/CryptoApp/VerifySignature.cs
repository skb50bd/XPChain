using Crypto;

using System;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class VerifySignature : Form
    {
        public VerifySignature(Form home)
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

        private void VerifySig_Click(object sender, EventArgs e)
        {
            var data = message.Text;
            var sig = signature.Text;
            var pubKey = publicKey.Text;

            var isValid = SignatureProvider.Verify(data, sig, pubKey);
            MessageBox.Show(isValid
                ? "This is a valid signature"
                : "This is an invalid signature");
        }
    }
}
