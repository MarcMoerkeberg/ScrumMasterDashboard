using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ScrumMasterDashboard.Api.DAL.Entities;
using ScrumMasterDashboard.Api.Services.v1.Interfaces;

namespace ScrumMasterDashboard.Api.Controllers.v1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/[controller]/[action]")]
	public class TeamMemberController : ControllerBase
	{
		private readonly ITeamMemberService _teamMemberService;
		public TeamMemberController(ITeamMemberService teamMemberService)
		{
			_teamMemberService = teamMemberService;
		}

		[HttpGet]
		public async Task<TeamMember> Get(int teamMemberId)
		{
			throw new NotImplementedException();
		}
	}
}
