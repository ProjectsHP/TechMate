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
using System.Collections;

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
                UserClass userObj = new UserClass(user.Id, user.name, user.surname, user.email, Convert.ToInt32(user.cellNo), user.gender, user.userType);
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

            if (user == null)
            {


                if (email.Contains("@admin.com"))
                {
                    userType = "Admin";
                }
                else if (email.Contains("@manager.com"))
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

        public int SendMail(string receiverEmail, string subject, string body)
        {
            MailSender mailSender = new MailSender();
            int response = mailSender.sendTextMail(receiverEmail, subject, body);
            return response;
        }


        // *********LOGIC************LOGIC*************LOGIC******************

        public CompatibilityClass VerifyBuildCompatibility(string desktopBaseId, string ram, string cpu, string storage, string graphics)
        {

            CompatibilityClass compObj = new CompatibilityClass();
            int deskId = Convert.ToInt32(desktopBaseId);
                        var caseCompatibility = (from u in db.Compatibilities
                              where u.desktopCase_id == deskId
                              select u).FirstOrDefault();


            if (caseCompatibility != null)
            {
                int ramId = Convert.ToInt32(ram);
                int cpuId = Convert.ToInt32(cpu);
                int graphicsId = Convert.ToInt32(graphics);
                int storageId = Convert.ToInt32(storage);

                dynamic build = (from u in db.Components
                                     where u.Id == ramId ||
                                           u.Id == cpuId ||
                                           u.Id == graphicsId ||
                                           u.Id == storageId 
                                     select u);
             
                if(build != null)
                {
                    foreach(Component comp in build)
                    {
                    
                        switch (comp.category)
                        {
                            case "Ram":
                                if (caseCompatibility.ramType == comp.compatibility)
                                {
                                    compObj.RamType = "Compatible";
                          

                                }
                                else
                                {
                                    compObj.RamType = "Not Compatible";
                                
                                }
                              
                                break;
                            case "CPU":
                                if (caseCompatibility.cpuType == comp.compatibility)
                                {
                                    compObj.CpuType = "Compatible";
                              

                                }
                                else
                                {
                                    compObj.CpuType = "Not Compatible";
                                
                                }

                                break;
                            case "Graphics":
                                if (caseCompatibility.graphicsType == comp.compatibility)
                                {
                                    compObj.GraphicsType = "Compatible";
                          

                                }
                                else
                                {
                                    compObj.GraphicsType = "Not Compatible";
                              
                                }

                                break;
                            case "Storage":
                                if (caseCompatibility.storageType == comp.compatibility)
                                {
                                    compObj.StorageType = "Compatible";
                             

                                }
                                else
                                {
                                    compObj.StorageType = "Not Compatible";
                              
                                }
                                break;
                                default:

                                break;


                        }
                    }

                    compObj.BaseId = desktopBaseId;
                    string y = "Compatible";
                    string n = "Not Compatible";
                    if(compObj.RamType ==y && compObj.CpuType==y && compObj.GraphicsType==y && compObj.StorageType == y)
                    {
                        compObj.BuildCompatibility = y;
                    }
                    else
                    {
                        compObj.BuildCompatibility = n;
                    }

                    return compObj;
                }
                return null;

               
            }
            return null;
        }


        //********DELETE***************** DELETE*****************DELETE***************** DELETE*********

        public int DeleteUser(string activeId)
        {
            int userId = Convert.ToInt32(activeId);
            var user = (from u in db.Users
                        where userId == u.Id
                        select u).FirstOrDefault();

            if (user != null)
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

        public int DeleteComponent(string compId)
        {
            int cId = Convert.ToInt32(compId);
            var comp = (from u in db.Components
                        where u.Id == cId
                        select u).FirstOrDefault();

            if (comp != null)
            {
                db.Components.DeleteOnSubmit(comp);
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
                //component not found
                return 0;
            }
        }

        // *******EDIT** EDIT*****EDIT****** EDIT*******EDIT***** EDIT********EDIT****** EDIT********


        public int EditUser(string name, string surname, string cellNo, string gender, string email, string activeId)
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

        public int EditComponent(string compId, string name, string priceToDisp, string availability, string description, string image, string category, string compatibilityStatus)
        {
            int id = Convert.ToInt32(compId);
            var comp = (from u in db.Components
                        where id == u.Id
                        select u).FirstOrDefault();

            if (comp != null)
            {

                string p = priceToDisp;
                string normalPrice = p.Replace(" ", "");
               int intPrice  = Convert.ToInt32(normalPrice);

                comp.name = name;
                comp.price = priceToDisp;
                comp.availability = availability;
                comp.description = description;
                comp.image = image;
                comp.category = category;
                comp.compatibility = compatibilityStatus;
                comp.intPriceFormat = intPrice;

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

        public int FulfilOrder(string orderId)
        {
           
            var activeOrder = FetchOrderById(orderId);
            if(activeOrder != null)
            {
                string uId = Convert.ToString(activeOrder.userId);
               var user= FetchActiveUser(uId);
                if(user != null)
                {
                    activeOrder.orderStatus = "Approved";


                    try
                    {
                        //edited successfully
                        db.SubmitChanges();
                        string mail = "Hello " + user.name +" "+user.surname+ " Thank you for your order, it has been reviewed and approved. It will soon leave the storehouse into shippment to your specified address. Your order number is #" + activeOrder.Id;
                        SendMail("hlulankubayi@gmail.com", "Order approved", mail);
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
                    //user not found
                    return -2;
                }

              


            }
            else
            {
                //Order not found
                return 0;
            }

           
        }

        public int RejectOrder(string orderId, string reason)
        {
            var activeOrder = FetchOrderById(orderId);
            if (activeOrder != null)
            {
                string uId = Convert.ToString(activeOrder.userId);
                var user = FetchActiveUser(uId);
                if (user != null)
                {
                    activeOrder.orderStatus = "Rejected";


                    try
                    {
                        //edited successfully
                        db.SubmitChanges();
                        string mail = "Hello " + user.name + " " + user.surname + " Thank you for your order, Unfortunately your order has been rejected due to: " + reason;
                        mail += " Your order Id is #" + activeOrder.Id;
                        SendMail("hlulankubayi@gmail.com", "Order Rejected", mail);
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
                    //user not found
                    return -2;
                }




            }
            else
            {
                //Order not found
                return 0;
            }
        }

        public int UpdateStock(string componentId, string updateType, string quantity)
        {
            int stockQuantity = Convert.ToInt32(quantity);

            var activeComp = FetchComponent(componentId);
            if (activeComp != null)
            {
                int stockCount = Convert.ToInt32(activeComp.availability);
                
                    if (updateType == "Increase" )
                    {
                        stockCount += stockQuantity;
                    }
                    else if(updateType == "Decrease")
                    {
                        stockCount -= stockQuantity;
                        if (stockCount <= 0)
                        {
                            stockCount = 0;
                        }
                    }
                    
               
                    activeComp.availability = stockCount.ToString();


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
                //Order not found
                return 0;
            }

            return -1;
        }

        //******CREATE************* CREATE*************CREATE************* CREATE*************CREATE*******

        public int CreateBuild(string user_id, string desktop_id, string cpu_id, string storage_id, string graphics_id, string ram_id, string compatibilityStatus, string totalPrice)
        {


            int storage = Convert.ToInt32(storage_id);
            int user = Convert.ToInt32(user_id);
            int cpu = Convert.ToInt32(cpu_id);
            int graphics = Convert.ToInt32(graphics_id);
            int ram = Convert.ToInt32(ram_id);
            int desktop = Convert.ToInt32(desktop_id);
            int total = Convert.ToInt32(totalPrice);




            var newBuild = new Build
            {
                baseBuild_id = desktop,
                cpu_id = cpu,
                storage_id = storage,
                graphics_id = graphics,
                ram_id = ram,
                compatibilityStatus = compatibilityStatus,
                category = "Build",
                user_id = user,
                totalPrice = total,

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

        public int CreateComponent(string name, string priceToDisp, string availability, string description, string image, string category, string compatibilityStatus)
        {
            string p = priceToDisp;
            string normalPrice = p.Replace(" ", "");
            int price = Convert.ToInt32(normalPrice);


            var newComp = new Component
            {
                name = name,
                intPriceFormat = price,
                availability = availability,
                description = description,
                image = image,
                category = category,
                compatibility = compatibilityStatus,
                price = priceToDisp,


            };
            db.Components.InsertOnSubmit(newComp);

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

        public int SaveCart(string userId, string buildId, string totalPrice, string discountSaved)
        {
            int user_id = Convert.ToInt32(userId);

            var user = (from u in db.Users
                        where u.Id == user_id
                        select u).FirstOrDefault();

            if (user != null)
            {

                var newCart = new Cart
                {
                    build_id = -1,
                    user_id = Convert.ToInt32(user_id),
                    totalPrice = totalPrice,
                    totalDiscountSaved = discountSaved

                };
                db.Carts.InsertOnSubmit(newCart);

                try
                {
                    // added new cart successfully
                    db.SubmitChanges();

                    int cartId = newCart.Id;
                    return cartId;
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
                //user does not exist
                return -2;
            }


        }

        public int SaveOrder(string cartId, string userAddressId, string userId)
        {
            int user_id = Convert.ToInt32(userId);


            string date = DateTime.Today.ToString("dd/MM/yyyy");
            var newOrder = new Order
                {
                    cartId = Convert.ToInt32(cartId),
                    paymentId = -1,
                    userAddressId = Convert.ToInt32(userAddressId),
                    userId = Convert.ToInt32(userId),
                    dateCreated=date,
                    paymentMade="Paid",
                   orderStatus="Pending",
                };
                db.Orders.InsertOnSubmit(newOrder);

                try
                {
                    // added new cart successfully
                    db.SubmitChanges();
                string body = "Hello your order has been received. It will shortly be reviewed and place for shippment.";
              
                int retVal = SendMail("hlulankubayi@gmail.com", "Order received", body);
                if (retVal == 1)
                {
                    //added and sent email
                    int orderId = newOrder.Id;
                    return orderId;
                }
                else
                {
                    // added but did not send email
                    return -3;
                }
                
                }
                catch (Exception ex)
                {
                    //error occured
                    ex.GetBaseException();
                    return -1;
                }

          

        }

        public int SaveCartItems(string componentId, string cartId, string quantity)
        {

            var cartItem = new CartItem
            {
                component_id = Convert.ToInt32(componentId),
                cart_id = Convert.ToInt32(cartId),
                quantity = 1

            };
            db.CartItems.InsertOnSubmit(cartItem);

            try
            {
                // added new cart item successfully
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

        public int CheckoutOrder(string userId, string orderId, string cardId, string paymentId,
                                 string userAddressId, string totalPrice, string totalItems, string paymentMade,
                                 string orderStatus, List<int> listOfCartItemId)
        {


            int uId = Convert.ToInt32(userId);
            var user = (from u in db.Users
                        where u.Id == uId
                        select u).FirstOrDefault();

            if (user != null)
            {

                bool allSavedToCart = true;
                //CREATE CART *************************
                int cartSaved = SaveCart(userId, "-1", totalPrice, "0");
                string cartI = Convert.ToString(cartSaved);
                if (cartSaved != -1 || cartSaved != -2)
                {
                    foreach (int itemId in listOfCartItemId)
                    {

                        int verify = SaveCartItems(Convert.ToString(itemId), cartI, "1");
                        if (verify != 1)
                        {
                            allSavedToCart = false;
                        }

                    }
                    if (allSavedToCart == true)
                    {
                        string date = DateTime.Today.ToString("dd/MM/yyyy");
                        var newOrder = new Order
                        {
                            cartId = cartSaved,
                            orderStatus = orderStatus,
                            paymentId = Convert.ToInt32(paymentId),
                            userAddressId = 2,
                            userId = user.Id,
                            dateCreated = date,
                            paymentMade = paymentMade,

                        };
                        db.Orders.InsertOnSubmit(newOrder);

                        try
                        {
                            // registered successfully
                            db.SubmitChanges();
                            string body = "Hello " + user.name + " your order has been received. It will shortly be reviewed and place for shippment.";

                            int retVal = SendMail("hlulankubayi@gmail.com", "Order received", body);
                            if (retVal == 1)
                            {
                                //added and sent email
                                return 1;
                            }
                            else
                            {
                                // added but did not send email
                                return -3;
                            }

                        }
                        catch (Exception ex)
                        {
                            //error occured
                            ex.GetBaseException();
                            return -1;
                        }

                    }
                }

            }
            return 0;

        }

        public int StoreUserAddress(string userId, string country, string province, string city, string streetUnit, string name, string surname, string cellPhone, string email)
        {

            int user_id = Convert.ToInt32(userId);
            var user = (from u in db.Users
                        where u.Id == user_id
                        select u).FirstOrDefault();

            if (user != null)
            {

                var newUserAddress = new DeliveryAddress
                {
                    user_id = user_id,
                    country = country,
                    province = province,
                    city = city,
                   // suburb = "Brixton",
                    streetUnit = streetUnit,


                };
                db.DeliveryAddresses.InsertOnSubmit(newUserAddress);

                try
                {
                    // registered successfully
                    db.SubmitChanges();
                    int addrId = newUserAddress.Id;
                    return addrId;
                  
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
                // user not found/logged in. 
                return 0;
            }


        }


      //********FETCH*************** FETCH***************FETCH*************** FETCH***************FETCH*******

        public User FetchActiveUser(string id)
        {
            int userId = Convert.ToInt32(id);
            var activeUser = (from u in db.Users
                              where u.Id == userId
                              select u).FirstOrDefault();

            if (activeUser != null)
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

            if (allUsers != null)
            {
                foreach (dynamic user in allUsers)
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

        public List<Component> FetchSingleComponentByImage(string image)
        {

            var compList = new List<Component>();  
            dynamic result = (from u in db.Components
                                   where u.image == image
                                   select u);
            
            if (result != null)
            {
               
                    foreach (Component comp in result)
                    {
                        compList.Add(comp);
                    }
              
                return compList;
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



            if (result != null)
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
                foreach (dynamic comp in buildComp)
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

        public List<Component> FetchSingleUserBuild(string user_id)
        {

            var buildCompList = new List<Component>();
            int Id = Convert.ToInt32(user_id);
            var activeBuild = (from u in db.Builds
                               where u.user_id == Id
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
                foreach (dynamic comp in buildComp)
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

        public DeliveryAddress FetchUserAddress(string userId)
        {
            int user_id = Convert.ToInt32(userId);

            var address = (from u in db.DeliveryAddresses
                           where u.user_id == user_id
                           select u).FirstOrDefault();

            if (address != null)
            {
                return address;
            }
            else
            {
                return null;
            }

        }

        public OrderClass FetchOrder(string userId, string orderId, string cardNumber)
        {
            bool running = true;
            OrderClass objOrder = new OrderClass();
            int uId = Convert.ToInt32(userId);
            int oId = Convert.ToInt32(orderId);

            var activeOrder = (from u in db.Orders
                               where u.userId == uId
                               select u).FirstOrDefault();

            if (activeOrder != null)
            {
                objOrder.OrderId = activeOrder.Id;
                objOrder.CardNumber = Convert.ToInt32(cardNumber);
                objOrder.OrderDate = activeOrder.dateCreated;
                objOrder.OrderStatus = activeOrder.orderStatus;
                objOrder.PaymentMade = activeOrder.paymentMade;

                //get address
                var address = (from u in db.DeliveryAddresses
                               where u.user_id == uId
                               select u).FirstOrDefault();
                if (address != null)
                {
                    objOrder.DeliveryAddress = address;

                }
                else
                {
                    running = false;
                }



                //get user
                var userObj = (from u in db.Users
                               where u.Id == uId
                               select u).FirstOrDefault();
                if (userObj != null)
                {
                    objOrder.User = userObj;
                }
                else
                {
                    running = false;
                }


                // get cart
                var cartObj = (from u in db.Carts
                               where u.Id == activeOrder.cartId
                               select u).FirstOrDefault();
                if (cartObj != null)
                {

                    //get cart items
                    dynamic itemsList = (from u in db.CartItems
                                         where u.cart_id == activeOrder.cartId
                                         select u);

                    if (itemsList != null)
                    {

                        //make list of items

                        objOrder.ListOfCartObj = new List<CartItem>();
                        objOrder.ListOfComponents = new List<Component>();

                        foreach (CartItem item in itemsList)
                        {

                            var comp = FetchComponent(Convert.ToString(item.component_id));
                            objOrder.ListOfCartObj.Add(item);
                            objOrder.ListOfComponents.Add(comp);
                        }
                        objOrder.TotalItems = objOrder.ListOfCartObj.Count();
                        objOrder.TotalPrice = Convert.ToInt32(cartObj.totalPrice);


                    }
                    else
                    {
                        running = false;
                    }


                }
                else
                {
                    running = false;
                }


            }
            else
            {
                running = false;

            }


            //return 
            if (running == true)
            {
                return objOrder;
            }
            else
            {
                return null;
            }

        }

        public List<Order> FetchAllUserOrders(string userId)
        {
            int uId = Convert.ToInt32(userId);
            var orderList = new List<Order>();



            dynamic allOrders = (from u in db.Orders
                                 where u.userId == uId
                                 select u);

            if (allOrders != null)
            {
                foreach (dynamic comp in allOrders)
                {

                    orderList.Add(comp);
                }
                return orderList;
            }
            else
            {
                return null;
            }
        }

        public List<Order> FetchAllOrders(string filter)
        {
        
            var orderList = new List<Order>();

            dynamic allOrders = (from u in db.Orders
                                 select u);

            if (allOrders != null)
            {
                foreach (dynamic comp in allOrders)
                {

                    orderList.Add(comp);
                }
                return orderList;
            }
            else
            {
                return null;
            }
        }

        public Order FetchOrderById(string orderId)
        {
            int oId = Convert.ToInt32(orderId);
            var activeUser = (from u in db.Orders
                              where u.Id == oId
                              select u).FirstOrDefault();

            if (activeUser != null)
            {
                return activeUser;
            }
            else
            {
                return null;
            }
        }

        public Compatibility FetchCaseCompatibility(string caseId)
        {
            int cId = Convert.ToInt32(caseId);
            var compatibility = (from u in db.Compatibilities
                              where u.desktopCase_id == cId
                              select u).FirstOrDefault();

            if (compatibility != null)
            {
                return compatibility;
            }
            else
            {
                return null;
            }
        }

      
    }
}
