using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Service_Server_
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract(Name ="LoginSOAP")]   
        UserClass Login(string email, string password);
        

        [OperationContract(Name="HashPasswordSOAP")]
        string HashPassword(string password);

        
        [OperationContract(Name ="RegisterSOAP")]
        int Register(string name, string surname, string cellNo, string gender, string email, string password, string userType);
        

        [OperationContract(Name="EditUserSOAP")]     
        int EditUser(string name, string surname, string cellNo, string gender,string email, string activeId);

        [OperationContract(Name = "EditComponentSOAP")]
        int EditComponent(string compId, string name, string priceToDisp, string availability, string description, string image, string category, string compatibilityStatus);


        [OperationContract(Name = "UpdateStockSOAP")]
        int UpdateStock(string componentId, string updateType, string quantity);


        // Logic functions********** Logic functions********** Logic functions********** Logic functions**********

        [OperationContract(Name = "FulfilOrderSOAP")]
        int FulfilOrder(string orderId);

        [OperationContract(Name = "RejectOrderSOAP")]
        int RejectOrder(string orderId, string reason);


        [OperationContract(Name = "VerifyBuildCompatibilitySOAP")]
        CompatibilityClass VerifyBuildCompatibility(string desktopBaseId, string ram, string cpu, string storage, string graphics);




        [OperationContract(Name = "DeleteUserSOAP")]
        int DeleteUser(string activeId);


        [OperationContract(Name = "DeleteComponentSOAP")]
        int DeleteComponent(string compId);


        [OperationContract(Name = "StoreUserAddressSOAP")]
        int StoreUserAddress(string userId, string country,string province, string city, string streetUnit, string name, string surname, string cellPhone, string email);


        [OperationContract(Name ="FetchActiveUserSOAP")]
        User FetchActiveUser(string id);


        [OperationContract(Name = "FetchSingleUserBuildSOAP")]
        List<Component> FetchSingleUserBuild(string user_id);


        [OperationContract(Name ="FetchAllUsersSOAP")] 
        List<User> FetchAllUsers();


        [OperationContract(Name = "FetchRandomComponentsSOAP")]
        List<Component> FetchRandomComponents(string size);


        [OperationContract(Name = "FetchComponentsByCategorySOAP")]
        List<Component> FetchComponentsByCategory(string category);


        [OperationContract(Name = "FetchTopComponentsSOAP")]
        List<Component> FetchTopComponents(string category, string size);


        [OperationContract(Name = "FetchBuildSOAP")]
        List<Component> FetchBuild(string build_id);

        [OperationContract(Name = "FetchComponentSOAP")]
        Component FetchComponent(string component_id);


        [OperationContract(Name = "FetchSingleComponentByImageSOAP")]
        List<Component> FetchSingleComponentByImage(string image);


        [OperationContract(Name = "CreateComponentSOAP")]
        int CreateComponent(string name, string priceToDisp, string availability, string description,string image, string category, string compatibilityStatus);


        [OperationContract(Name = "CreateBuildSOAP")]
        int CreateBuild(string user_id, string desktop_id, string cpu_id, string storage_id, string graphics_id, string ram_id, string compatibilityStatus, string totalPrice);


        [OperationContract(Name = "FetchAllUserBuildsSOAP")]
        List<BuildClass> FetchAllUserBuilds(string user_id);




        [OperationContract(Name = "FetchUserAddressSOAP")]
        DeliveryAddress FetchUserAddress(string userId);


        [OperationContract(Name = "FetchOrderSOAP")]
        OrderClass FetchOrder(string userId, string orderId, string cardNumber);


        [OperationContract(Name = "FetchOrderByIdSOAP")]
        Order FetchOrderById(string orderId);


        [OperationContract(Name = "FetchCaseCompatibilitySOAP")]
        Compatibility FetchCaseCompatibility(string componentId);



        [OperationContract(Name = "FetchAllUserOrdersSOAP")]
        List<Order> FetchAllUserOrders(string userId);


        [OperationContract(Name = "FetchAllOrdersSOAP")]
        List<Order> FetchAllOrders(string filter);



        [OperationContract(Name = "CheckoutOrderSOAP")]
        int CheckoutOrder(string userId, string orderId, string cardId, string paymentId,
                                 string userAddressId, string totalPrice, string totalItems, string paymentMade,
                                 string orderStatus, List<int> listOfCartItemId);



        [OperationContract(Name = "SaveCartSOAP")]
        int SaveCart(string userId, string buildId, string totalPrice, string discountSaved);


        [OperationContract(Name = "SaveCartItemsSOAP")]
        int SaveCartItems(string componentId, string cartId, string quantity);


        [OperationContract(Name = "SaveOrderSOAP")]
        int SaveOrder(string cartId, string userAddressId, string userId);



    }
}
