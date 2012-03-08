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
    public partial class EnterSubjectForm : Form
    {
        public EnterSubjectForm()
        {
            InitializeComponent();
        }

        public string PresentationSubject;

        public void SetPresentationSubjectText(string subject)
        {
            tPresentationSubject.Text = subject;
        }

        private void bSaveSubject_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            PresentationSubject = tPresentationSubject.Text;
        }
    }
}
