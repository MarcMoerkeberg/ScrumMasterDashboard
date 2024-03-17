using ScrumMasterDashboard.Api.Mappers;
using ScrumMasterDashboard.Api.Models.Entities;
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

		/// <inheritdoc cref="ITeamMemberService.GetTeamAllMembers"/>
		public async Task<List<TeamMemberResponseDTO>> GetTeamAllMembers()
		{
			List<TeamMember> allTeamMembers = await _teamMemberRepository.GetAllTeamMembers();
			List<TeamMemberResponseDTO> response = allTeamMembers.ToResponseDTO();

			return response;
		}

		/// <inheritdoc cref="ITeamMemberService.GetTeamMember"/>
		public async Task<TeamMemberResponseDTO> GetTeamMember(int teamMemberId)
		{
			TeamMember teamMember = await _teamMemberRepository.GetTeamMember(teamMemberId);
			TeamMemberResponseDTO response = teamMember.ToResponseDTO();

			return response;
		}

		/// <inheritdoc cref="ITeamMemberService.CreateTeamMember"/>
		public async Task<TeamMemberResponseDTO> CreateTeamMember(TeamMemberRequestDTO teamMemberRequestDTO)
		{
			TeamMember teamMember = await _teamMemberRepository.CreateTeamMember(teamMemberRequestDTO.ToDbModel());
			TeamMemberResponseDTO response = teamMember.ToResponseDTO();

			return response;
		}

		/// <inheritdoc cref="ITeamMemberService.DeleteTeamMember"/>
		public async Task<bool> DeleteTeamMember(int teamMemberId)
		{
			TeamMember teamMemberToDelete = await _teamMemberRepository.GetTeamMember(teamMemberId);
			bool deleteResult = await _teamMemberRepository.DeleteTeamMember(teamMemberToDelete);

			return deleteResult;
		}

		/// <inheritdoc cref="ITeamMemberService.UpdateTeamMember"/>
		public async Task<TeamMemberResponseDTO> UpdateTeamMember(int teamMemberId, TeamMemberRequestDTO teamMemberRequestDTO)
		{
			TeamMember teamMemberToUpdate = await _teamMemberRepository.GetTeamMember(teamMemberId);
			teamMemberToUpdate.UpdateProperties(teamMemberRequestDTO.ToDbModel());

			TeamMember updatedTeamMember = await _teamMemberRepository.UpdateTeamMember(teamMemberToUpdate);
			TeamMemberResponseDTO response = updatedTeamMember.ToResponseDTO();

			return response;
		}
	}
}
