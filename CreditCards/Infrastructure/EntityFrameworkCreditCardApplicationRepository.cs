using CreditCards.Core.Interfaces;
using CreditCards.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCards.Infrastructure
{
    public class EntityFrameworkCreditCardApplicationRepository : ICreditCardApplicationRepository
    {
        private readonly AppDbContext _dbContext;

        public EntityFrameworkCreditCardApplicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(CreditCardApplication application)
        {
            _dbContext.CreditCardApplications.Add(application);

            return _dbContext.SaveChangesAsync();
        }
    }
}
