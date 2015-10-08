using System;
using System.IO;

class SlicingFile
{
    const string sourceFile = "../../file.txt";
    const string destination = "../../";


    static void Main()
    {
        Console.Write("Enter in how many parts do you want the file to be sliced: ");
        int parts = int.Parse(Console.ReadLine());
        SplitFile(parts);
        Assemble(parts);
    }

    public static void SplitFile(int parts)
    {
        byte[] buffer = new byte[4096];

        using (Stream input = File.OpenRead(sourceFile))
        {
            int index = 1;
            while (input.Position < input.Length)
            {

                using (Stream output = File.Create(destination + "\\" + index + ".txt"))
                {

                    int chunkBytesRead = 0;
                    while (chunkBytesRead < input.Length / parts)
                    {
                        int bytesRead = input.Read(buffer, 0, buffer.Length);

                        if (bytesRead == 0)
                        {
                            break;
                        }
                        chunkBytesRead += bytesRead;
                        output.Write(buffer, 0, bytesRead);
                    }

                }
                index++;
            }
        }
    }
    private static void Assemble(int parts)
    {
        byte[] buffer = new byte[4096];
        for (int i = 1; i <= parts; i++)
        {
            string source = String.Format("../../{0}.txt", i);
            FileStream partOfFile = new FileStream(source, FileMode.Open);
            FileStream assembledFile = new FileStream("../../assembled.txt", FileMode.Append);

            using (partOfFile)
            {
                using (assembledFile)
                {
                    int bytesRead;
                    while ((bytesRead = partOfFile.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        assembledFile.Write(buffer, 0, bytesRead);
                    }

                }
            }
        }
    }


}