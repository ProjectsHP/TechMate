using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.ServiceModel.Description;
using System.Net;

namespace WCF_Service_Server_
{

    public class Service : IService, IServiceREST
    {

        linq2sqlDataContext db = new linq2sqlDataContext();
  

        public string HashPassword(string password)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] byteArray = null;
            byteArray = algorithm.ComputeHash(Encoding.Default.GetBytes(password));
            string hashedPassword = "";
            for (int i = 0; i < byteArray.Length - 1; i++)
            {
                hashedPassword += byteArray[i].ToString("x2");
            }
            return hashedPassword;
        }

        public UserClass Login(string email, string password)
        {
          

            //  string hashedPass = HashPassword(password);
            var user = (from u in db.Users
                        where u.email == email && u.password == password
                        select u).FirstOrDefault();

            if (user != null)
            {
                UserClass userObj = new UserClass(user.Id,user.name,user.surname,user.email,Convert.ToInt32(user.cellNo),user.gender,user.userType);
                return userObj;
            }
            else
            {
                UserClass defaultObj = new UserClass(-1, "def", "def", "def", 111, "def", "def");
                return defaultObj;
              
            }
       
        }

        public int Register(string name, string surname, string cellNo, string gender, string email, string password, string userType)
        {
            var user = (from u in db.Users
                        where u.email == email 
                        select u).FirstOrDefault();

            if(user == null)
            {
              

                if (email.Contains("@admin.com"))
                {
                    userType = "Admin";
                }
                else if(email.Contains("@manager.com"))
                {
                    userType = "Manager";
                }
                else if (email.Contains("@clerk.com"))
                {
                    userType = "Clerk";
                }
                else if (email.Contains("@sManager.com"))
                {
                    userType = "sManager";
                }
                else
                {
                    userType = "Customer";
                }

                //       password=HashPassword(password);
                var newUser = new User
                {
                    name = name,
                    surname = surname,
                  //  cellNo = 4545,
                    cellNo = cellNo,
                    gender = gender,
                    email = email,
                    password = password,
                    userType = userType,
                    

                };
                db.Users.InsertOnSubmit(newUser);

                try
                {
                    // registered successfully
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    //error occured
                    ex.GetBaseException();
                    return -1;
                }
            }
            else
            {
                // user already exist try different email
                return 0;
            }
              
        }
        
        public int EditUser(string name, string surname, string cellNo, string gender,string email, string activeId)
        {
            int id = Convert.ToInt32(activeId);
            var user = (from u in db.Users
                        where id == u.Id
                        select u).FirstOrDefault();

            if (user != null)
            {

                user.name = name;
                user.surname = surname;
                user.cellNo = cellNo;
                user.gender = gender;
                user.email = email;
                user.userType = "customer";
                try
                {
                    //edited successfully
                    db.SubmitChanges();
                    return 1;
                }
                catch (IndexOutOfRangeException ex)
                {
                    //error OutOfRangeException 
                    ex.GetBaseException();
                    return -1;
                }
            }
            else
            {
                //User doesnt exist
                return 0;
            }  
            
        }

        public int DeleteUser(string activeId)
        {
            int userId = Convert.ToInt32(activeId);
            var user = (from u in db.Users
                        where userId == u.Id
                        select u).FirstOrDefault();

            if(user != null)
            {
                db.Users.DeleteOnSubmit(user);
                try
                {

                    //succesfull
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    //error
                    ex.GetBaseException();
                    return -1;
                }
            }
            else
            {
                //user not found
                return 0;
            }
        
        }

        public int SendMail(string receiverEmail, string subject, string body)
        {
            MailSender mailSender = new MailSender();
            int response = mailSender.sendTextMail("ph.kubaye@gmail.com", "Test email",
                "Just to check if the server sends email to clients");
            return response;
        }

        public int CreateBuild(string user_id, string desktop_id, string cpu_id, string storage_id, string graphics_id, string ram_id, string compatibilityStatus, string totalPrice)
        {

          
            int storage=Convert.ToInt32(storage_id);
            int user = Convert.ToInt32(user_id);
            int cpu = Convert.ToInt32(cpu_id);
            int graphics = Convert.ToInt32(graphics_id);
            int ram = Convert.ToInt32(ram_id);
            int desktop = Convert.ToInt32(desktop_id);
            int total = Convert.ToInt32(totalPrice);
           
             


              var newBuild = new Build
                  {
                     baseBuild_id=desktop,
                     cpu_id= cpu,
                     storage_id= storage,
                     graphics_id= graphics,
                     ram_id= ram,
                     compatibilityStatus=compatibilityStatus,
                     category="Desktop Computer",
                     user_id= user,
                     totalPrice= total,

                  };
                  db.Builds.InsertOnSubmit(newBuild);

                  try
                  {
                      // created build successfully
                      db.SubmitChanges();

                  int build_id = newBuild.Id;
                      return build_id;
                  }
                  catch (Exception ex)
                  {
                      //error occured
                      ex.GetBaseException();
                      return -1;
                  }
            
        
            }

        public User FetchActiveUser(string id)
        {
            int userId = Convert.ToInt32(id);
            var activeUser = (from u in db.Users
                              where u.Id == userId
                              select u).FirstOrDefault();

            if(activeUser != null)
            {
                return activeUser;
            }
            else
            {
                return null;
            }
        }

        public List<User> FetchAllUsers()
        {
            var allUserList = new List<User>();
            dynamic allUsers = (from u in db.Users
                                select u);

            if(allUsers != null)
            {
                foreach(dynamic user in allUsers)
                {
                    allUserList.Add(user);
                }
                return allUserList;
            }
            else
            {
                return null;
            }
        }


        public Component FetchComponent(string component_id)
        {
            int compId = Convert.ToInt32(component_id);
            var activeComponent = (from u in db.Components
                              where u.Id == compId
                              select u).FirstOrDefault();

            if (activeComponent != null)
            {
                return activeComponent;
            }
            else
            {
                return null;
            }
        }

        public List<Component> FetchRandomComponents(string size)
        {

            var compList = new List<Component>();

            dynamic result = (from u in db.Components.ToList()
             
              select u).OrderBy(x => Guid.NewGuid()).Take(Convert.ToInt32(size));

       

            if(result != null)
            {
                foreach (Component comp in result)
                {
                    compList.Add(comp);
                }
            }

            return compList;          
        }

        public List<Component> FetchComponentsByCategory(string category)
        {
            var compsList = new List<Component>();
            dynamic allComps = (from u in db.Components
                                where u.category == category
                                select u);

            if (allComps != null)
            {
                foreach (dynamic comp in allComps)
                {
                    compsList.Add(comp);
                }
                return compsList;
            }
            else
            {
                return null;
            }
        }
     
        public List<Component> FetchBuild(string build_id)
        {

            var buildCompList = new List<Component>();
            int Id = Convert.ToInt32(build_id);
            var activeBuild = (from u in db.Builds
                              where u.Id == Id
                              select u).FirstOrDefault();

            if (activeBuild != null)
            {
                dynamic buildComp = (from u in db.Components
                                     where u.Id == activeBuild.storage_id ||
                                           u.Id == activeBuild.graphics_id ||
                                           u.Id == activeBuild.cpu_id ||
                                           u.Id == activeBuild.ram_id ||
                                           u.Id == activeBuild.baseBuild_id
                                     select u);
                foreach(dynamic comp in buildComp)
                {

                    buildCompList.Add(comp);
                }
           
                buildCompList.Sort((a, b) => a.category.CompareTo(b.category));

                return buildCompList;
            }
            else
            {
                return null;
            }


        }


        public List<BuildClass> FetchAllUserBuilds(string user_id)
        {
          
            var buildCompList = new List<BuildClass>();
            int Id = Convert.ToInt32(user_id);

            dynamic activeBuild = (from u in db.Builds
                               where u.user_id == Id
                               select u);

            if (activeBuild != null)
            {
               
                foreach (Build build in activeBuild)
                {
                    BuildClass buildClass = new BuildClass();
                    string buildId = Convert.ToString(build.Id);
                    List<Component> buildComponentData = FetchBuild(buildId);
                   
                    foreach (Component component in buildComponentData)
                    {
                        switch (component.category)
                        {
                            case "Ram":
                                buildClass.RamComponent = component;

                                break;
                            case "CPU":
                                buildClass.CpuComponent = component;

                                break;
                            case "Storage":
                                buildClass.StorageComponent = component;

                                break;
                            case "Desktop":
                                buildClass.BaseCaseComponent = component;
                                break;
                            case "Graphics":
                                buildClass.GraphicsComponent = component;
                                break;
                        }
                    
                    }
                    buildClass.Build_id = buildId;
                    buildClass.CompatibilityStatus = "Compatible";
                    buildClass.User_build_id = user_id;
                    buildClass.Category = build.category;
                    buildClass.TotalPrice = Convert.ToString(build.totalPrice);
                   
                        buildCompList.Add(buildClass);
                }

             //   buildCompList.Sort((a, b) => a.Category.CompareTo(b.Category));

                return buildCompList;
            }
            else
            {
                return null;
            }


        }

        public List<Component> FetchTopComponents(string category, string size)
        {
            var compList = new List<Component>();

            dynamic result = (from u in db.Components.ToList()
                              where u.category == category
                              select u).Take(Convert.ToInt32(size));



            if (result != null)
            {
                foreach (Component comp in result)
                {
                    compList.Add(comp);
                }
            }

            return compList;
        }

        public void MakeOrder(List<CartItemClass> itemsList)
        {

        }

     
    }
}
