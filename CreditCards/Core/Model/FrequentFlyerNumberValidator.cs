using CreditCards.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards.Core.Model
{
    public class FrequentFlyerNumberValidator : IFrequentFlyerNumberValidator
    {
        private readonly char[] _validSchemeIdentifiers = { 'A', 'Q', 'Y' };
        private const int ExpectedTotalLength = 8;
        private const int ExpectedMemberNumberLength = 6;

        public bool IsValid(string frequentFlyerNumber)
        {
            if (frequentFlyerNumber is null)
            {
                throw new ArgumentNullException(nameof(frequentFlyerNumber));
            }

            if (frequentFlyerNumber.Length != ExpectedTotalLength)
            {
                return false;
            }

            var memberNumberPart = frequentFlyerNumber
                                    .Substring(0, ExpectedMemberNumberLength);

            /*if (!int.TryParse(memberNumberPart, out int _))
            {
                return false;
            }*/

            if (!int.TryParse(memberNumberPart, NumberStyles.None, null, out int _))
            {
                return false;
            }

            var schemeIdentifier = frequentFlyerNumber.Last();
            return _validSchemeIdentifiers.Contains(schemeIdentifier);
        }
    }
}
