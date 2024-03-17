using ScrumMasterDashboard.Api.DataAccess;
using ScrumMasterDashboard.Api.Models.Entities;

namespace ScrumMasterDashboard.Api.Repositories.v1.Interfaces
{
	public interface ITeamMemberRepository
	{
		/// <summary>
		/// Returns all <see cref="TeamMember"/> in the db asynchronously as a list.
		/// </summary>
		Task<List<TeamMember>> GetAllTeamMembers();

		/// <summary>
		/// Returns the <see cref="TeamMember"/> with <paramref name="teamMemberId"/> asynchronously.<br/><br/>
		/// Throws <see cref="Exception"/> if no <see cref="TeamMember"/> with <paramref name="teamMemberId"/> is found.
		/// </summary>
		/// <exception cref="Exception"></exception>
		Task<TeamMember> GetTeamMember(int teamMemberId);

		/// <summary>
		/// Inserts the <paramref name="teamMember"/> in the <see cref="DatabaseContext"/> asynchronously.<br/><br/>
		/// Throws an <see cref="Exception"/> if it failed creating the <paramref name="teamMember"/>.
		/// </summary>
		/// <returns>The created <see cref="TeamMember"/> entity.</returns>
		/// <exception cref="Exception"></exception>
		Task<TeamMember> CreateTeamMember(TeamMember teamMember);

		/// <summary>
		/// Removes the <paramref name="teamMember"/> from the <see cref="DatabaseContext"/>.
		/// </summary>
		/// <returns>True if the <paramref name="teamMember"/> was successfully removed.</returns>
		Task<bool> DeleteTeamMember(TeamMember teamMember);

		/// <summary>
		/// Uses <paramref name="teamMemberToUpdate"/> to update the existing entry in the <see cref="DatabaseContext"/>.
		/// </summary>
		/// <param name="teamMemberToUpdate">Will replace the existing <see cref="TeamMember"/>.</param>
		/// <returns>The updated <see cref="TeamMember"/> entity.</returns>
		/// <exception cref="Exception"></exception>
		Task<TeamMember> UpdateTeamMember(TeamMember teamMemberToUpdate);
	}
}
