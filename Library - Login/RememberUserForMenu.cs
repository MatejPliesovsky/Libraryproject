using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library___Login
{
    class RememberUserForMenu
    {
        private string userID;

        public RememberUserForMenu()
        {
        }

        public void setUserID(string userID)
        {
            this.userID = userID;
        }

        public string getUserID()
        {
            return userID;
        }
    }
}
