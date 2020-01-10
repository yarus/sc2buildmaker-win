using System.Collections.Generic;
using System.Linq;

namespace SC2.Entities.BuildItems
{
    public class BuildItemsDictionary
    {
        private readonly Dictionary<string, BuildItemEntity> mDictionary;

        public BuildItemsDictionary() : this(new Dictionary<string, BuildItemEntity>())
        {
        }

        public BuildItemsDictionary(Dictionary<string, BuildItemEntity> dictionary)
        {
            this.mDictionary = dictionary;
        }

        public void AddItem(BuildItemEntity item)
        {
            this.mDictionary[item.Name] = item;
        }

        public BuildItemEntity GetItem(string name)
        {
            return this.mDictionary.ContainsKey(name) ? this.mDictionary[name] : null;
        }

        public IDictionary<string, BuildItemEntity> Clone()
        {
            return new Dictionary<string, BuildItemEntity>(this.mDictionary);
        }

        public BuildItemEntity DefaultBuidlItem
        {
            get
            {
                return this.GetItem(Consts.DefaultStateItemName);
            }
        }

        public List<BuildItemEntity> GetList()
        {
            return mDictionary.Select(buildItemEntity => buildItemEntity.Value).ToList();
        }
    }
}
