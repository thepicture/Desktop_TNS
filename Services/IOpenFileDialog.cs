namespace TelekomNevaSvyazWpfApp.Services
{
    public interface IOpenFileDialog
    {
        bool TryOpenFile(out string filePath);
    }
}
