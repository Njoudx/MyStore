namespace MyStore.Models
{
    public class Compatibility
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }

    }
}