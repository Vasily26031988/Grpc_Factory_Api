using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Abstraction.Gateways
{
    public interface INotificationGateway
    {
	    Task SendNotificationToPartnerAsync(Guid partnerId, string message);
    }
}
