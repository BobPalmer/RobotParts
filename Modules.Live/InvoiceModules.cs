using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Persistance;
using Invoicing.Repository;
using Invoicing.TestHelpers;
using Ninject.Modules;

namespace Modules.Live
{
    public class InvoiceModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IPartsRepository>().To<PartsRepository>();
        }
    }
}
