using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Information
{
       public static class ValidationExtensions
    {
      
     public static bool NationalCode(this string Code)
        {

            bool valid = true;    
            try
            {
                if (Code.Length != 10)
                    return false;
                int[] numArray = new int[Code.Length];
                for (int i = 0; i < Code.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(Code[i]);
                }
                int num2 = numArray[9];
                switch (Code)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        valid = false;
                        break;
                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    //"کد ملی صحیح می باشد"
                }
                else
                {
                    valid = false;
                }
            }
            catch
            {
                valid = false;
            }
            return valid;
     

        }
     }
    public partial class FrmPerson : Form
    {
        public FrmPerson()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtNationalCode.Text.NationalCode())
            {
                MessageBox.Show("کد ملی نامعتبر است");
                return;
            }            
            var Peaple = new Person();
            Peaple.NationalCode = txtNationalCode.Text;
            Peaple.Name = txtName.Text;
            Peaple.LastName = txtLastName.Text;
            Peaple.Gender = txtGender.Text;
            var frmMain = Application.OpenForms["FrmMain"] as FrmMain;
            frmMain.peaple.Add(Peaple);
            this.Close();

        }
    }
}
