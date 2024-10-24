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
    public partial class Controller : Form
    {
        public Controller()
        {
            InitializeComponent();
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            tbcNavigationDman.Appearance = TabAppearance.FlatButtons;
            tbcNavigationDman.SizeMode = TabSizeMode.Fixed;
            tbcNavigationDman.ItemSize = new Size(0, 1);

            rbtHomeDman.Checked = true;
        }

        private void HandleNavigation(object sender, EventArgs e)
        {
            if (sender == rbtHomeDman)
            {
                tbcNavigationDman.SelectedTab = tbpHomeDman;
            }
            else if (sender == rbtRankingDman)
            {
                tbcNavigationDman.SelectedTab = tbpRankingDman;
            }
        }

        private void btnExitDman_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuitDman_Click(object sender, EventArgs e)
        {
            tbcNavigationDman.SelectedTab = tbpHomeDman;
        }

        private void btnStartGameDman_Click(object sender, EventArgs e)
        {
            rbtHomeDman.Enabled = false;
            rbtRankingDman.Enabled = false;

            tbcNavigationDman.SelectedTab = tbpQuizDman;

            FillQuizData();
        }

        public void FillQuizData()
        {

        }
    }
}
