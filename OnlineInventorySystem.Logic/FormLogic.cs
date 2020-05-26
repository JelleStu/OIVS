using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineInventorySystem.Logic
{
    public class FormLogic
    {
        public bool NullCheck(string username, string psword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(psword))
            {
                return true;
            }
            return false;
        }

    }
}
