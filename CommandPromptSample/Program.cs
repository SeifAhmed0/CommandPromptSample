namespace CommandPromptSample
{
    internal class Program
    {
        /* [ File System Command Line ] 👌
         * List files & directories: list [path] 👌
         * Print file & directory info: info [path] 👌
         * Create directory: mkdir [path] 👌
         * Remove file & directory: remove [path] 👌
         * Read file content: read [path] 👌
         */

        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write(">> ");
                var input = Console.ReadLine().Trim();
                var whiteSpaceIndex = input.IndexOf(' ');
                var command = input.Substring(0, whiteSpaceIndex).ToLower();
                var path = input.Substring(whiteSpaceIndex + 1).Trim();
                //Console.WriteLine(command);
                //Console.WriteLine(path);

                if (command == "list")
                {
                    foreach (var entry in Directory.GetDirectories(path))
                    {
                        Console.WriteLine($"\t [Dir] {entry}");
                    }

                    foreach (var entry in Directory.GetFiles(path))
                    {
                        Console.WriteLine($"\t [File] {entry}");
                    }
                }
                else if (command == "info")
                {
                    if (Directory.Exists(path))
                    {
                        var content = new DirectoryInfo(path);
                        Console.WriteLine($"Name: {content.Name}");
                        Console.WriteLine($"Full Name: {content.FullName}");
                        Console.WriteLine($"Creation Time: {content.CreationTime}");
                        Console.WriteLine($"Last Modification Time: {content.LastWriteTime}");
                    }
                    else if (File.Exists(path))
                    {
                        var content = new FileInfo(path);
                        Console.WriteLine($"Name: {content.Name}");
                        Console.WriteLine($"Full Name: {content.FullName}");
                        Console.WriteLine($"Creation Time: {content.CreationTime}");
                        Console.WriteLine($"Last Modification Time: {content.LastWriteTime}");
                        Console.WriteLine($"The Size in Bytes: {content.Length}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid!");
                    }
                }
                else if (command == "mkdir")
                {
                    Directory.CreateDirectory(path);
                }
                else if (command == "remove")
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }
                    else if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                else if (command == "read")
                {
                    Console.WriteLine(File.ReadAllText(path));
                }
                else if(command == "exit")
                {
                    break;
                }

            }


        }
    }
}
