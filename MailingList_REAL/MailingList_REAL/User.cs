using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailingList_REAL
{
    public class User
    {
        private Int32 id;
        private String name;
        private String mailAddress;

        public User(Int32 id, String name, String address)
        {
            this.id = id;
            this.name = name;
            this.mailAddress = address;
        }

        public Int32 GetId()
        {
            return id;
        }

        public String GetName()
        {
            return name;
        }

        public String getMailAddress()
        {
            return mailAddress;
        }
    }
}