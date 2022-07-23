﻿using System;
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

                var key = split[0].TrimEnd();

                // 移除 url 中的 tracking 碼。utm, fblid
                if (key.Contains("utm"))
                {
                    var utmIndex = key.IndexOf("utm");
                    var end = key.IndexOf('&', utmIndex);
                    if (end == -1)
                    {
                        end = key.Length;
                    }

                    key = key.Remove(utmIndex, end - utmIndex);
                }

                if (key.Contains("fbclid"))
                {
                    var fbclidIndex = key.IndexOf("fbclid");
                    var end = key.IndexOf('&', fbclidIndex);

                    if (end == -1)
                    {
                        end = key.Length;
                    }

                    key = key.Remove(fbclidIndex, end - fbclidIndex);
                }

                if (key.EndsWith("?"))
                {
                    key = key.Remove(key.Length - 1);
                }

                if (matched.ContainsKey(key) == true)
                {
                    Console.WriteLine($"{matched[key]:0000}: {key}");
                    Console.WriteLine($"{index:0000}: {line}");
                    duplicate++;
                }
                else
                {
                    results.Add($"{split[1].TrimEnd()},{key}");
                    matched.Add(key, index);
                }
            }

            _document.Save(results);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"duplicate count: {duplicate}");
            Console.WriteLine($"total count: {index}");
        }
    }
}