using Dolphin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Services
{
    public abstract class ServiceBase
    {
        protected IDataContext Context { get; private set; }

        internal ServiceBase(IDataContext context)
        {
            Context = context;
        }
    }
}
