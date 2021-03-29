using System.Configuration;

namespace Trade.Core.Configuration
{
    [ConfigurationCollection(typeof(CategoryElement))]
    public class CategoryElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CategoryElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CategoryElement)element).Name;
        }
        internal CategoryElement GetByName(string name)
        {
            CategoryElement element = null;

            foreach (CategoryElement item in this)
            {
                if (item.Name == name)
                {
                    element = item;
                    break;
                }
            }

            return element;
        }

        internal CategoryElement this[int index]
        {
            get { return (CategoryElement)this.BaseGet(index); }
        }
    }

}
