namespace IdeapadToolkit.Core.Services
{
    public interface IAdministratorPermissionService
    {
        public bool IsAdministrator { get; }
        public void RelaunchAsAdmin();
    }
}
