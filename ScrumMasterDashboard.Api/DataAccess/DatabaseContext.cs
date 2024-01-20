using Microsoft.EntityFrameworkCore;
using ScrumMasterDashboard.Api.DataAccess.Entities;

namespace ScrumMasterDashboard.Api.DataAccess
{
	public class DatabaseContext : DbContext
	{
		public DbSet<TeamMember> TeamMembers { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
		{
		}
	}
}
