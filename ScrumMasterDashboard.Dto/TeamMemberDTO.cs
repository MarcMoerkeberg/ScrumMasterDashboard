using System.ComponentModel.DataAnnotations;

namespace ScrumMasterDashboard.Dto
{
	public class TeamMemberDTO
	{
		[Required]
		public int Id { get; set; }

		[MaxLength(100)]
		[MinLength(1)]
		public string Name { get; set; } = string.Empty;
	}
}
