using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;

        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }

        public class StudentInformationClass
        {
            public static int SetStudentNo = 0;
            public static int SetContactNo = 0;
            public static int SetAge = 0;
            public static string SetProgram = " ";
            public static string SetGender = " ";
            public static string SetBirthDay = " ";
            public static string SetFullName = " ";
        }
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            // Using the provided methods
            StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = (int) StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = (int)ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirtday.Value.ToString("yyyyMM-dd");

            // Show confirmation form
            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();

            try
            {
                StudentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNo.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Student Number format: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Student Number cannot be empty: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Value too large: " + ex.Message);
            }
            finally
            {
                // Any cleanup code if necessary
            }

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
     {
        "BS Information Technology",
        "BS Computer Science",
        "BS Information Systems",
        "BS in Accountancy",
        "BS in Hospitality Management",
        "BS in Tourism Management"
     };
            for (int i = 0; i < ListOfProgram.Length; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i]);
            }
        }

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
    


        }
    }
}
