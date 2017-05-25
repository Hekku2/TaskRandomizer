using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Randomizer
{
    public class FileReader
    {
        private readonly string _taskFolder;

        public FileReader(string taskFolder)
        {
            _taskFolder = taskFolder;
        }

        public List<List<string>> ReadFiles()
        {
            var files = Directory.GetFiles(_taskFolder);

            return files
                .Select(File.ReadAllLines)
                .Select(FilterLines)
                .ToList();
        }

        private static List<string> FilterLines(string[] lines)
        {
            return lines.Where(ShouldBeIncluded).ToList();
        }

        private static bool ShouldBeIncluded(string line)
        {
            return !string.IsNullOrEmpty(line) && !line.StartsWith("#");
        }
    }
}
