using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarnsleyFern
{
    public partial class StatusForm : Form
    {
        public StatusForm(string header, string summary, bool isPlaying)
        {
            InitializeComponent();

            this.Text = header;

            SummaryLabel.Text = summary;

            if (isPlaying == true)
            {
                ResumeButton.Hide();
            }
            else
            {
                RefreshButton.Hide();
            }

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
