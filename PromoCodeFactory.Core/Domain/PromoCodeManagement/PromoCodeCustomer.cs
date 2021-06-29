using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCodeCustomer 
	    : BaseEntity
    {
	    public Guid PromoCodeId { get; set; }
	    public virtual PromoCode PromoCode { get; set; }

	    public Guid CustomerId { get; set; }
	    public virtual Customer Customer { get; set; }
    }
}
