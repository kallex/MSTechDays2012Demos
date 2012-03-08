using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationTracker
{
    public partial class EnterPINForm : Form
    {
        public EnterPINForm()
        {
            InitializeComponent();
        }

        public string PINNumber;

        private void bSavePIN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            PINNumber = tTwitterPIN.Text;
            Close();
        }
    }
}
