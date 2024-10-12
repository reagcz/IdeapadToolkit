namespace IdeapadToolkit.Services
{
    public interface IAdministratorPermissionService
    {
        public bool IsAdministrator { get; }
        public void RelaunchAsAdmin();
    }
}
