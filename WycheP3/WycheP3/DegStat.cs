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
    public partial class DegStat : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Employment employment;

        public DegStat()
        {
            InitializeComponent();
        }

        private void DegStat_Load(object sender, EventArgs e)
        {

            if (employment == null)
            {
                //go get /employment/ and cast to the Employment object
                string jsonEmp = rj.getRESTDataJSON("/employment/");
                employment = JToken.Parse(jsonEmp).ToObject<Employment>();
            }

            

            //Title
            deg_title.Text = employment.degreeStatistics.title;

            /*for (int i = 0; i < employment.degreeStatistics.statistics.Count; i++)
            {

                StringBuilder statBuild = new StringBuilder();
                statBuild.Append(employment.degreeStatistics.statistics[0].value);
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[0].description);
                statBuild.AppendLine();
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[1].value);
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[1].description);
                statBuild.AppendLine();
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[2].value);
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[2].description);
                statBuild.AppendLine();
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[3].value);
                statBuild.AppendLine();
                statBuild.Append(employment.degreeStatistics.statistics[3].description);
                textBox1.Text = statBuild.ToString();
            }*/

            //Getting the degree statistics
            value1.Text = employment.degreeStatistics.statistics[0].value;
            desc1.Text = employment.degreeStatistics.statistics[0].description;
            value2.Text = employment.degreeStatistics.statistics[1].value;
            desc2.Text = employment.degreeStatistics.statistics[1].description;
            value3.Text = employment.degreeStatistics.statistics[2].value +"%";
            desc3.Text = employment.degreeStatistics.statistics[2].description;
            value4.Text = employment.degreeStatistics.statistics[3].value;
            desc4.Text = employment.degreeStatistics.statistics[3].description;
        }
    }
}
