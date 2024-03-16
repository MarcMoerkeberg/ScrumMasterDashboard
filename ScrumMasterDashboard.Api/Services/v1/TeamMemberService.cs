using ScrumMasterDashboard.Api.Mappers;
using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Repositories.v1;
using ScrumMasterDashboard.Api.Repositories.v1.Interfaces;
using ScrumMasterDashboard.Api.Services.v1.Interfaces;
using ScrumMasterDashboard.Dto;

namespace ScrumMasterDashboard.Api.Services.v1
{
	public class TeamMemberService : ITeamMemberService
	{
		private readonly ITeamMemberRepository _teamMemberRepository;

		public TeamMemberService(ITeamMemberRepository teamMemberRepository)
		{
			_teamMemberRepository = teamMemberRepository;
		}

		/// <summary>
		/// Returns a list of all team members as <see cref="TeamMemberResponseDTO"/>.
		/// </summary>
		public async Task<List<TeamMemberResponseDTO>> GetTeamAllMembers()
		{
			List<TeamMember> allTeamMembers = await _teamMemberRepository.GetAllTeamMembers();
			List<TeamMemberResponseDTO> response = allTeamMembers.ToResponseDTO();

			return response;
		}

		/// <summary>
		/// Returns the team member with the given <paramref name="teamMemberId"/> as <see cref="TeamMemberResponseDTO"/>.
		/// </summary>
		public async Task<TeamMemberResponseDTO> GetTeamMember(int teamMemberId)
		{
			TeamMember teamMember = await _teamMemberRepository.GetTeamMember(teamMemberId);
			TeamMemberResponseDTO response = teamMember.ToResponseDTO();

			return response;
		}

		/// <summary>
		/// Creates a new team member with the given <paramref name="teamMemberRequestDTO"/>.
		/// </summary>
		/// <returns>The newly created <see cref="TeamMember"/> as a <see cref="TeamMemberResponseDTO"/>.</returns>
		public async Task<TeamMemberResponseDTO> CreateTeamMember(TeamMemberRequestDTO teamMemberRequestDTO)
		{
			TeamMember teamMember = await _teamMemberRepository.CreateTeamMember(teamMemberRequestDTO.ToDbModel());
			TeamMemberResponseDTO response = teamMember.ToResponseDTO();

			return response;
		}

		/// <summary>
		/// Deletes the team member with the given <paramref name="teamMemberId"/>.
		/// </summary>
		/// <returns>The deletion result from <see cref="TeamMemberRepository.DeleteTeamMember"/>.</returns>
		public async Task<bool> DeleteTeamMember(int teamMemberId)
		{
			TeamMember teamMemberToDelete = await _teamMemberRepository.GetTeamMember(teamMemberId);
			bool deleteResult = await _teamMemberRepository.DeleteTeamMember(teamMemberToDelete);

			return deleteResult;
		}
	}
}
