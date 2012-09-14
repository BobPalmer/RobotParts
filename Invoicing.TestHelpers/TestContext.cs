using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Tasks;

namespace Invoicing.TestHelpers
{
    public static class DefaultContext
    {
        private static PartsTasks _parts;
        private static FinanceTasks _finance;
        private static FakePartsRepository _repo = new FakePartsRepository();

        public static PartsTasks PartsTask { get { return _parts ?? (_parts = new PartsTasks(_repo)); } }
        public static FinanceTasks FinanceTask { get { return _finance ?? (_finance = new FinanceTasks(_repo)); } }
    }
}
