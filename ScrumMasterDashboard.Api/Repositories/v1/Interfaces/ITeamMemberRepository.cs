using ScrumMasterDashboard.Api.DAL.Entities;

namespace ScrumMasterDashboard.Api.Repositories.v1.Interfaces
{
	public interface ITeamMemberRepository
	{
		Task<TeamMember> GetTeamMemberAsync(string teamMemberId);
	}
}
