using InterviewPracticeApi.Models;

namespace InterviewPracticeApi.Services;

public class OrderService
{
    private static readonly List<Order> Orders = new();
    private static int _nextId = 1;

    public List<Order> GetAll()
    {
        return Orders;
    }

    public Order? GetById(int id)
    {
        return Orders.FirstOrDefault(x => x.Id == id);
    }

    public Order Create(Order order)
    {
        if (string.IsNullOrWhiteSpace(order.CustomerName))
            throw new ArgumentException("CustomerName is required.");

        if (string.IsNullOrWhiteSpace(order.ProductName))
            throw new ArgumentException("ProductName is required.");

        if (order.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        order.Id = _nextId++;
        order.CreatedAtUtc = DateTime.UtcNow;

        Orders.Add(order);
        return order;
    }

    public bool Delete(int id)
    {
        var existing = Orders.FirstOrDefault(x => x.Id == id);
        if (existing is null)
            return false;

        Orders.Remove(existing);
        return true;
    }
}