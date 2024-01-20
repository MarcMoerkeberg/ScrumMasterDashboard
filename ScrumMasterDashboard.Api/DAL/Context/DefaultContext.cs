using Microsoft.EntityFrameworkCore;
using ScrumMasterDashboard.Api.DAL.Entities;

namespace ScrumMasterDashboard.Api.DAL.Context
{
	public class DefaultContext : DbContext
	{
		public DbSet<TeamMember> TeamMembers { get; set; }
		public DefaultContext(DbContextOptions contextOptions) : base(contextOptions)
		{
		}
	}
}
