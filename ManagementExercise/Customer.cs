namespace ManagementExercise;

public sealed class Customer : User
{
    public string ShippingAddress { get; set; } = string.Empty;
    public List<CheckoutItem> CheckoutItems { get; set; } = new();
}