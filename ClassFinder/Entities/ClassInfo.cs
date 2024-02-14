namespace ClassFinder.Entities
{
    public class ClassInfo
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public string FilePath { get; set; }
        public string Namespace { get; set; }

        public ClassInfo(string name, DataType dataType)
        {
            Name = name;
            DataType = dataType;
            FilePath = string.Empty;
            Namespace = string.Empty;
        }
    }
}
