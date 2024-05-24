using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ScrumMasterDashboard.Api.Services.v1.Interfaces;
using ScrumMasterDashboard.Dto;

namespace ScrumMasterDashboard.Api.Controllers.v1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/[controller]")]
	public class TeamMembersController : ControllerBase
	{
		private readonly ITeamMemberService _teamMemberService;
		public TeamMembersController(ITeamMemberService teamMemberService)
		{
			_teamMemberService = teamMemberService;
		}

		[HttpGet]
		public async Task<List<TeamMemberResponseDTO>> GetAllTeamMembers()
		{
			List<TeamMemberResponseDTO> allTeamMembers = await _teamMemberService.GetTeamAllMembers();

			return allTeamMembers;
		}

		[HttpGet]
		[Route("{teamMemberId:int}")]
		public async Task<TeamMemberResponseDTO> GetTeamMember(int teamMemberId)
		{
			TeamMemberResponseDTO teamMember = await _teamMemberService.GetTeamMember(teamMemberId);

			return teamMember;
		}

		[HttpPost]
		public async Task<TeamMemberResponseDTO> CreateTeamMember(TeamMemberRequestDTO teamMemberRequestDTO)
		{
			TeamMemberResponseDTO createTeamMemberResponse = await _teamMemberService.CreateTeamMember(teamMemberRequestDTO);

			return createTeamMemberResponse;
		}

		[HttpDelete]
		[Route("{teamMemberId:int}")]
		public async Task<bool> DeleteTeamMember(int teamMemberId)
		{
			bool deleteResult = await _teamMemberService.DeleteTeamMember(teamMemberId);

			//Should return NoContent() (http 204) instead of the boolean result if successful
			return deleteResult;
		}

		[HttpPut]
		[Route("{teamMemberId:int}")]
		public async Task<TeamMemberResponseDTO> UpdateTeamMember(int teamMemberId, TeamMemberRequestDTO teamMemberRequestDTO)
		{
			TeamMemberResponseDTO updatedTeamMember = await _teamMemberService.UpdateTeamMember(teamMemberId, teamMemberRequestDTO);

			return updatedTeamMember;
		}
	}
}
