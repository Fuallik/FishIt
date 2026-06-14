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
    public partial class UC_DashboardAdmin : UserControl
    {
        public UC_DashboardAdmin()
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

        private void UC_DashboardAdmin_Load(object sender, EventArgs e)
        {

        }

        private void lblKasirKelola_Click(object sender, EventArgs e)
        {

        }
    }
}
