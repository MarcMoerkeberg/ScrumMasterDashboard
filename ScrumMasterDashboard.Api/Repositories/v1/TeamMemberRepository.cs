using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

			return teamMemberResult ?? throw new Exception($"No team member exists with id: {teamMemberId}.");
		}

		/// <summary>
		/// Inserts the <paramref name="teamMember"/> in the <see cref="DatabaseContext"/> asynchronously.<br/><br/>
		/// Throws an <see cref="Exception"/> if the <paramref name="teamMember"/> is not created.
		/// </summary>
		/// <returns><see cref="TeamMember.Id"/> of the newly created entity.</returns>
		/// <exception cref="Exception"></exception>
		public async Task<TeamMember> CreateTeamMember(TeamMember teamMember)
		{
			EntityEntry<TeamMember> createResult = await _databaseContext.TeamMembers.AddAsync(teamMember);
			await _databaseContext.SaveChangesAsync();

			if(createResult.Entity == null || createResult.Entity.Id == 0)
			{
				throw new Exception("Failed to create team member.");
			}

			return createResult.Entity;
		}
	}
}
