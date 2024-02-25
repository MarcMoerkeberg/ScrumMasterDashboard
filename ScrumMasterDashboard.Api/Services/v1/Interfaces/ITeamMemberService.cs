﻿using ScrumMasterDashboard.Api.Models.Entities;

namespace ScrumMasterDashboard.Api.Services.v1.Interfaces
{
    public interface ITeamMemberService
	{
		Task<TeamMember> GetTeamMemberAsync(int teamMemberId);
	}
}
