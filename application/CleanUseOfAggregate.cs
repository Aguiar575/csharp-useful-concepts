//we can create a value object to hold some values but
//THIS PRODUCT CLASS IS JUST A PIECE OF CRAP IMPL
//WE ONLY NEED TO CREATE AGGREGATES WHEN WE NEED CONSISTENCY IN OUR DATA
public class Product
{
    public Product(
        string productName,
        ProductPrice productPrice)
    {
        ProductName = productName;
        SetPrice(productPrice);
    }

    public string ProductName { get; private set; }
    public decimal ProductPrice { get; set; }

    public void SetPrice(ProductPrice productPrice)
    {
        ProductPrice = productPrice;
    }
}

public class ProductPrice
{
    private decimal Value { get; }

    public ProductPrice(decimal price)
    {
        if (price <= 0)
            throw new Exception("Product price cannot bem zero or less");

        Value = price;
    }

    public static implicit operator decimal(ProductPrice price)
    {
        return price.Value;
    }
}

//HERE IS A MORE REALISTIC USE OF AN AGGREGATE TO KEEP CONSISTENCY
public class Order
{
    public readonly IEnumerable<OrderItem> _orderItems;

    public Order() => _orderItems = new HashSet<OrderItem>();

    public static int Id { get; private set; }

    public void AddOrderItem(OrderItem orderItem)
    {
        OrderItem? existingOrder = _orderItems.Where(e => e.ProductId == orderItem.ProductId).SingleOrDefault();

        if (existingOrder != null)
        {
            existingOrder.SpecificActionFromContextOfOrderItem();
        }
        else
        {
            _orderItems.Append(orderItem);
        }
    }
}

public class OrderItem
{
    private decimal _productPrice;

    public int ProductId { get; set; }
    public decimal ProductPrice
    {
        get { return _productPrice; }
        set
        {
            if (value <= 0)
                throw new Exception("Product price cannot bem zero or less");

            _productPrice = value;
        }
    }

    public void SpecificActionFromContextOfOrderItem() { }
}