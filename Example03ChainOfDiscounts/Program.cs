using Example03ChainOfDiscounts;

var orderService = new OrderService();

// Add multiple discount strategies
orderService.AddDiscountStrategy(new SeasonalDiscount());
orderService.AddDiscountStrategy(new LoyaltyDiscount());
orderService.AddDiscountStrategy(new CouponDiscount("SAVE15"));
    
var originalPrice = 100.0m;
var finalPrice = orderService.CalculateFinalPrice(originalPrice);
    
Console.WriteLine($"Original price: ${originalPrice}");
Console.WriteLine($"Final price after all discounts: ${finalPrice}");
// Output: Original price: $100
// Final price after all discounts: $71.25
// (100 * 0.9 = 90, 90 - 5 = 85, 85 * 0.85 = 72.25)