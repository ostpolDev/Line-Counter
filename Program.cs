using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LineCounter {
    class Program {

        static void Main(string[] args) {
            Program p = new Program();
            p.Main();
        }

        public void Main() {
            Console.Title = "ostpol.it Simple Line Counter";
            Console.WriteLine("File Ending. (e.g. \"cs\") or \"*\" for every file type");
            string fileEnding = Console.ReadLine();
            Console.WriteLine("Directory Path. Empty for current Directory");
            string dir = Console.ReadLine();
            if (dir == "") {
                Console.WriteLine("Using Directory: " + Directory.GetCurrentDirectory());
                dir = Directory.GetCurrentDirectory();
            }
            Console.WriteLine("Counting Lines...");
            List<string> paths = getFilePaths(dir, fileEnding);
            List<int> counts = new List<int>();
            List<string> dirs = getDirPaths(dir);
            int fileCount, dirCount;
            fileCount = 0;
            // Add 1 to include current Directory
            dirCount = dirs.Count + 1;
            foreach (string dirPath in paths) {
                int tmpCount = 0;
                if (File.Exists(dirPath) && dirPath != Path.Combine(Directory.GetCurrentDirectory(), AppDomain.CurrentDomain.FriendlyName)) {
                    Console.WriteLine("> File found: " + dirPath);
                    tmpCount = File.ReadAllLines(dirPath).Length;
                    Console.WriteLine(tmpCount.ToString() + " Lines");
                    fileCount++;
                }
                counts.Add(tmpCount);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Line count in all files: ");
            Console.WriteLine(counts.Sum().ToString("N0"));
            Console.WriteLine("Files:");
            Console.WriteLine(fileCount.ToString("N0"));
            Console.WriteLine("Searched Directories:");
            Console.WriteLine(dirCount.ToString("N0"));
            Console.WriteLine("Press any key to restart");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ostpol.it | 2018");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

        public List<string> getDirPaths(string dir) {
            if (Directory.Exists(dir)) {
                return Directory.GetDirectories(dir, "*", SearchOption.AllDirectories).ToList();
            } else {
                Console.WriteLine("Directory not found! \"" + dir + "\"");
                return null;
            }
        }

        public List<string> getFilePaths(string dir, string ending) {
            if (Directory.Exists(dir)) {
                return Directory.GetFiles(dir, "*." + ending, SearchOption.AllDirectories).ToList();
            } else {
                Console.WriteLine("Directory not found! \""+ dir +"\"");
                return null;
            }
        }
    }
}
