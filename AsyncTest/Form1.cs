using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTest
{
    public partial class Form1 : Form
    {
        private const string URL = "https://www.google.com";
        public Form1()
        {
            InitializeComponent();
            rchTextBox.Text += String.Format("Current thread: {0} \n", Thread.CurrentThread.ManagedThreadId);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            rchTextBox.Text += String.Format("Current thread 1S: {0} \n", Thread.CurrentThread.ManagedThreadId);
            GetHtml();
            rchTextBox.Text += String.Format("Current thread 4S: {0} \n", Thread.CurrentThread.ManagedThreadId);
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            rchTextBox.Text += String.Format("Current thread 1A: {0} \n", Thread.CurrentThread.ManagedThreadId);
            GetHtmlAsync();
            rchTextBox.Text += String.Format("Current thread 4A: {0} \n", Thread.CurrentThread.ManagedThreadId);
        }

        async Task GetHtmlAsync()
        {
            using (var client = new HttpClient())
            {
                rchTextBox.Text += String.Format("Current thread 2A: {0} \n", Thread.CurrentThread.ManagedThreadId);
                rchTextBox.Text += "\n" + (await client.GetStringAsync(URL)) + "\n";
                rchTextBox.Text += String.Format("Current thread 3A: {0} \n", Thread.CurrentThread.ManagedThreadId);
            }
        }

        void GetHtml()
        {
            using (var client = new WebClient())
            {
                rchTextBox.Text += String.Format("Current thread 2S: {0} \n", Thread.CurrentThread.ManagedThreadId);
                rchTextBox.Text += "\n" + client.DownloadString(URL) + "\n";
                rchTextBox.Text += String.Format("Current thread 3S: {0} \n", Thread.CurrentThread.ManagedThreadId);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rchTextBox.Text = String.Empty;
        }
    }
}
