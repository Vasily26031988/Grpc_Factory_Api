using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.DataAccess;
using PromoCodeFactory.DataAccess.Data;

namespace PromoCodeFactory.IntegrationTests.Data
{
    public class EfTestDbInitializer 
	    :IDbInitializer
    {
	    private readonly DataContext _dataContext;

	    public EfTestDbInitializer(DataContext dataContext)
	    {
		    _dataContext = dataContext;
	    }

	    public void InitializeDb()
	    {
		    _dataContext.Database.EnsureDeleted();
		    _dataContext.Database.EnsureCreated();

		    _dataContext.AddRange(TestDataFactory.Employees);
		    _dataContext.SaveChanges();

		    _dataContext.AddRange(TestDataFactory.Preferences);
		    _dataContext.SaveChanges();

		    _dataContext.AddRange(TestDataFactory.Customers);
		    _dataContext.SaveChanges();

		    _dataContext.AddRange(TestDataFactory.Partners);
		    _dataContext.SaveChanges();
	    }

	    public void CleanDb()
	    {
		    _dataContext.Database.EnsureDeleted();
	    }
    }
}
