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
    public partial class Tutors : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Resources resources;

        public Tutors()
        {
            InitializeComponent();
        }

        private void Tutors_Load(object sender, EventArgs e)
        {
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();

            tutor_lbl.Text = resources.tutorsAndLabInformation.title;
            label2.Text = resources.tutorsAndLabInformation.description;
            linkLabel1.Text = resources.tutorsAndLabInformation.tutoringLabHoursLink;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }
    }
}
