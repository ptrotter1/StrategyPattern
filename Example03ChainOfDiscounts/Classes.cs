namespace Example03ChainOfDiscounts;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal amount);
}

// Concrete discount strategies
public class SeasonalDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        return amount * 0.9m; // 10% seasonal discount
    }
}

public class LoyaltyDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        return amount - 5.0m; // $5 off for loyalty
    }
}

public class CouponDiscount : IDiscountStrategy
{
    private readonly string _couponCode;

    public CouponDiscount(string couponCode)
    {
        _couponCode = couponCode;
    }

    public decimal ApplyDiscount(decimal amount)
    {
        // Logic to validate coupon code
        if (_couponCode == "SAVE15")
            return amount * 0.85m; // 15% off
    
        return amount;
    }
}

// Composite discount strategy that chains multiple discounts
public class CompositeDiscountStrategy : IDiscountStrategy
{
    private readonly List<IDiscountStrategy> _discountStrategies = new();

    public void AddDiscountStrategy(IDiscountStrategy discountStrategy)
    {
        _discountStrategies.Add(discountStrategy);
    }

    public decimal ApplyDiscount(decimal amount)
    {
        decimal discountedAmount = amount;
    
        foreach (var strategy in _discountStrategies)
        {
            discountedAmount = strategy.ApplyDiscount(discountedAmount);
        }
    
        return discountedAmount;
    }
}

// Order service that uses the composite discount strategy
public class OrderService
{
    private readonly CompositeDiscountStrategy _discountStrategy = new();

    public void AddDiscountStrategy(IDiscountStrategy discountStrategy)
    {
        _discountStrategy.AddDiscountStrategy(discountStrategy);
    }

    public decimal CalculateFinalPrice(decimal originalPrice)
    {
        return _discountStrategy.ApplyDiscount(originalPrice);
    }
}
