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
    public partial class StudentServ : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Resources resources;

        public StudentServ()
        {
            InitializeComponent();
        }

        private void StudentServ_Load(object sender, EventArgs e)
        {
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }

        private void tp_acad_Enter(object sender, EventArgs e)
        {
            label1.Text = resources.studentServices.academicAdvisors.title;

            label17.Text = resources.studentServices.academicAdvisors.description;

            label2.Text = resources.studentServices.academicAdvisors.faq.title;

            linkLabel1.Text = resources.studentServices.academicAdvisors.faq.contentHref;
        }

        private void tp_prof_Enter(object sender, EventArgs e)
        {
            label3.Text = resources.studentServices.professonalAdvisors.advisorInformation[0].name;
            label5.Text = resources.studentServices.professonalAdvisors.advisorInformation[0].department;
            label6.Text = resources.studentServices.professonalAdvisors.advisorInformation[0].email;

            label7.Text = resources.studentServices.professonalAdvisors.advisorInformation[1].name;
            label8.Text = resources.studentServices.professonalAdvisors.advisorInformation[1].department;
            label9.Text = resources.studentServices.professonalAdvisors.advisorInformation[1].email;

            label10.Text = resources.studentServices.professonalAdvisors.advisorInformation[2].name;
            label11.Text = resources.studentServices.professonalAdvisors.advisorInformation[2].department;
            label12.Text = resources.studentServices.professonalAdvisors.advisorInformation[2].email;
        }

        private void tp_fac_Enter(object sender, EventArgs e)
        {
            label23.Text = resources.studentServices.facultyAdvisors.title;

            label13.Text = resources.studentServices.facultyAdvisors.description;
        }

        private void tp_ist_Enter(object sender, EventArgs e)
        {
            label20.Text = resources.studentServices.istMinorAdvising.title;

            foreach (MinorAdvisorInformation m in resources.studentServices.istMinorAdvising.minorAdvisorInformation)
            {
                comboBox1.Items.Add(m.title);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MinorAdvisorInformation mai = resources.studentServices.istMinorAdvising.minorAdvisorInformation.Find(x => x.title == comboBox1.SelectedItem.ToString());

            label19.Text = mai.title;
            label18.Text = mai.advisor;
            label16.Text = mai.email;

        }
    }
}
