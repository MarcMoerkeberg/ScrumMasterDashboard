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
			try
			{
				List<TeamMemberResponseDTO> allTeamMembers = await _teamMemberService.GetTeamAllMembers();

				return allTeamMembers;
			}
			catch (Exception)
			{
				//TODO: Log exception and handle response
				throw;
			}
		}

		[HttpGet]
		[Route("{teamMemberId:int}")]
		public async Task<TeamMemberResponseDTO> GetTeamMember(int teamMemberId)
		{
			try
			{
				TeamMemberResponseDTO teamMember = await _teamMemberService.GetTeamMember(teamMemberId);

				return teamMember;
			}
			catch (Exception)
			{
				//TODO: Log exception and handle response
				throw;
			}
		}

		[HttpPost]
		public async Task<TeamMemberResponseDTO> CreateTeamMember(TeamMemberRequestDTO teamMemberRequestDTO)
		{
			try
			{
				TeamMemberResponseDTO createTeamMemberResponse = await _teamMemberService.CreateTeamMember(teamMemberRequestDTO);

				return createTeamMemberResponse;
			}
			catch (Exception)
			{
				//TODO: Log exception and handle response
				throw;
			}
		}

		[HttpDelete]
		[Route("{teamMemberId:int}")]
		public async Task<bool> DeleteTeamMember(int teamMemberId)
		{
			try
			{
				bool deleteResult = await _teamMemberService.DeleteTeamMember(teamMemberId);

				return deleteResult;
			}
			catch (Exception)
			{
				//TODO: Log exception and handle response
				throw;
			}
		}

		[HttpPut]
		[Route("{teamMemberId:int}")]
		public async Task<string> UpdateTeamMember(int teamMemberId)
		{
			try
			{
				throw new NotImplementedException();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
