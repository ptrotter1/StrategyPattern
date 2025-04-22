using Example04RuleBasedDiscountEngine;

var order = new Order
{
    Customer = new Customer { Id = "C123", Name = "John Doe", LoyaltyPoints = 150, MemberSince = new DateTime(2020, 1, 1) },
    OrderDate = new DateTime(2023, 12, 15),
    CouponCode = "SAVE15",
    Items = new List<OrderItem>
    {
        new OrderItem { ProductId = "P1", ProductName = "Product 1", Price = 20.0m, Quantity = 5, Category = "Electronics" },
        new OrderItem { ProductId = "P2", ProductName = "Product 2", Price = 15.0m, Quantity = 6, Category = "Books" }
    }
};

var calculator = new DiscountCalculator();
var (finalPrice, appliedDiscounts) = calculator.CalculateDiscount(order);

decimal subtotal = order.Subtotal;

Console.WriteLine($"Subtotal: ${subtotal}");
Console.WriteLine("Applied discounts:");
foreach (var discount in appliedDiscounts)
{
    Console.WriteLine($"- {discount}");
}
Console.WriteLine($"Final price: ${finalPrice}");
