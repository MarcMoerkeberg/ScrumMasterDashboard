using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Repositories.v1.Interfaces;
using ScrumMasterDashboard.Api.Services.v1.Interfaces;

namespace ScrumMasterDashboard.Api.Services.v1
{
    public class TeamMemberService : ITeamMemberService
	{
		private readonly ITeamMemberRepository _teamMemberRepository;

		public TeamMemberService(ITeamMemberRepository teamMemberRepository)
		{
			_teamMemberRepository = teamMemberRepository;
		}

		public Task<TeamMember> GetTeamMemberAsync(int teamMemberId)
		{
			throw new NotImplementedException();
		}
	}
}
