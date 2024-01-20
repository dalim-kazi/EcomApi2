using System.ComponentModel.DataAnnotations;

namespace EcomApi2.Models.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string? CouponCode { get; set; }
        public double discountAmount { get; set; }
        public int minAmount { get; set; }
        public double totalAmount { get; set; }
    }
}
