using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void genKey_Click(object sender, EventArgs e)
        {
            GenerateKeys gs = new GenerateKeys(this);
            gs.Show();
            this.Hide();
        }

        private void genSig_Click(object sender, EventArgs e)
        {
            GenerateSignature gs = new GenerateSignature(this);
            gs.Show();
            this.Hide();
        }

        private void VerifySig_Click(object sender, EventArgs e)
        {
            VerifySignature vs = new VerifySignature(this);
            vs.Show();
            this.Hide();
        }
    }
}
