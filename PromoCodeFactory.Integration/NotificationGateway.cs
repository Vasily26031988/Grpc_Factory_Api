using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstraction.Gateways;

namespace PromoCodeFactory.Integration
{
    public class NotificationGateway
	     : INotificationGateway
    {
	    public Task SendNotificationToPartnerAsync(Guid partnerId, string message)
	    {
		    //Код, который вызывает сервис отправки уведомлений партнеру

		    return Task.CompletedTask;
	    }
    }
}
