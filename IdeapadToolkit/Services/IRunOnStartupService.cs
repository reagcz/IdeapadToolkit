namespace IdeapadToolkit.Services
{
    public interface IRunOnStartupService
    {
        bool IsRunOnStartupEnabled();
        void ToggleRunOnStartup();
    }
}
