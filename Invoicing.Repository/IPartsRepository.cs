using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormouse.Core.Repository;
using Invoicing.Model;

namespace Invoicing.Repository
{
    public interface IPartsRepository : IRepositorySearch<Part>, IRepositoryCRUD<Part,Int32>
    {
        IList<Part> SearchParts(string term, int maxResults);
        Part GetPartByName(string name);
    }
}
