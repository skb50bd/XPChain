using System;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void GenKey_Click(object sender, EventArgs e)
        {
            var gs = new GenerateKeys(this);
            gs.Show();
            Hide();
        }

        private void GenSig_Click(object sender, EventArgs e)
        {
            var gs = new GenerateSignature(this);
            gs.Show();
            Hide();
        }

        private void VerifySig_Click(object sender, EventArgs e)
        {
            var vs = new VerifySignature(this);
            vs.Show();
            Hide();
        }
    }
}
