using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Service.Interfaces
{
    public interface IReceiveMessagesFactory
    {
        ReceiveMessagesSalesService CreateNewSalesService(string topic, string subscription, string filterName = null, string filter = null);
        ReceiveMessagesUserWithLessOfferService CreateNewUserWithLessOfferService(string topic, string subscription, string filterName = null, string filter = null);
    }
}
