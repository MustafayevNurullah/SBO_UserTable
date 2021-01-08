using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using SBO_User_Table.Controller;
using SBO_User_Table.Models;
using System.Windows.Forms;

namespace SBO_User_Table.Views
{
    [FormAttribute("SBO_User_Table.Views.UpdateUserView", "Views/UpdateUserView.b1f")]
    class UpdateUserView : UserFormBase
    {
        UserController usercontroller;
        UserView userview;
        User user;
        public UpdateUserView(User user,UserController usercontroler,UserView userview)
        {
            this.usercontroller = usercontroler;
            this.userview = userview;
            NameTb.Value = user.Name;
            SurnameTb.Value = user.Surname;
            FatherNameTb.Value = user.Fathername;
            AddressTb.Value = user.Address;
            PhoneTb.Value = user.Phone;
            CompanyTb.Value = user.Company;
            this.user = user;
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.NameTb = ((SAPbouiCOM.EditText)(this.GetItem("NameTb").Specific));
            this.SurnameTb = ((SAPbouiCOM.EditText)(this.GetItem("SurnameTb").Specific));
            this.FatherNameTb = ((SAPbouiCOM.EditText)(this.GetItem("FatherTb").Specific));
            this.AddressTb = ((SAPbouiCOM.EditText)(this.GetItem("AddressTb").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.PhoneTb = ((SAPbouiCOM.EditText)(this.GetItem("PhoneTb").Specific));
            this.CompanyTb = ((SAPbouiCOM.EditText)(this.GetItem("CompanyTb").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Update").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText NameTb;
        private SAPbouiCOM.EditText SurnameTb;
        private SAPbouiCOM.EditText FatherNameTb;
        private SAPbouiCOM.EditText AddressTb;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText PhoneTb;
        private SAPbouiCOM.EditText CompanyTb;
        private SAPbouiCOM.Button Button0;

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
            if (NameTb.Value == "" || SurnameTb.Value == "" || FatherNameTb.Value == "" || AddressTb.Value == "" || CompanyTb.Value == "" || PhoneTb.Value == "")
            {
                MessageBox.Show("Enter the text");
            }
            else
            {
                user.Name = NameTb.Value;
                user.Surname = SurnameTb.Value;
                user.Fathername = FatherNameTb.Value;
                user.Address = AddressTb.Value;
                user.Company = CompanyTb.Value;
                user.Phone = CompanyTb.Value;
                usercontroller.UpdateUser(user);
                userview.MatrixDataWrite();
                MessageBox.Show("User update successfully");

            }

        }
    }
}
