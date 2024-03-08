using ScrumMasterDashboard.Api.Models.Entities;
using ScrumMasterDashboard.Dto;

namespace ScrumMasterDashboard.Api.Mappers
{
	public static class TeamMemberMapper
	{
		public static TeamMemberResponseDTO ToResponseDTO(this TeamMember teamMember)
		{
			return new TeamMemberResponseDTO
			{
				Id = teamMember.Id,
				Name = teamMember.Name
			};
		}
		
		public static List<TeamMemberResponseDTO> ToResponseDTO(this List<TeamMember> teamMembers)
		{
			return teamMembers.Select(ToResponseDTO).ToList();
		}
	}
}
