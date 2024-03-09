using System.Diagnostics;
using System.IO;

namespace TransientTempFolders;

public class TempFolderData
{
    private readonly DirectoryInfo _tempFolder;
    private readonly Process _process;

    public TempFolderData(DirectoryInfo folder, string folderPath)
    {
        _tempFolder = folder;
        _process = new Process();
        _process.StartInfo = new ProcessStartInfo("dolphin", folderPath);
    }

    public void OpenFolder()
    {
        _process.Start();
        while (true)
        {
            if (!_process.HasExited) continue;
            _tempFolder.Delete();
            break;
        }
    }
}