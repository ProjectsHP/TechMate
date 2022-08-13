using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service_Server_
{
    public class UserClass
    {
        int id;
        string name;
        string surname;
        string email;
        int phoneNo;
        string gender;
        string userType;


        public UserClass(int id, string name, string surname, string email, int phoneNo, string gender, string userType)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.PhoneNo = phoneNo;
            this.Gender = gender;
            this.UserType = userType;
        }

        public UserClass() { }

      
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public int PhoneNo { get => phoneNo; set => phoneNo = value; }
        public string Gender { get => gender; set => gender = value; }
        public string UserType { get => userType; set => userType = value; }
        public int Id { get => id; set => id = value; }
    }
}