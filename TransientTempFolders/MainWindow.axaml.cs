using System;
using System.Diagnostics;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TransientTempFolders;

public partial class MainWindow : Window
{
    private readonly string _path = @"/home/mike/temp/";
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateTmpFolderBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var tmpFolderPath = string.Concat(_path, Guid.NewGuid());
        var fileStream = Directory.CreateDirectory(tmpFolderPath);
        var processInfo = new ProcessStartInfo("dolphin", tmpFolderPath);
        var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        while (true)
        {
            if (!process.HasExited) continue;
            fileStream.Delete();
            break;
        }
    }
}