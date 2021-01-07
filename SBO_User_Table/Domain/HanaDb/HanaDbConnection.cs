using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO_User_Table.Domain.HanaDb
{
    public class HanaDbConnection
    {
        static Company company;
        private HanaDbConnection()
        {
             company = (SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany();
        }

        public static Company DbConnection()
        {
            if (company == null)
            {
                HanaDbConnection DbConnection = new HanaDbConnection();
            }
            return company;
        }


    }
}
