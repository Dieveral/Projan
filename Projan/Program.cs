using System.Text.Json;

namespace Projan
{
    internal class Program
    {
        static JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        static void Main(string[] args)
        {
            string path = GetPath(args);

            SearchSummary summary = new SearchSummary();

            while (true)
            {
                if (path.Trim().ToLower() is "exit")
                {
                    return;
                }
                else if (PathIsDirectory(path))
                {
                    // Run folder algorithm
                    Console.WriteLine($"Started to collect information in directory: '{path}'");
                    break;
                }
                else if (PathIsFile(path))
                {
                    // Run file algorithm
                    Console.WriteLine($"Started to collect information in file: '{path}'");

                    SearchInFile(path, summary);
                    break;
                }
                else
                {
                    Console.WriteLine($"Path '{path}' does not exist or is incorrect");
                    Console.WriteLine();
                    path = AskForPath();
                }
            }

            string summaryFilePath = "summary.json";
            WriteSummaryToFile(summary, summaryFilePath);

            Console.WriteLine($"Search summary was successfully created: '{new FileInfo(summaryFilePath).FullName}'");
            Console.ReadLine();
        }

        private static string GetPath(string[] args)
        {
            string path;

            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                path = AskForPath();
            }

            return path;
        }

        private static string AskForPath()
        {
            Console.WriteLine("Enter directory\\file path or 'exit'");
            return Console.ReadLine() ?? string.Empty;
        }

        private static bool PathIsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        private static bool PathIsFile(string path)
        {
            return File.Exists(path);
        }

        private static void SearchInFile(string filePath, SearchSummary summary)
        {
            summary.Results.Add(CollectWordsInFile(filePath, new string[] { }));
        }

        private static FileResult CollectWordsInFile(string filePath, string[] ignoreList)
        {
            FileResult result = new FileResult(filePath);

            using (StreamReader fromFile = new StreamReader(filePath))
            {
                while (fromFile.EndOfStream is false)
                {
                    string line = fromFile.ReadLine() ?? string.Empty;
                    if (line.StartsWith("using ") ||
                        line.Trim().StartsWith("///"))
                    {
                        continue;
                    }
                    else if (line.StartsWith("namespace "))
                    {
                        result.Namespace = line.Substring(10);
                    }
                    else
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            if (ignoreList.Contains(word))
                            {
                                continue;
                            }

                            if (result.Words.ContainsKey(word))
                            {
                                result.Words[word]++;
                            }
                            else
                            {
                                result.Words.Add(word, 1);
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static void WriteSummaryToFile(SearchSummary summary, string filePath)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(summary, serializerOptions));
        }
    }
}
