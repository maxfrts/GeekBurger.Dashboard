using GeekBurger.Dashboard.Data;
using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Repository
{
    public class UserWithLessOfferRepository : IUserWithLessOfferRepository
    {
        private DashboardContext _context;

        public UserWithLessOfferRepository(DashboardContext context)
        {
            _context = context;
        }

        public async Task<List<UserWithLessOffer>> GetAll()
        {
            return _context.UserWithLessOffer?
                .ToList();
        }

        public async Task Add(UserWithLessOffer userWithLessOffer)
        {
            _context.UserWithLessOffer.Add(userWithLessOffer);
        }
    }
}
