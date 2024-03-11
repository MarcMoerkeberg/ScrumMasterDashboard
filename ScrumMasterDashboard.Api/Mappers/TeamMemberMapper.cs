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
		
		public static TeamMember ToDbModel(this TeamMemberRequestDTO requestDto)
		{
			return new TeamMember
			{
				Name = requestDto.Name
			};
		}
		
		public static List<TeamMember> ToDbModel(this List<TeamMemberRequestDTO> requestDto)
		{
			return requestDto.Select(ToDbModel).ToList();
		}
	}
}
