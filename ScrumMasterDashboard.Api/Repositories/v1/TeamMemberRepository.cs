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

		/// <inheritdoc cref="ITeamMemberRepository.GetAllTeamMembers"/>
		/// Returns all <see cref="TeamMember"/> in the db asynchronously as a list.
		/// </summary>
		public async Task<List<TeamMember>> GetAllTeamMembers() => await _databaseContext.TeamMembers.ToListAsync();

		/// <inheritdoc cref="ITeamMemberRepository.GetTeamMember"/>
		public async Task<TeamMember> GetTeamMember(int teamMemberId)
		{
			TeamMember? teamMemberResult = await _databaseContext.TeamMembers.FindAsync(teamMemberId);

			return teamMemberResult ?? throw new Exception($"No team member exists with id: {teamMemberId}.");
		}

		/// <inheritdoc cref="ITeamMemberRepository.CreateTeamMember"/>
		public async Task<TeamMember> CreateTeamMember(TeamMember teamMember)
		{
			EntityEntry<TeamMember> createResult = await _databaseContext.TeamMembers.AddAsync(teamMember);
			int numberOfAddedEntries = await _databaseContext.SaveChangesAsync();

			if (numberOfAddedEntries != 1 || createResult.Entity.Id < 1)
			{
				throw new Exception("Failed to create team member.");
			}

			return createResult.Entity;
		}

		/// <inheritdoc cref="ITeamMemberRepository.DeleteTeamMember"/>
		public async Task<bool> DeleteTeamMember(TeamMember teamMember)
		{
			_databaseContext.TeamMembers.Remove(teamMember);
			int numberOfDeletedEntities = await _databaseContext.SaveChangesAsync();

			return numberOfDeletedEntities.Equals(1);
		}
	}
}
