using Xunit;
using ShoppingModel;

namespace ShoppingTest;

public class AddCustomerTest
{
    [Fact]
    public void AddCustomer()
    {
        //Arrange
        Customer testName = new Customer();
        string testNameVar = "Joseph";

        //Act
        testName.CustomerName = testNameVar;

        //Assert
        Assert.NotNull(testName.CustomerName);
        Assert.Equal(testNameVar, testName.CustomerName);
    }
}