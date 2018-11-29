using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards.Core.Interfaces
{
    public interface IFrequentFlyerNumberValidator 
    {
        bool IsValid(string frequentFlyerNumber);
    }
}
