using Quipex.Domain.Entities;
using Quipex.Domain.Exceptions;
using System.Xml.Linq;

namespace Quipex.Tests.Domain;

public class CompanyRecordTests
{
    [Theory]
    [InlineData("US1234567890")]
    [InlineData("!@1234567890")]
    [InlineData("!@123slt7890")]
    [InlineData("!@1d2k4^9F7%")]
    public void Constructor_ShouldCreate_WhenISINIsValid(string Isin)
    {
        // Arrange
        var name = "";
        var stockTicker = "";
        var exchange = "";
        string? website = null;

        // Act
        var exception = Record.Exception(() =>
        {
            var companyRecord = new CompanyRecord(name, stockTicker, exchange, Isin, website);
            Assert.NotNull(companyRecord);
        });

        // Assert
        Assert.Null(exception);

    }

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("901d2k4^9F7%")]
    [InlineData("1S3456789012")]
    [InlineData("S13456789012")]
    public void Constructor_ShouldThrow_WhenISINIsInvalid(string Isin)
    {
        // Arrange
        var name = "";
        var stockTicker = "";
        var exchange = "";
        string? website = null;
        var expectedExceptionMsg = $"'{Isin}' is not a valid ISIN. ISIN must not start with 2 numbers and must be 12 characters long.";

        // Act & Assert
        var exception = Assert.Throws<InvalidCompanyRecordISINException>(() =>
        {
            var companyRecord = new CompanyRecord(name, stockTicker, exchange, Isin, website);
        });

        Assert.Equal(expectedExceptionMsg, exception.Message);

    }
}