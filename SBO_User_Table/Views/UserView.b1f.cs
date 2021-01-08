using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;
using System.Windows.Forms;
using SBO_User_Table.Controller;
using SAPbobsCOM;
using SBO_User_Table.Domain.HanaDb;
using SBO_User_Table.Models;
using System.Threading.Tasks;
using SBO_User_Table.Views;

namespace SBO_User_Table
{
    [FormAttribute("SBO_User_Table.Form1", "Views/UserView.b1f")]
    class UserView : UserFormBase
    {

        UserController UserController;
        Company oCompany;
        List<User> Users;
        int SelectedRow=0;
        public UserView()
        {
            Users = new List<User>();
            oCompany = new Company();
            UserController = new UserController();
            MatrixDataWrite();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Matrix").Specific));
            this.Matrix0.ClickBefore += new SAPbouiCOM._IMatrixEvents_ClickBeforeEventHandler(this.Matrix0_ClickBefore);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("AddBtn").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("UpdateBtn").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("DeleteBtn").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.OnCustomInitialize();

        }
        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        public void MatrixDataWrite()
        { 
                Users = UserController.GetAllUser();
                for (int i = 0; i < Users.Count; i++)
                {
                    Matrix0.AddRow();
                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Name").Cells.Item(i + 1).Specific).Value = Users[i].Name;
                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("Surname").Cells.Item(i + 1).Specific).Value = Users[i].Surname;
                    ((SAPbouiCOM.EditText)Matrix0.Columns.Item("FatherName").Cells.Item(i + 1).Specific).Value = Users[i].Fathername;
                }
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            AddUserView form2 = new AddUserView(UserController,this);
            form2.Show();
            
        }

        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (SelectedRow != 0)
            {
                UserController.DeleteUser(Users[SelectedRow - 1].Id);
                Users.RemoveAt(SelectedRow - 1);
                Matrix0.DeleteRow(SelectedRow);
                SelectedRow = 0;
            }
            else
            {
                MessageBox.Show("Select item");
            }
            }

        private void Matrix0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SelectedRow = pVal.Row;

        }

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if(SelectedRow!=0)
            {

            UpdateUserView view = new UpdateUserView(Users[SelectedRow - 1], UserController, this);
            view.Show();
                SelectedRow = 0;
            }
            else
            {
                MessageBox.Show("Select item");
            }
           
        }
    }
}