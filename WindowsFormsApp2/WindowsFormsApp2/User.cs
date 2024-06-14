using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class User
    {
        private string name = "";
        private string email = "";
        private string password = "";

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }
        public string getName() { return name; }
    }
}
