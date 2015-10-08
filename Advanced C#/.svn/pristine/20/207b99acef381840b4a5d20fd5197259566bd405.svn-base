using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main(string[] args)
    {
        string pathCurrent = Directory.GetCurrentDirectory();// mnogo polezno za da si tarsi programata sama patekata spored komputara na koito startira
        string[] files = Directory.GetFiles(pathCurrent);
        List<FileInfo> fileInfos = files.Select(file => new FileInfo(file)).ToList();//Katya Marincheva
        var sorted = fileInfos.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);
        string resultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt"); ;
        using (var writer = new StreamWriter(resultPath, false))
        {
            foreach (var extensionGroup in sorted)
            {
                writer.WriteLine(extensionGroup.Key);
                foreach (var fileInfo in extensionGroup)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", fileInfo.Name, fileInfo.Length / 1024.0);
                }
            }
        }
    }
}
