using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PartnerPromoCodeLimit
    {
	    public Guid Id { get; set; }

	    public Guid PartnerId { get; set; }

	    public virtual Partner Partner { get; set; }

	    public DateTime CreateDate { get; set; }

	    public DateTime? CancelDate { get; set; }

	    public DateTime EndDate { get; set; }

	    public int Limit { get; set; }
    }
}
