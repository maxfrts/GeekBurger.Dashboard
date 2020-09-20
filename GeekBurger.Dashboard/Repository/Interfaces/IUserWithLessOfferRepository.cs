using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Model;

namespace GeekBurger.Dashboard.Repository.Interfaces
{
    public interface IUserWithLessOfferRepository
    {
        Task<List<UserWithLessOffer>> GetAll();
        Task Add(UserWithLessOffer userRestrictions);
    }
}
