using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Service.Interfaces;

namespace GeekBurger.Dashboard.Service
{
    public class ReceiveMessagesFactory : IReceiveMessagesFactory
    {
        private readonly ISalesService _salesService;
        private readonly IUserRestrictionsService _userRestrictionsService;

        public ReceiveMessagesFactory(ISalesService salesService, IUserRestrictionsService userRestrictionsService)
        {
            _salesService = salesService;
            _userRestrictionsService = userRestrictionsService;

            CreateNewSalesService("orderchanged", "sub_dashboard");

            CreateNewUserWithLessOfferService("userwithlessoffer", "sub_dashboard");
        }

        public ReceiveMessagesSalesService CreateNewSalesService(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesSalesService(_salesService, topic, subscription, filterName, filter);
        }

        public ReceiveMessagesUserWithLessOfferService CreateNewUserWithLessOfferService(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesUserWithLessOfferService(_userRestrictionsService, topic, subscription, filterName, filter);
        }
    }
}
