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
    public partial class EmpTables : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Employment employment;

        public EmpTables()
        {
            InitializeComponent();
        }

        private void EmpTables_Load(object sender, EventArgs e)
        {
            //if i haven't loaded employment yet - get employment
            if (employment == null)
            {
                //go get /employment/ and cast to the Employment object
                string jsonEmp = rj.getRESTDataJSON("/employment/");
                employment = JToken.Parse(jsonEmp).ToObject<Employment>();
            }

            var sb = new StringBuilder();
            foreach (string eName in employment.employers.employerNames)
            {
                sb.Append(eName);
                sb.AppendLine();
            }

            //add the title
            coop_title.Text = employment.coopTable.title;

            //create the data grid view contents!
            for (int i = 0; i < employment.coopTable.coopInformation.Count; i++)
            {
                //build a row, add it
                dg_coopTable.Rows.Add();
                //add things to the row
                dg_coopTable.Rows[i].Cells[0].Value = employment.coopTable.coopInformation[i].employer;
                dg_coopTable.Rows[i].Cells[1].Value = employment.coopTable.coopInformation[i].degree;
                dg_coopTable.Rows[i].Cells[2].Value = employment.coopTable.coopInformation[i].city;
                dg_coopTable.Rows[i].Cells[3].Value = employment.coopTable.coopInformation[i].term;
            }

            //add the title
            emp_title.Text = employment.employmentTable.title;

            for (int i = 0; i < employment.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                //build a row, add it
                dg_empTable.Rows.Add();
                //add things to the row
                dg_empTable.Rows[i].Cells[0].Value = employment.employmentTable.professionalEmploymentInformation[i].employer;
                dg_empTable.Rows[i].Cells[1].Value = employment.employmentTable.professionalEmploymentInformation[i].degree;
                dg_empTable.Rows[i].Cells[2].Value = employment.employmentTable.professionalEmploymentInformation[i].city;
                dg_empTable.Rows[i].Cells[3].Value = employment.employmentTable.professionalEmploymentInformation[i].title;
                dg_empTable.Rows[i].Cells[4].Value = employment.employmentTable.professionalEmploymentInformation[i].startDate;
            }
        }
    }
}
