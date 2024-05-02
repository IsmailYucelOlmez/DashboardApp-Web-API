namespace DashboardApp.DTO.Customer
{
    public class CustomerDto
    {
        public int ID { get; set; }
        public string CName { get; set; } = null!;
        public string? Cmail { get; set; }
        public string? CPhone { get; set; } = null!;
        public decimal? CBudget { get; set; }
        public byte[]? CImage { get; set; }
        public string? CStatu { get; set; }
        public string? CLocation { get; set; }

    }
}
