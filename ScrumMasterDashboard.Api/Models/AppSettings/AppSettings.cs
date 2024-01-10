namespace ScrumMasterDashboard.Api.Models.AppSettings
{
	public class AppSettings
	{
		public string AppName { get; set; } = string.Empty;
		public ConnectionStrings ConnectionStrings { get; set; } = new();
	}
}
