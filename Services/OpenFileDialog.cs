namespace TelekomNevaSvyazWpfApp.Services
{
    public class OpenFileDialog : IOpenFileDialog
    {
        public bool TryOpenFile(out string filePath)
        {
            filePath = null;
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            bool? isOpenedFile = fileDialog.ShowDialog();
            if (isOpenedFile.HasValue && isOpenedFile.Value)
            {
                filePath = fileDialog.FileName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
