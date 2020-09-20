using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Model;

namespace GeekBurger.Dashboard.Service.Interfaces
{
    public interface IUserRestrictionsService
    {
        Task<IEnumerable<UserRestrictions>> ConsolidateUserRestrictions();
        Task SaveUserRestriction(UserWithLessOffer user);
    }
}
