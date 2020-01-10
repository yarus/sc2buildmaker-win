using System;
using System.Collections.Generic;

namespace SC2.PublicData
{
    [Serializable]
    public class NameValueInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public List<NameValueInfo> ChildInfos { get; set; }

        public NameValueInfo()
        {
            this.ChildInfos = new List<NameValueInfo>();
        }
    }
}