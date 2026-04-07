using System.Collections.Concurrent;
using System.Threading;
using InterviewPracticeApi.Models;

namespace InterviewPracticeApi.Services;

public class OrderService
{
    private readonly ConcurrentDictionary<int, Order> _orders = new();
    private int _nextId = 0;

    public IReadOnlyList<Order> GetAll()
    {
        return _orders.Values
            .OrderBy(x => x.Id)
            .ToList();
    }

    public Order? GetById(int id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }

    public Order Create(Order order)
    {
        if (string.IsNullOrWhiteSpace(order.CustomerName))
            throw new ArgumentException("CustomerName is required.");

        if (string.IsNullOrWhiteSpace(order.ProductName))
            throw new ArgumentException("ProductName is required.");

        if (order.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var id = Interlocked.Increment(ref _nextId);

        var newOrder = new Order
        {
            Id = id,
            CustomerName = order.CustomerName,
            ProductName = order.ProductName,
            Amount = order.Amount,
            CreatedAtUtc = DateTime.UtcNow
        };

        if (!_orders.TryAdd(newOrder.Id, newOrder))
            throw new InvalidOperationException("Failed to add order.");

        return newOrder;
    }

    public bool Delete(int id)
    {
        return _orders.TryRemove(id, out _);
    }
}