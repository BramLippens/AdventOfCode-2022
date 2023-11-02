namespace AdventOfCode
{
    public class Day07 : BaseDay
    {
        private readonly string _input;

        public Day07()
        {
            _input = File.ReadAllText(InputFilePath);
        }
        public override ValueTask<string> Solve_1()
        {
            var lines = _input.Split('\n');
            Directory root = new Directory("/");
            Directory currentDir = null;
            List<Directory> smallOnes = new();
            foreach (string item in lines)
            {
                var line = item.Replace("\r", "");
                if (line.StartsWith("$"))
                {
                    if(line.Contains(" cd "))
                    {
                        string directoryName = line.Split("cd ")[1];
                        if (directoryName.Equals("/"))
                        {
                            currentDir = root;
                        }
                        else
                        {
                            if (directoryName.Equals(".."))
                            {
                                currentDir = currentDir.Parent;
                            }
                            else
                            {
                                currentDir = Helpers.FindOrCreate(currentDir, directoryName);
                            }
                        }
                    }
                }
                else
                {
                    if (line.StartsWith("dir"))
                    {
                        var dirName = line.Split("dir ")[1];
                        currentDir.Directories.Add(Helpers.FindOrCreate(currentDir, dirName));
                    }
                    else
                    {
                        var parts = line.Split(" ");
                        currentDir.Files.Add(new ElfFile(parts[1], int.Parse(parts[0])));
                    }
                }
            }
            Helpers.GoTroughDirs(root, smallOnes);
            var total = 0L;
            foreach(var dir in smallOnes)
            {
                total += dir.TotalSize;
            }
            return new($"{total}");
        }

        public override ValueTask<string> Solve_2()
        {
            var lines = _input.Split('\n');
            Directory root = new Directory("/");
            Directory currentDir = null;
            List<Directory> toDelete = new();
            foreach (string item in lines)
            {
                var line = item.Replace("\r", "");
                if (line.StartsWith("$"))
                {
                    if (line.Contains(" cd "))
                    {
                        string directoryName = line.Split("cd ")[1];
                        if (directoryName.Equals("/"))
                        {
                            currentDir = root;
                        }
                        else
                        {
                            if (directoryName.Equals(".."))
                            {
                                currentDir = currentDir.Parent;
                            }
                            else
                            {
                                currentDir = Helpers.FindOrCreate(currentDir, directoryName);
                            }
                        }
                    }
                }
                else
                {
                    if (line.StartsWith("dir"))
                    {
                        var dirName = line.Split("dir ")[1];
                        currentDir.Directories.Add(Helpers.FindOrCreate(currentDir, dirName));
                    }
                    else
                    {
                        var parts = line.Split(" ");
                        currentDir.Files.Add(new ElfFile(parts[1], int.Parse(parts[0])));
                    }
                }
            }
            var freeSpace = 70000000 - root.TotalSize;
            Helpers.FindDeletableDirectories(root, toDelete, freeSpace);
            Directory deleted = toDelete.OrderBy(e => e.TotalSize).First();
            return new($"{deleted.Name} - {deleted.TotalSize}");
        }

        
        class Directory
        {
            public string Name { get; set; }
            public List<ElfFile> Files { get; set; }
            public List<Directory> Directories { get; set; }
            public Directory? Parent { get; set; }

            public Directory(string name, Directory? parent = null)
            {
                Name = name;
                Parent = parent;
                Files = new();
                Directories = new();
            }
            public long TotalSize
            {
                get
                {
                    long size = 0;
                    foreach (var item in Files)
                    {
                        size += item.Size;
                    }
                    foreach (var item in Directories)
                    {
                        size += item.TotalSize;
                    }
                    return size;
                }
            }
        }
        class ElfFile
        {
            public string FileName { get; set; }
            public int Size { get; set; }

            public ElfFile(string name, int size)
            {
                FileName = name;
                Size = size;
            }
        }
        static class Helpers
        { 
            public static Directory FindOrCreate(Directory current, string name)
            {
                Directory directory = current.Directories.Find(d => d.Name == name);
                if (directory is null)
                {
                    return new Directory(name, current);
                }
                return directory;
            }
            public static void GoTroughDirs(Directory current, List<Directory> smallOnes)
            {
                if (current.TotalSize <= 100000)
                {
                    smallOnes.Add(current);
                }
                foreach (var directory in current.Directories)
                {
                    GoTroughDirs(directory, smallOnes);
                }
            }
            public static void FindDeletableDirectories(Directory current, List<Directory> toDelete, long freeSpace)
            {
                if (freeSpace + current.TotalSize >= 30000000)
                {
                    toDelete.Add(current);
                }
                foreach (var directory in current.Directories)
                {
                    FindDeletableDirectories(directory, toDelete, freeSpace);
                }
            }
        }
    }
}