using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards.Core.Model
{
    public enum CreditCardApplicationDecision
    {
        Unknown,
        AutoAccepted,
        AutoDeclined,
        ReferredToHuman
    }
}
