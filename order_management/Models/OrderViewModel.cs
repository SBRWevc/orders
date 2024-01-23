using Microsoft.AspNetCore.Mvc.Rendering;

namespace test_task.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public double Weight { get; set; }
        public string Weight_Measure { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
