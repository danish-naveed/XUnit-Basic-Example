using EmployeesApp.Validation;
using System.Collections.Generic;
using Xunit;

namespace EmployyesTestApp
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidation _validation;

        public AccountNumberValidationTests() => _validation = new AccountNumberValidation();

        [Theory]
        [InlineData("13-4543234576-23")]
        [InlineData("1334-4543234576-23")]
        public void IsValid_ValidAccountNumberFirstPart_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("13-543234576-23")]
        [InlineData("13-95432345763-23")]
        public void IsValid_ValidAccountNumberMiddlePart_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("13-4543234576-3")]
        [InlineData("13-4543234576-2333")]
        public void IsValid_ValidAccountNumberLastPart_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }
    }
}