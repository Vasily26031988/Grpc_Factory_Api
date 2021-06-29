using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models
{
    public class PartnerResponse
    {
	    public Guid Id { get; set; }

	    public bool IsActive { get; set; }

	    public string Name { get; set; }

	    public int NumberIssuedPromoCodes { get; set; }

	    public List<PartnerPromoCodeLimitResponse> PartnerLimits { get; set; }
    }
}
