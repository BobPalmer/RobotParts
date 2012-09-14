using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dormouse.Core.Repository;
using Dormouse.Core.Search;
using Invoicing.Model;
using Invoicing.Repository;

namespace Invoicing.Persistance
{
    public class PartsRepository : RepositorySearch<Part,Int32>, IPartsRepository
    {
        public IList<Part> SearchParts(string term, int maxResults)
        {
            var crit = new AdvancedSearchCriteria();
            if (!String.IsNullOrEmpty(term))
            {
                crit.SearchFilter.Add(new SearchCriteria { Compare = ComparisonType.LikeStartWith, Value = term, PropertyName = "PartName" });
            }
            crit.TotalRecords = maxResults;
            var parts = Search(crit);
            return parts;
        }


        public Part GetPartByName(string name)
        {
            var crit = new SearchCriteria {Compare = ComparisonType.Equals, PropertyName = "PartName", Value = name};
            var part = Search(crit).FirstOrDefault();
            return part;
        }
    }
}
