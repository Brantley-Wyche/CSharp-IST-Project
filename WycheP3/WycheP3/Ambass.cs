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
    public partial class Ambass : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Resources resources;

        public Ambass()
        {
            InitializeComponent();
        }

        private void Ambass_Load(object sender, EventArgs e)
        {
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();

            foreach (SubSectionContent ssc in resources.studentAmbassadors.subSectionContent)
            {
                comboBox1.Items.Add(ssc.title);
            }
        }

        private void tp_apply_Enter(object sender, EventArgs e)
        {
            label1.Text = resources.studentAmbassadors.note;
            linkLabel1.Text = resources.studentAmbassadors.applicationFormLink;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubSectionContent ssc = resources.studentAmbassadors.subSectionContent.Find(x => x.title == comboBox1.SelectedItem.ToString());

            label18.Text = ssc.title;
            label16.Text = ssc.description;
        }
    }
}
