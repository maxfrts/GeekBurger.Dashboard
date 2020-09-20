using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.ServiceBus;
using System.Collections.Generic;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using System.Threading.Tasks;
using System;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Service.Interfaces;
using GeekBurger.Dashboard.Repository.Interfaces;
using GeekBurger.Dashboard.Model;
using System.Linq;

namespace GeekBurger.Dashboard.Service
{
    public class UserRestrictionsService : IUserRestrictionsService
    {
        private readonly IUserWithLessOfferRepository _userWithLessOfferRepository;

        public UserRestrictionsService(IUserWithLessOfferRepository userWithLessOfferRepository)
        {
            _userWithLessOfferRepository = userWithLessOfferRepository;
        }

        public async Task SaveUserRestriction(UserWithLessOffer user)
        {
            await _userWithLessOfferRepository.Add(user);
        }

        public async Task<IEnumerable<UserRestrictions>> ConsolidateUserRestrictions()
        {
            var userRestrictions = await _userWithLessOfferRepository.GetAll();

            return userRestrictions
                .GroupBy(g => g.UserRestrictions)
                .Select(g => new UserRestrictions()
                {
                    Restrictions = g.Key.Split(' '),
                    Users = g.Count()
                })
                .OrderByDescending(g => g.Users);
        }
    }
}
