using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumMasterDashboard.Api.DAL.Entities
{
	[Table("TeamMembers")]
	public class TeamMember
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; } = string.Empty;
	}
}
