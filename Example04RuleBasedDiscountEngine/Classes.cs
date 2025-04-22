namespace Example04RuleBasedDiscountEngine;

public interface IDiscountRule
{
    bool IsApplicable(Order order);
    decimal CalculateDiscount(decimal amount);
    string Description { get; }
}

public class Order
{
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public string CouponCode { get; set; }
    
    public decimal Subtotal => Items.Sum(item => item.Price * item.Quantity);
}

public class OrderItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
}

public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int LoyaltyPoints { get; set; }
    public DateTime MemberSince { get; set; }
}

// Concrete discount rules
public class SeasonalDiscountRule : IDiscountRule
{
    public bool IsApplicable(Order order)
    {
        // Check if current date is within seasonal promotion period
        return order.OrderDate.Month == 12; // December promotion
    }
    
    public decimal CalculateDiscount(decimal amount)
    {
        return amount * 0.1m; // 10% off
    }
    
    public string Description => "10% Seasonal Discount";
}

public class LoyaltyDiscountRule : IDiscountRule
{
    public bool IsApplicable(Order order)
    {
        // Check if customer has enough loyalty points
        return order.Customer.LoyaltyPoints >= 100;
    }
    
    public decimal CalculateDiscount(decimal amount)
    {
        return 5.0m; // $5 off
    }
    
    public string Description => "$5 Loyalty Discount";
}

public class BulkPurchaseDiscountRule : IDiscountRule
{
    public bool IsApplicable(Order order)
    {
        // Check if total quantity is above threshold
        return order.Items.Sum(item => item.Quantity) >= 10;
    }
    
    public decimal CalculateDiscount(decimal amount)
    {
        return amount * 0.05m; // 5% off
    }
    
    public string Description => "5% Bulk Purchase Discount";
}

public class CouponDiscountRule : IDiscountRule
{
    public bool IsApplicable(Order order)
    {
        return !string.IsNullOrEmpty(order.CouponCode) && order.CouponCode == "SAVE15";
    }
    
    public decimal CalculateDiscount(decimal amount)
    {
        return amount * 0.15m; // 15% off
    }
    
    public string Description => "15% Coupon Discount";
}

// Discount calculator service
public class DiscountCalculator
{
    private readonly List<IDiscountRule> _discountRules =
    [
        new SeasonalDiscountRule(),
        new LoyaltyDiscountRule(),
        new BulkPurchaseDiscountRule(),
        new CouponDiscountRule()
    ];
    
    public (decimal FinalPrice, List<string> AppliedDiscounts) CalculateDiscount(Order order)
    {
        decimal subtotal = order.Subtotal;
        decimal totalDiscount = 0;
        var appliedDiscounts = new List<string>();
        
        foreach (var rule in _discountRules)
        {
            if (rule.IsApplicable(order))
            {
                decimal discount = rule.CalculateDiscount(subtotal);
                totalDiscount += discount;
                appliedDiscounts.Add($"{rule.Description} (-${discount})");
            }
        }
        
        return (subtotal - totalDiscount, appliedDiscounts);
    }
}
