using ScrumMasterDashboard.Dto;

namespace ScrumMasterDashboard.Api.Services.v1.Interfaces
{
	public interface ITeamMemberService
	{
		Task<List<TeamMemberResponseDTO>> GetTeamAllMembers();
		Task<TeamMemberResponseDTO> GetTeamMember(int teamMemberId);
		Task<TeamMemberResponseDTO> CreateTeamMember(TeamMemberRequestDTO teamMemberRequestDTO);
	}
}
