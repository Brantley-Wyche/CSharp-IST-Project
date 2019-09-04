using Newtonsoft.Json.Linq;
using RESTUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
//DISCLAIMER: 
//
// When I created this project, I did it on my 17inch laptop
// When I tested it on the lab computers, some text became 
// bigger for some reason and I didn't have enough time to change it.  
// Look at this on both a bigger and smaller screen. This was 
// not an oversight, I didn't know that this would happen.
// Please don't take a lot of points off for that.  It looked 
// fine on my laptop

namespace WycheP3
{
    public partial class Form1 : Form
    {
        //instantiate my rest classes
        REST rj = new REST("http://ist.rit.edu/api");
        REST googleRj = new REST("http://www.google.com/api");

        //instantiate my data objects        
        About about;
        Degrees degrees;
        Minors minors;
        Employment employment;
        People people;
        Research research;
        Resources resources;
        News news;
        Footer footer;

        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //go get /about/ and cast to the About object
            string jsonAbout = rj.getRESTDataJSON("/about/");
            about = JToken.Parse(jsonAbout).ToObject<About>();

            //access the information in the About node
            label19.Text = about.quote;
            label18.Text = about.description;
            lbl_title.Text = about.title;
            lbl_author.Text = "- "+about.quoteAuthor;

            //go get /footer/ and cast to the Footer object
            string jsonFooter = rj.getRESTDataJSON("/footer/");
            footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            //Setting the social footer stuff in the bottom left corner panel
            tweet_lbl.Text = footer.social.tweet;
            by_lbl.Text = footer.social.by;
            linkLabel1.Text = footer.social.twitter;
            linkLabel2.Text = footer.social.facebook;       
            
            //THE REST OF THE FOOTER STUFF IS IN A SEPARATE FORM, CHECK THE FOOTER REGION BELOW
        }

        #region About
        private void btn_about_Click(object sender, EventArgs e)
        {
            //Go to the About page
            tabControl1.SelectedIndex = 0;
        }

        #endregion About

        #region Degrees

        private void btn_degrees_Click(object sender, EventArgs e)
        {
            //Go to the Degrees page
            tabControl1.SelectedIndex = 3;
        }

        private void tp_degrees_Enter(object sender, EventArgs e)
        {
            //go get /degrees/ and cast to the Degrees object
            string jsonDegrees = rj.getRESTDataJSON("/degrees/");
            degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();
        }

        //Undergraduate degree combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //If the selected value is wmc, the WMC information will print out
            if (comboBox1.SelectedItem.ToString() == "wmc")
            {
                ug_title.Text = degrees.undergraduate[0].title;
                label13.Text = degrees.undergraduate[0].description;

                var sb = new StringBuilder();
                foreach (string eName in degrees.undergraduate[0].concentrations)
                {
                    sb.Append(eName);
                    sb.AppendLine();
                }
                label14.Text = sb.ToString();

            }

            //If the selected value is hcc, the HCC information will print out
            if (comboBox1.SelectedItem.ToString() == "hcc")
            {
                ug_title.Text = degrees.undergraduate[1].title;
                label13.Text = degrees.undergraduate[1].description;

                var sb = new StringBuilder();
                foreach (string eName in degrees.undergraduate[1].concentrations)
                {
                    sb.Append(eName);
                    sb.AppendLine();
                }
                label14.Text = sb.ToString();
            }

