using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Model;
using Invoicing.Repository;

namespace Invoicing.Tasks
{
    public class PaymentTasks
    {
        private IPartsRepository _partsRepo;
        private FinanceTasks _finance;

        public PaymentTasks(IPartsRepository partsRepo)
        {
            _partsRepo = partsRepo;
            _finance = new FinanceTasks(partsRepo);
        }

        public PaymentSchedule CalculatePaymentSchedule(PaymentData data)
        {
            var order = data;
            for(int i = 0; i < order.Parts.Count(); i++)
            {
                var part = data.Parts[i];
                part = _finance.LoadLineData(part);
                part = _finance.CalculateLineTotals(part);
                order.Parts[i] = part;
            }

            order = _finance.CombineLineData(order);
            order = _finance.ApplyGiftCertificate(order);
            order = _finance.ApplyCredit(order);
            var schedule = _finance.GeneratePaymentSchedule(order);
            return schedule;
        }
    }
}
