using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Model;
using Invoicing.Repository;

namespace Invoicing.Tasks
{
    public class PartsTasks
    {
        private IPartsRepository _partsRepo;
        private const int MAX_SEARCH_RESULTS = 20;

        public PartsTasks(IPartsRepository partsRepo)
        {
            _partsRepo = partsRepo;
        }

        public IList<Part>SearchParts(string term)
        {
            var results = _partsRepo.SearchParts(term, MAX_SEARCH_RESULTS);
            return results;
        }

        public Part GetPartById(int id)
        {
            return _partsRepo.Get(id);
        }

        public Part GetPartByName(string name)
        {
            var part = _partsRepo.GetPartByName(name);
            return part;
        }    
    }
}
