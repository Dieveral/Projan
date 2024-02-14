using ClassFinder.Entities;

namespace ClassFinder
{
    public static class CodeParser
    {
        public static List<ClassInfo> Parse(IEnumerable<string> codeLines)
        {
            List<ClassInfo> result = new List<ClassInfo>();

            foreach (string codeLine in codeLines)
            {
                var classInfo = ParseCodeLine(codeLine);
                if (classInfo is not null)
                {
                    result.Add(classInfo);
                }
            }

            return result;
        }

        public static ClassInfo? ParseCodeLine(string codeLine)
        {
            // Find class
            if (codeLine.StartsWith("class "))
            {
                string className = codeLine.Substring(6).Trim();
                return new ClassInfo(className, DataType.Class);
            }
            else if (codeLine.Contains(" class "))
            {
                int startIndex = codeLine.IndexOf(" class ") + 7;
                string className = codeLine.Substring(startIndex).Trim();
                return new ClassInfo(className, DataType.Class);
            }

            return null;
        }

        //public static List<string> SplitCodeLine(string codeLine)
        //{
        //    char[] specialChars = new char[]
        //    {
        //        ' ',
        //        '+',
        //        '-',
        //        '=',
        //        ';',
        //    };
        //}

        //public static string RemoveSpecialCharacters(string line)
        //{
        //    string[] specialCharacters = new string[]
        //    {
        //    };
        //}
    }
}
