using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoToolApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void genKey_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerateKeys gk = new GenerateKeys(this);
            gk.Show();
        }

        private void genSig_Click(object sender, EventArgs e)
        {
            GenerateSignature gs = new GenerateSignature();
            gs.Show();
            this.Close();
        }

        private void verifySig_Click(object sender, EventArgs e)
        {
            VerifySignature vs = new VerifySignature();
            vs.Show();
            this.Close();
        }
    }
}
