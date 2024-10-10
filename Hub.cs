using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_TriviaBlitz_22SD_Dman
{
    public partial class Hub : Form
    {
        public Hub()
        {
            InitializeComponent();
        }

        private void Hub_Load(object sender, EventArgs e)
        {
            tbcHubDman.Appearance = TabAppearance.FlatButtons;
            tbcHubDman.SizeMode = TabSizeMode.Fixed;
            tbcHubDman.ItemSize = new Size(0, 1);
        }

        private void btnExitDman_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStartGameDman_Click(object sender, EventArgs e)
        {
            tbcHubDman.SelectedTab = tbpTriviaDman;
        }
    }
}
