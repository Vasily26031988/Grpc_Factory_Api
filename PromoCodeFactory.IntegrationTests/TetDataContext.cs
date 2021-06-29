using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.DataAccess;


namespace PromoCodeFactory.IntegrationTests.Api
{
	public class TestDataContext
		: DataContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=PromoCodeFactoryDb.sqlite");
		}
	}
}