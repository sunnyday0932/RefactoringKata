using System;
using System.Collections.Generic;
using System.IO;

namespace RefactorKata
{
    public class BookmarkProcess
    {
        private readonly IBookmarkRepository _document;

        public BookmarkProcess()
        {
            _document = new OutputBookmarkRepository();
        }

        public void ClearTracingCode(string filePath)
        {
            var streamReader = File.OpenText(filePath);
            var results = new List<string>();
            var matched = new Dictionary<string, int>();
            var duplicate = 0;
            var index = 1;
            while (streamReader.EndOfStream == false)
            {
                index++;
                var line = streamReader.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var split = line.Split('|');

                var url = split[0].TrimEnd();

                // 移除 url 中的 tracking 碼。utm, fblid
                url = RemoveTracingCode(url, "utm");
                url = RemoveTracingCode(url, "fbclid");
                url = RemoveTracingCode(url, "ptc");

                if (matched.ContainsKey(url) == true)
                {
                    Console.WriteLine($"{matched[url]:0000}: {url}");
                    Console.WriteLine($"{index:0000}: {line}");
                    duplicate++;
                }
                else
                {
                    results.Add($"{split[1].TrimEnd()},{url}");
                    matched.Add(url, index);
                }
            }

            _document.Save(results);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"duplicate count: {duplicate}");
            Console.WriteLine($"total count: {index}");
        }

        public string RemoveTracingCode(string url, string target)
        {
            while (url.Contains(target))
            {
                var utmIndex = url.IndexOf(target);
                var end = url.IndexOf('&', utmIndex);
                if (end == -1)
                {
                    end = url.Length;
                }

                url = url.Remove(utmIndex, end - utmIndex);
            }

            if (url.EndsWith("&"))
            {
                url = url.Remove(url.Length - 1);
            }

            if (url.EndsWith("?"))
            {
                url = url.Remove(url.Length - 1);
            }

            return url;
        }
    }
}