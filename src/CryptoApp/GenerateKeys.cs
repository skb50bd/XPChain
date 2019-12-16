using Crypto;

using System;
using System.IO;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class GenerateKeys : Form
    {
        public GenerateKeys(Form home)
        {
            InitializeComponent();
            Owner      = home;
            ControlBox = false;

        }

        private void GenSig_Click(object sender, EventArgs e)
        {
            var keyPair     = KeyPair.NewKeyPair();
            privateKey.Text = keyPair.PrivateKey;
            publicKey.Text  = keyPair.PublicKey;

            File.WriteAllLines("Keys.txt",
                                new[] {
                                    "Public Key: ",
                                    keyPair.PublicKey,
                                    "\nPrivate Key: ",
                                    keyPair.PrivateKey
                                });
            MessageBox.Show("Keys.txt Saved");

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }
    }
}
