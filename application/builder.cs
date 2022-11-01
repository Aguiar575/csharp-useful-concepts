namespace csharpUsefulConcepts.builder;

public class OrderBuilder
{
    private ICollection<OrderServiceLines> orderServiceLines 
        = new HashSet<OrderServiceLines>();
    private string name = "Default";
    private decimal discount = 0;  

    public OrderBuilder WithDiscount(decimal discount)
    {
        this.discount = discount;
        return this;
    }

    public OrderBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public OrderBuilder WithServiceLine(OrderServiceLines serviceLines)
    {
        orderServiceLines.Add(serviceLines);
        return this;
    }

    public Order Build() => 
        new Order(orderServiceLines, discount, name);
}

public class Order
{
    public Order(ICollection<OrderServiceLines> OrderServiceLines,
                    decimal discount,
                    string name)
    {
        this.CustomerSericeLines = OrderServiceLines;
        Discount = discount;
        Name = name;
    }

    public string Name { get; set; }
    public decimal Discount { get; set; }
    public ICollection<OrderServiceLines> CustomerSericeLines { get; set; }
}

public class OrderServiceLines
{
    public OrderServiceLines(string code) =>
        Code = code;

    public string Code { get; private set; }
}

