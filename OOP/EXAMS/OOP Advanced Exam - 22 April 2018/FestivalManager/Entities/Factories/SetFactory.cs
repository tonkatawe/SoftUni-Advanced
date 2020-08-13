using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            ISet set = null;
            if (type == "Short")
            {
                set = new Short(name);
            }
            else if (type == "Medium")
            {
                set = new Medium(name);
            }
            else if (type == "Long")
            {
                set = new Long(name);
            }

            return set;
        }
    }




}
