using System;
using System.Collections.Generic;
using System.Linq;

namespace SC2.PublicData
{
    [Serializable]
    public class ItemWithAttributesInfo
    {
        public string Name { get; set; }
        public List<NameValueInfo> Attributes { get; set; }

        public List<ItemWithAttributesInfo> ChildItems { get; set; } 

        public ItemWithAttributesInfo()
        {
            this.Attributes = new List<NameValueInfo>();
            this.ChildItems = new List<ItemWithAttributesInfo>();
        }

        public string ReadStringAttribute(string attributeName)
        {
            var attr = this.Attributes.FirstOrDefault(p => p.Name == attributeName);

            return attr != null ? attr.Value : string.Empty;
        }

        public int? ReadIntAttribute(string attributeName)
        {
            var strValue = this.ReadStringAttribute(attributeName);

            int intValue = int.MinValue;
            if (!string.IsNullOrEmpty(strValue))
            {
                int.TryParse(strValue, out intValue);
            }

            return intValue != int.MinValue ? intValue : (int?)null;
        }
    }
}