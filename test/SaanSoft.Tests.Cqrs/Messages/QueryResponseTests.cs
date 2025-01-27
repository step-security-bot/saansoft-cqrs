namespace SaanSoft.Tests.Cqrs.Messages;

public class QueryResponseTests
{
    [Fact]
    public void Empty_constructor_is_successful_result()
    {
        var result = new QueryResponse();
        result.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [AutoFakeData]
    public void Constructor_with_error_message_is_failure_result(string errorMessage)
    {
        var result = new QueryResponse(errorMessage);
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Be(errorMessage);
    }
}
