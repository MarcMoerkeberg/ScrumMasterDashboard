using System.ComponentModel.DataAnnotations;

namespace ScrumMasterDashboard.Dto
{
	public class TeamMemberBaseDTO
	{
		[Required, MinLength(1), MaxLength(100)]
		public string Name { get; set; } = string.Empty;
	}

	public class TeamMemberRequestDTO : TeamMemberBaseDTO
	{
	}

	public class TeamMemberResponseDTO : TeamMemberBaseDTO
	{
		[Required]
		public int Id { get; set; }
	}
}
