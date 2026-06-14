using FishIt.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_DashboardPembeli : UserControl
    {
        public UC_DashboardPembeli()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Session.Username))
            {
                lblUsername.Text = Session.Username;
            }
            else
            {
                lblUsername.Text = "Guest";
            }
            new AutoScaleHelper(this);
        }

        private void UC_DashboardPembeli_Load(object sender, EventArgs e)
        {

        }
    }
}
