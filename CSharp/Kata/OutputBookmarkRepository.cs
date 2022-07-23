using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorKata
{
    public class OutputBookmarkRepository : IBookmarkRepository
    {
        public void Save(List<string> results)
        {
            var write = new StreamWriter(@"bookmarks.csv");
            write.AutoFlush = true;
            results.ForEach(row =>
            {
                write.WriteLine(row);
            });

            write.Close();
        }
    }
}
