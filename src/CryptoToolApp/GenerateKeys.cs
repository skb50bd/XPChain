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
    public partial class GenerateKeys : Form
    {
        public GenerateKeys(Home home)
        {
            InitializeComponent();
            this.Owner = home;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
