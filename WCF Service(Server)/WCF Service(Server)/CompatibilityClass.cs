using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service_Server_
{
    public class CompatibilityClass
    {
        string buildCompatibility;
        string baseId;
        string ramType;
        string cpuType;
        string storageType;
        string graphicsType;

        public CompatibilityClass() { }

        public CompatibilityClass(string buildCompatibility, string baseId, string ramType, string cpuType, string storageType, string graphicsType)
        {
            this.BuildCompatibility = buildCompatibility;
            this.BaseId = baseId;
            this.RamType = ramType;
            this.CpuType = cpuType;
            this.StorageType = storageType;
            this.GraphicsType = graphicsType;
        }

        public string BuildCompatibility { get => buildCompatibility; set => buildCompatibility = value; }
        public string BaseId { get => baseId; set => baseId = value; }
        public string RamType { get => ramType; set => ramType = value; }
        public string CpuType { get => cpuType; set => cpuType = value; }
        public string StorageType { get => storageType; set => storageType = value; }
        public string GraphicsType { get => graphicsType; set => graphicsType = value; }
    }
}