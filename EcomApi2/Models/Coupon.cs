using System.ComponentModel.DataAnnotations;

namespace EcomApi2.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string? CouponCode { get; set; }
        [Required]
        public double discountAmount { get; set; }
        public int minAmount { get; set; }
    }
}
