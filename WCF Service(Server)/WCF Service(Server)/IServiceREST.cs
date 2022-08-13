using System;
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
        [WebInvoke(Method = "POST", UriTemplate = "/CreateBuildURI",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CreateBuild(string user_id, string desktop_id, string cpu_id, string storage_id, string graphics_id, string ram_id, string compatibilityStatus);
       
        [OperationContract]
        User FetchActiveUser(string id);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/FetchComponentURI/{component_id}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        Component FetchComponent(string component_id);


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

    }
}
