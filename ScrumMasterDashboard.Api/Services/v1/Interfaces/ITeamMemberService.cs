using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Repositories.v1.Interfaces;
using ScrumMasterDashboard.Dto;

namespace ScrumMasterDashboard.Api.Services.v1.Interfaces
{
	public interface ITeamMemberService
	{
		/// <summary>
		/// Returns a list of all team members as <see cref="TeamMemberResponseDTO"/>.
		/// </summary>
		Task<List<TeamMemberResponseDTO>> GetTeamAllMembers();

		/// <summary>
		/// Returns the team member with the given <paramref name="teamMemberId"/> as <see cref="TeamMemberResponseDTO"/>.
		/// </summary>
		Task<TeamMemberResponseDTO> GetTeamMember(int teamMemberId);

		/// <summary>
		/// Creates a new team member with the given <paramref name="teamMemberRequestDTO"/>.
		/// </summary>
		/// <returns>The newly created <see cref="TeamMember"/> as <see cref="TeamMemberResponseDTO"/>.</returns>
		Task<TeamMemberResponseDTO> CreateTeamMember(TeamMemberRequestDTO teamMemberRequestDTO);

		/// <summary>
		/// Deletes the team member with the given <paramref name="teamMemberId"/>.
		/// </summary>
		/// <returns>The deletion result from <see cref="ITeamMemberRepository.DeleteTeamMember"/>.</returns>
		Task<bool> DeleteTeamMember(int teamMemberId);
	}
}
