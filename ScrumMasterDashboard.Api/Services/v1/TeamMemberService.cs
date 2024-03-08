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

		public async Task<List<TeamMemberResponseDTO>> GetTeamAllMembers()
		{
			List<TeamMember> allTeamMembers = await _teamMemberRepository.GetAllTeamMembers();
			List<TeamMemberResponseDTO> response = allTeamMembers.ToResponseDTO();
			
			return response;
		}
	}
}
