using ScrumMasterDashboard.Api.Models.Entities;

namespace ScrumMasterDashboard.Api.Repositories.v1.Interfaces
{
	public interface ITeamMemberRepository
	{
		Task<List<TeamMember>> GetAllTeamMembers();
	}
}
