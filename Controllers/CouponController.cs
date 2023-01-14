using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class CouponController : ControllerBase
{
    private readonly PromotionsContext _promotionsContext;

    public CouponController(PromotionsContext promotionsContext)
    {
        _promotionsContext = promotionsContext;
    }

    [HttpGet]
    public IEnumerable<Coupon> GetAll()
    {
        return _promotionsContext
            .Coupons
            .AsNoTracking()
            .AsEnumerable();
    }

}