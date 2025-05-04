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
    public void Constructor_ShouldCreate_WhenISINIsValid(string isin)
    {
        // Arrange
        var name = "";
        var stockTicker = "";
        var exchange = "";
        string? website = null;

        // Act
        var exception = Record.Exception(() =>
        {
            var companyRecord = new CompanyRecord(name, stockTicker, exchange, isin, website);
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
    public void Constructor_ShouldInvalidCompanyRecordISINException_WhenISINIsInvalid(string isin)
    {
        // Arrange
        var name = "";
        var stockTicker = "";
        var exchange = "";
        string? website = null;
        var expectedExceptionMsg = $"'{isin}' is not a valid ISIN. ISIN must not start with 2 numbers and must be 12 characters long.";

        // Act & Assert
        var exception = Assert.Throws<InvalidCompanyRecordISINException>(() =>
        {
            var companyRecord = new CompanyRecord(name, stockTicker, exchange, isin, website);
        });

        Assert.Equal(expectedExceptionMsg, exception.Message);

    }

    [Theory]
    [InlineData("US1234567890")]
    [InlineData("!@1234567890")]
    [InlineData("!@123slt7890")]
    [InlineData("!@1d2k4^9F7%")]
    public void Update_ShouldUpdate_WhenISINIsValid(string isin)
    {
        // Arrange
        var name = "";
        var stockTicker = "";
        var exchange = "";
        string? website = null;
        var companyRecord = new CompanyRecord(name, stockTicker, exchange, "AB0987654321", website);


        // Act
        var exception = Record.Exception(() =>
        {
            companyRecord.Update(name, stockTicker, exchange, isin, website);
            Assert.Equal(companyRecord.ISIN, isin);
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
    public void Update_ShouldThrowInvalidCompanyRecordISINException_WhenISINIsInvalid(string isin)
    {
        // Arrange
        var name = "";
        var stockTicker = "";
        var exchange = "";
        string? website = null;
        var expectedExceptionMsg = $"'{isin}' is not a valid ISIN. ISIN must not start with 2 numbers and must be 12 characters long.";
        var companyRecord = new CompanyRecord(name, stockTicker, exchange, "US1234567890", website);

        // Act & Assert
        var exception = Assert.Throws<InvalidCompanyRecordISINException>(() =>
        {
            companyRecord.Update(name, stockTicker, exchange, isin, website);
        });

        Assert.Equal(expectedExceptionMsg, exception.Message);

    }
}