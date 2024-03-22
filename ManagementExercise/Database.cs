namespace ManagementExercise;

public sealed class Database
{
    public List<Customer> Customers { get; private set; } = new();
    public List<Delivery> Deliveries { get; private set; } = new();
    public List<Deliveryman> Deliverymen { get; private set; } = new();


    public Database()
    {
        AddCustomers(); 
        AddDeliverymen();
    }
    
    public bool DeleteItem<T>(T item) 
    {
        return item switch
        {
            Customer customer => Customers.Remove(customer),
            Delivery delivery => Deliveries.Remove(delivery),
            Deliveryman deliveryman => Deliverymen.Remove(deliveryman),
            _ => false
        };
    }

    public bool AddItem<T>(T item)
    {
        switch (item)
        {
            case Customer customer:
                Customers.Add(customer);
                return true;
            case Delivery delivery:
                Deliveries.Add(delivery);
                return true;
            case Deliveryman deliveryman:
                Deliverymen.Add(deliveryman);
                return true;
            default:
                return false;
        }
    }

    public bool UpdateItem<T, K>(T item, K key)
    {
        switch (item)
        {
            case Customer customer:
                if (key is not string)
                {
                    return false;
                }
                var existingCustomer = Customers.FirstOrDefault(c => c.Name == key.ToString());
                if (existingCustomer is null)
                {
                    return false;
                }

                existingCustomer = customer;
                return true;
            case Delivery delivery:
                if (key is not int)
                {
                    return false;
                }

                var id = Convert.ToInt32(key);
                var existingDelivery = Deliveries.FirstOrDefault(c => c.Id == id);
                if (existingDelivery is null)
                {
                    return false;
                }

                existingDelivery = delivery;
                return true;
            case Deliveryman deliveryman:
                if (key is not int)
                {
                    return false;
                }

                var manId = Convert.ToInt32(key);
                var existingDeliveryman = Deliverymen.FirstOrDefault(c => c.Name == deliveryman.ToString());
                if (existingDeliveryman is null)
                {
                    return false;
                }

                existingDeliveryman = deliveryman;
                return true;
            default:
                return false;
        }
    }

    private void AddCustomers()
    {
        Customers.Add(new Customer()
        {
            Name = "Paul",
            Password = "1234",
            Email = "ceva@gmail.com",
            ShippingAddress = "Fii"
        });
        
        Customers.Add(new Customer()
        {
            Name = "Marcel",
            Password = "1234",
            Email = "ceva2@gmail.com",
            ShippingAddress = "Fii2"
        });
    }

    private void AddDeliverymen()
    {
        Deliverymen.Add(new Deliveryman()
        {
            Name = "Marcel",
            Password = "1234",
            Email = "delivery@gmail.com",
            CarId = 1,
            CarName = "Mazda"
        });
        
        Deliverymen.Add(new Deliveryman()
        {
            Name = "Marcel",
            Password = "1234",
            Email = "delivery2@gmail.com",
            CarId = 2,
            CarName = "Toyota",
        });
    }

    public void PrintDb()
    {
        foreach (var customer in Customers)
        {
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Password: {customer.Password}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"ShippingAddress: {customer.ShippingAddress}");
            Console.WriteLine();
        }
        
        
        foreach (var deliveryman  in Deliverymen)
        {
            Console.WriteLine($"Name: {deliveryman.Name}");
            Console.WriteLine($"Password: {deliveryman.Password}");
            Console.WriteLine($"Email: {deliveryman.Email}");
            Console.WriteLine($"CarId: {deliveryman.CarId}");
            Console.WriteLine($"CarName: {deliveryman.CarName}");
            Console.WriteLine();
        }
        
        
        foreach (var delivery in Deliveries)
        {
            Console.WriteLine($"Id: {delivery.Id}");
            Console.WriteLine($"CreatedAt: {delivery.CreatedAt}");
            Console.WriteLine($"CustomerName: {delivery.CustomerName}");
            Console.WriteLine($"IsDelivered: {delivery.IsDelivered}");
            Console.WriteLine($"DeliveredAt: {delivery.DeliveredAt}");
            Console.WriteLine();
        }
    }
}