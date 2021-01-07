using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SBO_User_Table.Controller;
using SBO_User_Table.Models;
using SAPbouiCOM;
using System.Windows.Forms;

namespace SBO_User_Table.Views
{
    [FormAttribute("SBO_User_Table.Views.Form2", "Views/AddUserView.b1f")]
    class Form2 : UserFormBase
    {
        UserController UserController;
        Form1 Form1;
        public Form2(UserController usercontroller,Form1 form1 )
        {
            this.Form1 = form1;
            this.UserController = usercontroller;
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Name = ((SAPbouiCOM.EditText)(this.GetItem("NameTb").Specific));
            this.Surname = ((SAPbouiCOM.EditText)(this.GetItem("SurnameTb").Specific));
            this.FatherName = ((SAPbouiCOM.EditText)(this.GetItem("FatherTb").Specific));
            this.Address = ((SAPbouiCOM.EditText)(this.GetItem("AddressTb").Specific));
            this.Phone = ((SAPbouiCOM.EditText)(this.GetItem("PhoneTb").Specific));
            this.Company = ((SAPbouiCOM.EditText)(this.GetItem("CompanyTb").Specific));

            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.EditText Name;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.EditText Surname;
        private SAPbouiCOM.EditText FatherName;
        private SAPbouiCOM.EditText Address;
        private SAPbouiCOM.EditText Phone;
        private SAPbouiCOM.EditText Company;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.Button Button1;

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            User user = new User();
            if (Name.Value == "" || Surname.Value == "" || FatherName.Value == "" || Address.Value == "" || Company.Value == "" || Phone.Value == "")
            {
                MessageBox.Show("Enter the text");
            }
            else
            {

            user.Name = Name.Value;
            user.Surname = Surname.Value;
            user.Fathername = FatherName.Value;
            user.Address = Address.Value;
            user.Company = Company.Value;
            user.Phone = Company.Value;
            UserController.AddUser(user);
            Form1.MatrixDataWrite();
            }
    }

        

        
    }
}
