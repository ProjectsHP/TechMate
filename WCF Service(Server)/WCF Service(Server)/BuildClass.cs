using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service_Server_
{
    public class BuildClass
    {

        string build_id;
        string user_build_id;
        string category;
        string totalPrice;
        string compatibilityStatus;
        Component ramComponent;
        Component cpuComponent;
        Component graphicsComponent;
        Component storageComponent;
        Component baseCaseComponent;


        public BuildClass() { }

        public BuildClass(string build_id, string user_build, string category, string compatibilityStatus)
        {
            this.build_id = build_id;
            this.User_build_id = user_build;
            this.category = category;
            this.compatibilityStatus = compatibilityStatus;
        }


        public string Build_id { get => build_id; set => build_id = value; }
        public string Category { get => category; set => category = value; }
        public string CompatibilityStatus { get => compatibilityStatus; set => compatibilityStatus = value; }


        public Component RamComponent { get => ramComponent; set => ramComponent = value; }
        public Component CpuComponent { get => cpuComponent; set => cpuComponent = value; }
        public Component GraphicsComponent { get => graphicsComponent; set => graphicsComponent = value; }
        public Component StorageComponent { get => storageComponent; set => storageComponent = value; }
        public Component BaseCaseComponent { get => baseCaseComponent; set => baseCaseComponent = value; }
        public string User_build_id { get => user_build_id; set => user_build_id = value; }
        public string TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}