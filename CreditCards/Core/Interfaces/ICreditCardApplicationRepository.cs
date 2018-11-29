using CreditCards.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards.Core.Interfaces
{
    public interface ICreditCardApplicationRepository
    {
        Task AddAsync(CreditCardApplication application);
    }
}
