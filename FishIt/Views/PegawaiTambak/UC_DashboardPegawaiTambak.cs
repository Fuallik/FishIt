using FishIt.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_DashboardPegawaiTambak : UserControl
    {
        public UC_DashboardPegawaiTambak()
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
    }
}
