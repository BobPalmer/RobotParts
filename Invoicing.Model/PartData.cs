namespace Invoicing.Model
{
    public struct PartData
    {
        public string PartName { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UpfrontPercent { get; set; }
        public decimal UpfrontAmount { get; set; }
        public decimal FinancedAmount { get; set; }
    }
}