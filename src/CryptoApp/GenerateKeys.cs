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
    public partial class GenerateKeys : Form
    {
        public GenerateKeys(Home home)
        {
            InitializeComponent();
            this.Owner = home;
            this.ControlBox = false;

        }

        private void genSig_Click(object sender, EventArgs e)
        {
            var keyPair = KeyPair.NewKeyPair();
            privateKey.Text = keyPair.PrivateKey;
            publicKey.Text = keyPair.PublicKey;

            File.WriteAllLines("Keys.txt",
                                new[] {
                                    "Public Key: ",
                                    keyPair.PublicKey,
                                    "\nPrivate Key: ",
                                    keyPair.PrivateKey
                                });
            MessageBox.Show("Keys.txt Saved");

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
