using Microsoft.EntityFrameworkCore;
using ScrumMasterDashboard.Api.DAL.Entities;

namespace ScrumMasterDashboard.Api.DAL
{
	public class DatabaseContext : DbContext
	{
		public DbSet<TeamMember> TeamMembers { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
		{
		}
	}
}
