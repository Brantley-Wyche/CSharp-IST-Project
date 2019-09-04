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
    public partial class CoopEnroll : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Resources resources;

        public CoopEnroll()
        {
            InitializeComponent();
        }

        private void CoopEnroll_Load(object sender, EventArgs e)
        {
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();

            label1.Text = resources.coopEnrollment.title;

            lbl2.Text = resources.coopEnrollment.enrollmentInformationContent[0].title;
            rtb1.Text = resources.coopEnrollment.enrollmentInformationContent[0].description;

            lbl3.Text = resources.coopEnrollment.enrollmentInformationContent[1].title;
            rtb2.Text = resources.coopEnrollment.enrollmentInformationContent[1].description;

            lbl4.Text = resources.coopEnrollment.enrollmentInformationContent[2].title;
            rtb3.Text = resources.coopEnrollment.enrollmentInformationContent[2].description;

            lbl5.Text = resources.coopEnrollment.enrollmentInformationContent[3].title;
            rtb4.Text = resources.coopEnrollment.enrollmentInformationContent[3].description;

            //populate the link label with RITJobZoneLink!
            linkLabel1.Text = resources.coopEnrollment.RITJobZoneGuidelink;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go and load the pdf
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }
    }
}
