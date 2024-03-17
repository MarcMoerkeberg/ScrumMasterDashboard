using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumMasterDashboard.Api.Models.Entities
{
	[Table("TeamMembers")]
	public class TeamMember
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; init; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Alters the properties with those on <paramref name="updatedTeamMember"/>.<br/>
		/// It returns the updated <see cref="TeamMember"/> to allow for method chaining.
		/// </summary>
		/// <param name="updatedTeamMember">Should contain the properties to update the target <see cref="TeamMember"/>.</param>
		public TeamMember UpdateProperties(TeamMember updatedTeamMember)
		{
			Name = updatedTeamMember.Name;

			return this;
		}
	}
}
