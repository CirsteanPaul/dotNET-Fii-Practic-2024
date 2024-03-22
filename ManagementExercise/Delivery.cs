namespace ManagementExercise;

public sealed class Delivery
{
    public int Id { get; set; }
    public List<CheckoutItem> CheckoutItems { get; set; } = new();
    public string CustomerName { get; set; } = string.Empty;
    public string DeliverymanName { get; set; } = string.Empty;
    public bool IsDelivered { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeliveredAt { get; set; }
}