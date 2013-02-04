using SenzalaYogyakartaAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SenzalaYogyakartaManajemenSiswa
{
    public partial class LaunchBar : Form
    {
        public LaunchBar()
        {
            InitializeComponent();
        }

        private void btnManajemenSiswa_Click(object sender, EventArgs e)
        {
            ManagementSiswa managementSiswa = new ManagementSiswa();
            MainLibrary.getInstance().displayModule(managementSiswa);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
