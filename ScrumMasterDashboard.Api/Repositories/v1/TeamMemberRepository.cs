using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Repositories.v1.Interfaces;

namespace ScrumMasterDashboard.Api.Repositories.v1
{
    public class TeamMemberRepository : ITeamMemberRepository
	{
		public Task<TeamMember> GetTeamMemberAsync(string teamMemberId)
		{
			throw new NotImplementedException();
		}
	}
}
