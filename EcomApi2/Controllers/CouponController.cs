using EcomApi2.Data;
using EcomApi2.Models;
using EcomApi2.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponceDto _responceDto;

        public CouponController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responceDto = new ResponceDto();
        }
        [HttpGet]
        public ResponceDto Get() {
            try
            {
                IEnumerable<Coupon> couponList = _db.Coupones2.ToList();
                _responceDto.Result = couponList;
                _responceDto.Massage = "successfull";
            }
            catch (Exception ex) {
                _responceDto.Massage += ex.Message;
                _responceDto.IsSuccess = false;
            }
            return _responceDto;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponceDto Get(int id) {
            try
            {
              Coupon coupon =_db.Coupones2.First(x=>x.CouponId == id);
               CouponDto couponDto= new CouponDto();
                {
                   couponDto.CouponId=coupon.CouponId;
                   couponDto.CouponCode=coupon.CouponCode;
                    couponDto.discountAmount = coupon.discountAmount; 
                    couponDto.minAmount = coupon.minAmount;
                    couponDto.totalAmount=coupon.discountAmount + coupon.minAmount;
                }
                _responceDto.Result= couponDto;
            }
            catch(Exception ex)
            {
             _responceDto.Massage=ex.Message;
                _responceDto.IsSuccess=false;
            }
            return _responceDto;
        }
        [HttpPost]
        public ResponceDto post([FromBody]CouponDto xyz)
        {
            try
            {
                 Coupon coupon=new Coupon();
                {
                  coupon.CouponCode=xyz.CouponCode;
                  coupon.discountAmount=xyz.discountAmount;
                  coupon.minAmount=xyz.minAmount;
                }
                _db.Coupones2.Add(coupon);
                _db.SaveChanges();
                _responceDto.Result = xyz;

            }
            catch(Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.IsSuccess=false;
            }
            return _responceDto;
        }
        [HttpPut]
        public object put([FromBody] CouponDto xyz) {
            {
                try
                {
                    Coupon coupon = new Coupon();
                    {  
                        coupon.CouponId=xyz.CouponId;
                        coupon.CouponCode = xyz.CouponCode;
                        coupon.discountAmount = xyz.discountAmount;
                        coupon.minAmount = xyz.minAmount;
                    }
                    _db.Coupones2.Update(coupon);
                    _db.SaveChanges();
                    _responceDto.Result = xyz;

                }
                catch (Exception ex)
                {
                    _responceDto.Massage = ex.Message;
                    _responceDto.IsSuccess = false;
                }
                return _responceDto;
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public object delete(int id)
        {
            try 
            {
                Coupon coupon = _db.Coupones2.First(x => x.CouponId == id);
                _db.Coupones2.Remove(coupon);
                _db.SaveChanges();
                _responceDto.Massage= $"Coupon deleted successfully by {id} Id";
            }
            catch (Exception ex){ 
                _responceDto.Massage=ex.Message;
                _responceDto.IsSuccess=false;
            }
            return _responceDto;
        }
    }
}
