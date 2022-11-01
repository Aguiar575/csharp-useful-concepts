using csharpUsefulConcepts.builder;

namespace Test.Builder;

public class BuilderTests 
{
    [Fact]
    public void ShouldReturnOrderWithAnotherName()
    {
        var order = new OrderBuilder().WithName("Bob").Build();
        Assert.Equal("Bob", order.Name);
    }

    [Fact]
    public void ShouldReturnOrderWithAnotherDiscount()
    {
        var order = new OrderBuilder().WithDiscount(23.0m).Build();
        Assert.Equal(23.0m, order.Discount);
    }

    [Fact]
    public void ShouldReturnOrderWithOrderServiceLines()
    {
        var order = new OrderBuilder()
        .WithServiceLine(new OrderServiceLines("CD33"))
        .Build();

        Assert.Equal("CD33", order.CustomerSericeLines.First().Code);
    }

    [Fact]
    public void ShouldReturnOrderWithDefaultValues()
    {
        var order = new OrderBuilder().Build();
        
        Assert.True(!order.CustomerSericeLines.Any());
        Assert.Equal("Default", order.Name);
        Assert.Equal(0, order.Discount);
    }
}