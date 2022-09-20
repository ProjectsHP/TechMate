using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Service_Server_
{

    [ServiceContract]
    public interface IServiceREST
    {
        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate = "/LoginURI/{email}/{password}",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        UserClass Login(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/RegisterURI",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        int Register(string name, string surname, string cellNo, string gender, string email, string password, string userType);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/EditUserURI",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
       
        int EditUser(string name, string surname, string cellNo, string gender,string email, string activeId);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteUserURI/{activeId}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        int DeleteUser(string activeId);


        /*[WebInvoke(Method = "POST", UriTemplate = "/GetUsersURI",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        */
        List<User> FetchAllUsers();


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/SendEmailURI/{receiverEmail}/{subject}/{body}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        int SendMail(string receiverEmail, string subject, string body);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/CheckoutOrder",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CheckoutOrder(string userId, string orderId, string cardId, string paymentId,
                                 string userAddressId, string totalPrice, string totalItems, string paymentMade,
                                 string orderStatus, List<int> listOfCartItemId);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/StoreUserAddress",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        int StoreUserAddress(string userId, string country, string province, string city, string streetUnit, string name, 
                             string surname, string cellPhone, string email);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/CreateBuildURI",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CreateBuild(string user_id, string desktop_id, string cpu_id, string storage_id, string graphics_id, string ram_id,
                        string compatibilityStatus, string totalPrice);
       

        [OperationContract]
        User FetchActiveUser(string id);

       
        int SaveCart(string userId, string buildId, string totalPrice, string discountSaved);


       
        int SaveCartItems(string componentId, string cartId, string quantity);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchComponentURI/{component_id}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        Component FetchComponent(string component_id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchSingleUserBuildURI/{user_id}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Component> FetchSingleUserBuild(string user_id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchRandomComponentsURI/{size}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Component> FetchRandomComponents(string size);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchTopComponentsURI/{category}/{size}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Component> FetchTopComponents(string category, string size);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchComponentsByCategoryURI/{category}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Component> FetchComponentsByCategory(string category);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchBuildURI/{build_id}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Component> FetchBuild(string build_id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchAllUserBuildsURI/{user_id}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<BuildClass> FetchAllUserBuilds(string user_id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchUserAddress/{userId}",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        DeliveryAddress FetchUserAddress(string userId);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchOrderURI/{userId}/{orderId}/{cardNumber}",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped)]
        OrderClass FetchOrder(string userId, string orderId, string cardNumber);



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchAllUserOrdersURI/{userId}",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Order> FetchAllUserOrders(string userId);


    }
}
