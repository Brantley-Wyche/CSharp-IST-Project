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
    public partial class Formies : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Resources resources;

        public Formies()
        {
            InitializeComponent();
        }

        private void Formies_Load(object sender, EventArgs e)
        {
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();

            //The links don't work so there's no point in making them into link labels
            var sb = new StringBuilder();
            foreach (GraduateForm fo in resources.forms.graduateForms)
            {
                sb.Append(fo.formName);
                sb.AppendLine();
                sb.Append("http://ist.rit.edu/api/"+fo.href);
                sb.AppendLine();
                sb.AppendLine();                
            }
            label2.Text = sb.ToString();
            label3.Text = resources.forms.undergraduateForms[0].formName;
            label4.Text = "http://ist.rit.edu/api/" + resources.forms.undergraduateForms[0].href;
        }
    }
}
