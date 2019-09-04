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
    public partial class EmpCar : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Employment employment;

        public EmpCar()
        {
            InitializeComponent();
        }

        private void EmpCar_Load(object sender, EventArgs e)
        {
            if (employment == null)
            {
                //go get /employment/ and cast to the Employment object
                string jsonEmp = rj.getRESTDataJSON("/employment/");
                employment = JToken.Parse(jsonEmp).ToObject<Employment>();
            }

            #region Employer and Career names

            //Print out all of the employer names and career names
            title.Text = employment.employers.title;

            var builder1 = new StringBuilder();
            foreach (string eName in employment.employers.employerNames)
            {
                builder1.Append(eName);
                builder1.AppendLine();
            }
            emp_names.Text = builder1.ToString();

            title2.Text = employment.careers.title;

            var builder2 = new StringBuilder();
            foreach (string cName in employment.careers.careerNames)
            {
                builder2.Append(cName);
                builder2.AppendLine();
            }
            car.Text = builder2.ToString();

            #endregion Employer and Career Names
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
