using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RESTUtil;

namespace WycheP3
{
    public partial class FootForm : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Footer footer;

        public FootForm()
        {
            InitializeComponent();
        }

        private void FootForm_Load(object sender, EventArgs e)
        {
            string jsonFooter = rj.getRESTDataJSON("/footer/");
            footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            copyright_lbl.Text = footer.copyright.title + ":";
            html_lbl.Text = footer.copyright.html;
            linkLabel1.Text = footer.news;
            quicktitle1.Text = footer.quickLinks[0].title;
            linkLabel2.Text = footer.quickLinks[0].href;
            quicktitle2.Text = footer.quickLinks[1].title;
            linkLabel3.Text = footer.quickLinks[1].href;
            quicktitle3.Text = footer.quickLinks[2].title;
            linkLabel4.Text = footer.quickLinks[2].href;
            quicktitle4.Text = footer.quickLinks[3].title;
            linkLabel5.Text = footer.quickLinks[3].href;
        }
    }
}