            //If the selected value is cit, the CIT information will print out
            if (comboBox1.SelectedItem.ToString() == "cit")
            {
                ug_title.Text = degrees.undergraduate[2].title;
                label13.Text = degrees.undergraduate[2].description;

                var sb = new StringBuilder();
                foreach (string eName in degrees.undergraduate[2].concentrations)
                {
                    sb.Append(eName);
                    sb.AppendLine();
                }
                label14.Text = sb.ToString();
            }
        }
        
        //Graduate degree combobox
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the selected value is ist, the IST information will print out
            if (comboBox2.SelectedItem.ToString() == "ist")
            {
                g_title.Text = degrees.graduate[0].title;
                label15.Text = degrees.graduate[0].description;

                var sb = new StringBuilder();
                foreach (string eName in degrees.graduate[0].concentrations)
                {
                    sb.Append(eName);
                    sb.AppendLine();
                }
                conc_grad.Text = sb.ToString();

            }

            //If the selected value is hci, the HCI information will print out
            if (comboBox2.SelectedItem.ToString() == "hci")
            {
                g_title.Text = degrees.graduate[1].title;
                label15.Text = degrees.graduate[1].description;

                var sb = new StringBuilder();
                foreach (string eName in degrees.graduate[1].concentrations)
                {
                    sb.Append(eName);
                    sb.AppendLine();
                }
                conc_grad.Text = sb.ToString();
            }

            //If the selected value is nsa, the NSA information will print out
            if (comboBox2.SelectedItem.ToString() == "nsa")
            {
                g_title.Text = degrees.graduate[2].title;
                label15.Text = degrees.graduate[2].description;

                var sb = new StringBuilder();
                foreach (string eName in degrees.graduate[2].concentrations)
                {
                    sb.Append(eName);
                    sb.AppendLine();
                }
                conc_grad.Text = sb.ToString();
            }
        }

        #endregion Degrees

        #region Minors

        private void btn_minors_Click(object sender, EventArgs e)
        {
            //Go to the Minors page
            tabControl1.SelectedIndex = 7;
        }

        private void tp_minors_Enter(object sender, EventArgs e)
        {
            //go get /minors/ and cast to the Minors object
            string jsonMinors = rj.getRESTDataJSON("/minors/");
            minors = JToken.Parse(jsonMinors).ToObject<Minors>();

            //Add the UgMinor titles to the combobox
            foreach (UgMinor min in minors.UgMinors)
            {
                comboBox4.Items.Add(min.title);
            }
        }

        //Finds the relevant information that matches the chosen title in the combobox and prints it
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UgMinor ug = minors.UgMinors.Find(x => x.title == comboBox4.SelectedItem.ToString());

            var sb = new StringBuilder();
            foreach (string eName in ug.courses)
            {
                sb.Append(eName);
                sb.AppendLine();
            }
            courses_lbl.Text = sb.ToString();

            notes_lbl.Text = ug.note;
            label16.Text = ug.description;
        }

        #endregion Minors

        #region Employment

        private void btn_employment_Click(object sender, EventArgs e)
        {
            //Go to the Employment page
            tabControl1.SelectedIndex = 2;
        }

        private void deg_btn_Click(object sender, EventArgs e)
        {
            //Bring up the Degree Statistics Form
            DegStat degStat = new DegStat();
            degStat.ShowDialog();
        }

        private void emp_car_btn_Click(object sender, EventArgs e)
        {
            //Brings up the Employer and Career names form
            EmpCar empCar = new EmpCar();
            empCar.ShowDialog();
        }

        private void table_btn_Click(object sender, EventArgs e)
        {
            //Brings up the Employment Tables form
            EmpTables empTables = new EmpTables();
            empTables.ShowDialog();
        }

        private void tp_emp_Enter(object sender, EventArgs e)
        {
            //if i haven't loaded employment yet - get employment
            if (employment == null)
            {
                //go get /employment/ and cast to the Employment object
                string jsonEmp = rj.getRESTDataJSON("/employment/");
                employment = JToken.Parse(jsonEmp).ToObject<Employment>();
            }

            //Print out the introduction information
            emp_intro_title.Text = employment.introduction.title;
            title1.Text = employment.introduction.content[0].title;
            desc1.Text = employment.introduction.content[0].description;
            title2.Text = employment.introduction.content[1].title;
            desc2.Text = employment.introduction.content[1].description;
        }

        #endregion Employment

        #region People Stuff

        private void btn_people_Click(object sender, EventArgs e)
        {
            //Go to the People page
            tabControl1.SelectedIndex = 1;
        }

        //Get the picture of the selected faculty member
        private Faculty GetFacPicture(string person)
        {
            Faculty choice = people.faculty.Find(x => x.name == person);

            pictureBox1.Load(choice.imagePath);

            return choice;
        }

        //Get the picture of the selected staff member
        private Staff GetStaffPicture(string person)
        {
            Staff choice = people.staff.Find(x => x.name == person);

            pictureBox1.Load(choice.imagePath);

            return choice;
        }

        //Example from class
        private void getSingleInstance(string id)
        {
            //get one result that matches what you want
            Faculty result = people.faculty.Find(x => x.username == id);
            Console.WriteLine(result.office);

            //get multiple results that match what you want
            List<Faculty> res = people.faculty.FindAll(x => x.title == "Associate Professor");
            Console.WriteLine(res[2].name);
        }

        private void tp_people_Enter(object sender, EventArgs e)
        {
            //get the json for people
            string jsonPeople = rj.getRESTDataJSON("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();

            //Put the title in the label
            lbl_people_title.Text = people.title;

            //Put the subtitle in the label
            lbl_people_subtitle.Text = people.subTitle;

            //Add the faculty and staff names to the dropdown menus
            foreach (Faculty thisFac in people.faculty)
            {
                facCombo.Items.Add(thisFac.name);
            }

            foreach (Staff thisStaff in people.staff)
            {
                staffCombo.Items.Add(thisStaff.name);
            }
        }

        //Change the picture and labels based on who you choose
        private void facCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = facCombo.SelectedItem.ToString();
            GetFacPicture(s);

            Faculty inform = people.faculty.Find(x => x.name == s);

            
            label2.Text = inform.name;
            label3.Text = inform.title;

            if(inform.office != null)
            {
                label4.Text = inform.office;
            }
            
            if(inform.phone != null)
            {
                label5.Text = inform.phone;
            }
            
            label6.Text = inform.email;
            label7.Text = inform.tagline;
            label9.Text = inform.website;

            if(inform.twitter != null)
            {
                label10.Text = inform.twitter;
            }
            
            if(inform.facebook != null)
            {
                label11.Text = inform.facebook;
            }
            
            label12.Text = inform.interestArea;
        }

        //Change the picture and labels based on who you choose
        private void staffCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = staffCombo.SelectedItem.ToString();
            GetStaffPicture(s);

            Staff inform = people.staff.Find(x => x.name == s);

            label2.Text = inform.name;
            label3.Text = inform.title;

            if (inform.office != null)
            {
                label4.Text = inform.office;
            }

            if (inform.phone != null)
            {
                label5.Text = inform.phone;
            }

            label6.Text = inform.email;
            label7.Text = inform.tagline;
            label9.Text = inform.website;

            if (inform.twitter != null)
            {
                label10.Text = inform.twitter;
            }

            if (inform.facebook != null)
            {
                label11.Text = inform.facebook;
            }

            label12.Text = inform.interestArea;
        }

        #endregion People Stuff

        #region Research

        private void btn_research_Click(object sender, EventArgs e)
        {
            //Go to the Research page
            tabControl1.SelectedIndex = 4;
        }

        private void tp_research_Enter(object sender, EventArgs e)
        {
            //Get the json for Research
            string jsonResearch = rj.getRESTDataJSON("/research/");
            research = JToken.Parse(jsonResearch).ToObject<Research>();

            //Add the faculty names to the combobox
            foreach (ByFaculty byFac in research.byFaculty)
            {
                comboBox3.Items.Add(byFac.facultyName);
            }

            
        }

        //Prints out the matching information that goes with the selected faculty name
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ByFaculty by = research.byFaculty.Find(x => x.facultyName == comboBox3.SelectedItem.ToString());


            var sb = new StringBuilder();
            foreach (string eName in by.citations)
            {
                sb.Append(eName);
                sb.AppendLine();
                sb.AppendLine();
            }
            richTextBox4.Text = sb.ToString();

        }

        #endregion Research

        #region Resources

        private void btn_resources_Click(object sender, EventArgs e)
        {
            //Go to the Resources page
            tabControl1.SelectedIndex = 6;
        }

        private void tp_resources_Enter(object sender, EventArgs e)
        {
            //go get /resources/ and cast to the Resources object
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudyForm sf = new StudyForm();
            sf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentServ ss = new StudentServ();
            ss.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tutors t = new Tutors();
            t.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ambass a = new Ambass();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Formies f = new Formies();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CoopEnroll co = new CoopEnroll();
            co.ShowDialog();
        }

        #endregion Resources

        #region News

        private void btn_news_Click(object sender, EventArgs e)
        {
            //Go to the news page
            tabControl1.SelectedIndex = 5;
        }

        private void tp_news_Enter(object sender, EventArgs e)
        {
            //go get /news/ and cast to the News object
            string jsonNews = rj.getRESTDataJSON("/news/");
            news = JToken.Parse(jsonNews).ToObject<News>();

            //Add the news title to the combobox
            foreach (Older thisNew in news.older)
            {
                cmb_news.Items.Add(thisNew.title);
            }
        }

        //Print out the information based on the article that you choose
        private void cmb_news_SelectedIndexChanged(object sender, EventArgs e)
        {
            Older old = news.older.Find(x => x.title == cmb_news.SelectedItem.ToString());

            news_title.Text = old.title;
            news_date.Text = old.date;
            rtb_news.Text = old.description;
        }















        #endregion News

        #region Footer

        //The rest of the footer stuff will go in a separate form
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }

        #endregion Footer


    }
}
