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
    public partial class StudyForm : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Resources resources;

        public StudyForm()
        {
            InitializeComponent();
        }

        private void StudyForm_Load(object sender, EventArgs e)
        {
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();

            label1.Text = resources.studyAbroad.title;
            label17.Text = resources.studyAbroad.description;

            label2.Text = resources.studyAbroad.places[0].nameOfPlace;
            label4.Text = resources.studyAbroad.places[0].description;

            label3.Text = resources.studyAbroad.places[1].nameOfPlace;
            label5.Text = resources.studyAbroad.places[1].description;
        }
    }
}
