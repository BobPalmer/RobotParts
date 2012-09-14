namespace Invoicing.Model
{
    public struct PaymentSchedule
    {
        public decimal UpfrontDue { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal FinalPayment { get; set; }
        public decimal GiftCardBalance { get; set; }
        public decimal CreditBalance { get; set; }
    }
}