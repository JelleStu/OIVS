using System;
using System.Collections.Generic;
using System.Text;
using OnlineInventorySystem.Data;
using OnlineInventorySystem;
namespace OnlineInventorySystem.Logic
{
    public class CompanyManagerLogic
    {
        private readonly CompanyMangerData companyMangerData = new CompanyMangerData();
        public int CompanyLogin(string username, string psword)
        {
          int companyid =  companyMangerData.Login(username, psword);
          if (companyid != 0)
          {
              return companyid;
          }
          else
          {
              return 0;
          }
        }
    }
}
