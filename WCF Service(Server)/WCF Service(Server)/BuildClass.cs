using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service_Server_
{
    public class BuildClass
    {

        string build_id;
        string user_build;
        string ram_id;
        string storage_id;
        string graphics_id;
        string cpu_id;
        string category;
        string compatibilityStatus;

        public BuildClass(string build_id, string user_build, string ram_id, string storage_id, string graphics_id, string cpu_id, string category, string compatibilityStatus)
        {
            this.build_id = build_id;
            this.user_build = user_build;
            this.ram_id = ram_id;
            this.storage_id = storage_id;
            this.graphics_id = graphics_id;
            this.cpu_id = cpu_id;
            this.category = category;
            this.compatibilityStatus = compatibilityStatus;
        }

        public string Build_id { get => build_id; set => build_id = value; }
        public string User_build { get => user_build; set => user_build = value; }
        public string Ram_id { get => ram_id; set => ram_id = value; }
        public string Storage_id { get => storage_id; set => storage_id = value; }
        public string Graphics_id { get => graphics_id; set => graphics_id = value; }
        public string Cpu_id { get => cpu_id; set => cpu_id = value; }
        public string Category { get => category; set => category = value; }
        public string CompatibilityStatus { get => compatibilityStatus; set => compatibilityStatus = value; }
    }
}