using MangaDownloader.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaDownloader.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(urlTextBox.Text))
            {
                MessageBox.Show("The url field cannot be left empty.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (toUpDown.Value < fromUpDown.Value && toUpDown.Value != 0)
            {
                MessageBox.Show("Invalid range of chapters to download.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            logTextBox.Clear();

            string url = urlTextBox.Text;
            int from = (int)fromUpDown.Value;
            int to = (int)toUpDown.Value;

            Thread t = new Thread(() =>
            {
                disableControls(true);

                Manga m = new Manga(url, from, to);
                m.LogUpdate += log;
                m.download();

                disableControls(false);

                this.Invoke(new MethodInvoker(() =>
                {
                    MessageBox.Show("Download has completed!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            });

            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }

        private void disableControls(bool b)
        {
            urlTextBox.safeInvoke(() => { urlTextBox.ReadOnly = b; });
            fromUpDown.safeInvoke(() => { fromUpDown.Enabled = !b; });
            toUpDown.safeInvoke(() => { toUpDown.Enabled = !b; });
            downloadButton.safeInvoke(() => { downloadButton.Enabled = !b; });
        }

        private void log(string value)
        {
            logTextBox.safeInvoke(() =>
            {
                logTextBox.AppendText(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("hh:mm:ss tt"), value, Environment.NewLine));
            });
        }
    }
}
