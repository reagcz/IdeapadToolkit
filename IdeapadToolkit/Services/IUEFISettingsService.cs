namespace IdeapadToolkit.Services
{
    public interface IUEFISettingsService
    {
        public bool GetFlipToBootStatus();
        public int SetFlipToBootStatus(bool newStatus);
    }
}
