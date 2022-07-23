namespace RefactorKata
{
    class Program : BookmarkProcess
    {
        static void Main(string[] args)
        {
            var filePath = args.Length == 0 || string.IsNullOrWhiteSpace(args[0]) ? @"bookmarks.txt" : args[0];
            new BookmarkProcess().ClearTracingCode(filePath);
        }
    }
}