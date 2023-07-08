using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace HiTechBrowser
{
    public partial class Form1 : Form
    {
        // The link to load in the browser
        private string link;

        // The browser control
        private CefSharp.WinForms.ChromiumWebBrowser browser;

        public Form1(string link)
        {
            InitializeComponent();

            // Save the link
            this.link = link;

            // Create the browser control
            browser = new CefSharp.WinForms.ChromiumWebBrowser(link);

            // Add the browser control to the form
            this.Controls.Add(browser);

            // Set the browser control to fill the form
            browser.Dock = DockStyle.Fill;

            // Send the browser control to the back, so the buttons are visible
            browser.SendToBack();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // Go back in the browser history
            browser.Back();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            // Go forward in the browser history
            browser.Forward();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            // Reload the current page
            browser.Reload();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }
    }
}
