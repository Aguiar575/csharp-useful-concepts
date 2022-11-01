namespace Events;
//Events is a pub-sup relationship

public class PriceChangedEventArgs : EventArgs
{
    public readonly decimal LastPrice, NewPrice;

    public PriceChangedEventArgs(
        decimal lastPrice,
        decimal newPrice)
    {
        LastPrice = lastPrice;
        NewPrice = newPrice;
    }
}

public class Stock
{
    string _symbol;
    decimal _price;

    public Stock(string symbol) => _symbol = symbol;

    private event EventHandler<PriceChangedEventArgs> priceChanged;
    public event EventHandler<PriceChangedEventArgs> PriceChanged
    {
        add { priceChanged += value; }
        remove { priceChanged -= value; }
    }

    protected virtual void OnPriceChanged(PriceChangedEventArgs e) =>
        priceChanged?.Invoke(this, e);

    public decimal Price
    {
        get { return _price; }
        set
        {
            if (_price == value) return;
            OnPriceChanged(new PriceChangedEventArgs(_price, value));
            Price = _price;
        }
    }
}

public static class StockPrice
{
    public static void StockPriceChanged(Object sender, PriceChangedEventArgs e)
    {
        if (e.NewPrice > e.LastPrice)
            Console.WriteLine("Price increase");
    }
}