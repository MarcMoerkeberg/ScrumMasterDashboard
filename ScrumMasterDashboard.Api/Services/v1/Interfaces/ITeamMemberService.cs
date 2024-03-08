using ScrumMasterDashboard.Dto;

namespace ScrumMasterDashboard.Api.Services.v1.Interfaces
{
	public interface ITeamMemberService
	{
		Task<List<TeamMemberResponseDTO>> GetTeamAllMembers();
	}
}
