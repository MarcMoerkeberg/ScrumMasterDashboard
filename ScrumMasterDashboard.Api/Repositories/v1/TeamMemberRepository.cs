using Microsoft.EntityFrameworkCore;
using ScrumMasterDashboard.Api.DataAccess;
using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Repositories.v1.Interfaces;

namespace ScrumMasterDashboard.Api.Repositories.v1
{
	public class TeamMemberRepository : ITeamMemberRepository
	{
		private readonly DatabaseContext _databaseContext;
		public TeamMemberRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<List<TeamMember>> GetAllTeamMembers() => await _databaseContext.TeamMembers.ToListAsync();
	}
}
