namespace Invoicing.Model
{
    public struct PaymentData
    {
        public decimal CreditAmount { get; set; }
        public decimal GiftCardAmount { get; set; }
        public decimal APR { get; set; }
        public int Terms { get; set; }
        public PartData[] Parts { get; set; }
        public decimal UpfrontTotal { get; set; }
        public decimal FinancedTotal { get; set; }
    }
}