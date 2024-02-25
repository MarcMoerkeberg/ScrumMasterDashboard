﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumMasterDashboard.Api.DataAccess;
using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Services.v1.Interfaces;

namespace ScrumMasterDashboard.Api.Controllers.v1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/[controller]/[action]")]
	public class TeamMemberController : ControllerBase
	{
		private readonly ITeamMemberService _teamMemberService;
		private readonly DatabaseContext _databaseContext;
		public TeamMemberController(ITeamMemberService teamMemberService, DatabaseContext databaseContext)
		{
			_teamMemberService = teamMemberService;
			_databaseContext = databaseContext;
		}

		[HttpGet]
		public async Task<List<TeamMember>> GetTeamMembers()
		{
			try
			{
				List<TeamMember> teamMembers = await _databaseContext.TeamMembers.ToListAsync();

				return teamMembers;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpGet]
		[Route("{teamMemberId:int}")]
		public async Task<string> GetTeamMember(int teamMemberId)
		{
			try
			{
				TeamMember? teamMember = await _databaseContext.TeamMembers.FindAsync(teamMemberId);
				return teamMember?.Name ?? "Ikke fundet";
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
