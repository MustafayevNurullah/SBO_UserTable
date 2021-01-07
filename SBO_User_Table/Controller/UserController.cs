
using SAPbobsCOM;
using SBO_User_Table.Domain.HanaDb;
using SBO_User_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO_User_Table.Controller
{
    class UserController
    {
        List<User> Users;
        Company DbConnection;
        Recordset oRset;
        public UserController()
        {
            DbConnection = HanaDbConnection.DbConnection();
             oRset = (SAPbobsCOM.Recordset)DbConnection.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

        }
        public List<User>  GetAllUser()
        {
            Users = new List<User>();
            var query= "select * from \"@BMSTEST\"";
            oRset.DoQuery(query);

            if (oRset.RecordCount > 0)
            {
                for (int i = 0; i < oRset.RecordCount; i++)
                {
                   
                    User user = new User();
                    user.Name = oRset.Fields.Item("U_NAME").Value.ToString();
                    user.Surname = oRset.Fields.Item("U_SURNAME").Value.ToString();
                    user.Fathername = oRset.Fields.Item("U_FATHERNAME").Value.ToString();
                    user.Address = oRset.Fields.Item("U_ADDRESS").Value.ToString();
                    user.Phone = oRset.Fields.Item("U_PHONE").Value.ToString();
                    user.Company = oRset.Fields.Item("U_COMPANY").Value.ToString();
                    user.Id =Convert.ToInt32(oRset.Fields.Item("Code").Value.ToString());
                    Users.Add(user);
                    oRset.MoveNext();
                }
            }
            return Users;
        }

        public  void AddUser(User user)
        {
           oRset.DoQuery($"CALL \"B1100_PRD\".\"BMS::Add_User\"('{user.Name}','{user.Surname}','{user.Fathername}','{user.Address}','{user.Company}','{user.Phone}')");
            
            //SAPbobsCOM.UserTable oUserTable = HanaDbConnection.DbConnection().UserTables.Item("BMSTEST");
            ////oUserTable.Code = "2";

            ////oUserTable.Name = "2";

            //oUserTable.UserFields.Fields.Item("U_Name").Value = user.Name;

            //oUserTable.UserFields.Fields.Item("U_Surname").Value = user.Surname;

            //oUserTable.UserFields.Fields.Item("U_FatherName").Value = user.Fathername;
            //oUserTable.UserFields.Fields.Item("U_Address").Value = user.Address;
            //oUserTable.UserFields.Fields.Item("U_Company").Value = user.Company;
            //oUserTable.UserFields.Fields.Item("U_Phone").Value = user.Phone;
            //oUserTable.Add();
        }

        public void DeleteUser(int Id)
        {
            oRset.DoQuery($"DELETE FROM \"B1100_PRD\".\"@BMSTEST\" WHERE \"Code\" ={Id}");
        }

        public void UpdateUser(User user)
        {
            
            oRset.DoQuery($"UPDATE \"B1100_PRD\".\"@BMSTEST\"  SET \"U_NAME\" = '{user.Name}',\"U_SURNAME\" = '{user.Surname}',\"U_FATHERNAME\" = '{user.Fathername}',\"U_COMPANY\" = '{user.Company}',\"U_PHONE\" = '{user.Phone}',\"U_ADDRESS\" = '{user.Address}' WHERE \"Code\"= {user.Id}");
        }

    }
}
