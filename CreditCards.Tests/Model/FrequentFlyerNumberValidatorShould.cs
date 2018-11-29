using CreditCards.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CreditCards.Core.Interfaces;

namespace CreditCards.Tests.Model
{
    public class FrequentFlyerNumberValidatorShould
    {
        [Fact]
        public void AcceptValidSchemes()
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.True(sut.IsValid("012346-A"));
        }

        [Theory]
        [InlineData("012345-A")]
        [InlineData("012345-Q")]
        [InlineData("012345-Y")]
        public void AcceptValidSchemesMultiInput(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.True(sut.IsValid(number));
        }

        [Theory]
        [InlineData("0123-A")]
        [InlineData("Q-012345")]
        [InlineData("012345-G")]
        public void AcceptValidSchemesFalse(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.False(sut.IsValid(number));
        }

        [Theory]
        [InlineData("012345-1")]
        [InlineData("012345-B")]
        [InlineData("012345-P")]
        [InlineData("012345-R")]
        [InlineData("012345-X")]
        [InlineData("012345-Z")]
        [InlineData("012345- ")]
        [InlineData("012345-a")]
        [InlineData("012345-q")]
        [InlineData("012345-y")]
        public void RejectInvalidSchemes(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.False(sut.IsValid(number));
        }

        [Theory]
        [InlineData("      -A")]
        [InlineData("  1   -A")]
        [InlineData("1     -A")]
        [InlineData("     1-A")]
        public void RejectEmptyMemberNumberDigits(string number)
        {
            var sut = new FrequentFlyerNumberValidator();

            Assert.False(sut.IsValid(number));
        }

        [Theory]
        [InlineData("        ")]
        [InlineData("")]
        public void RejectEmptyFrequentFlyerNumber(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.False(sut.IsValid(number));
        }

        [Fact]
        public void ReferInvalidFrequentFlyerNumbers_RealValidator()
        {
            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);

            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

            var application = new CreditCardApplication
            {
                FrequentFlyerNumber = "0dm389dn29"
            };

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman,
                sut.Evaluate(application));
        }


    }
}
