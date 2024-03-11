using Microsoft.EntityFrameworkCore;
using ScrumMasterDashboard.Api.DataAccess;
using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Api.Repositories.v1.Interfaces;

namespace ScrumMasterDashboard.Api.Repositories.v1
{
	public class TeamMemberRepository : ITeamMemberRepository
	{
		private readonly DatabaseContext _databaseContext;
		public TeamMemberRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		/// <summary>
		/// Returns all <see cref="TeamMember"/> in the db asynchronously as a list.
		/// </summary>
		public async Task<List<TeamMember>> GetAllTeamMembers() => await _databaseContext.TeamMembers.ToListAsync();

		/// <summary>
		/// Returns the <see cref="TeamMember"/> with <paramref name="teamMemberId"/> asynchronously.<br/><br/>
		/// Throws <see cref="Exception"/> if no <see cref="TeamMember"/> with <paramref name="teamMemberId"/> is found.
		/// </summary>
		/// <exception cref="Exception"></exception>
		public async Task<TeamMember> GetTeamMember(int teamMemberId)
		{
			TeamMember? teamMemberResult = await _databaseContext.TeamMembers.FindAsync(teamMemberId);

			return teamMemberResult ?? throw new Exception($"No team member exists with id: {teamMemberId}");
		}
	}
}
