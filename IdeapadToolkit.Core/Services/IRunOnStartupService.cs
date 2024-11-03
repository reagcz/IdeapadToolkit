namespace IdeapadToolkit.Core.Services
{
    public interface IRunOnStartupService
    {
        bool IsRunOnStartupEnabled();
        void ToggleRunOnStartup();
    }
}
