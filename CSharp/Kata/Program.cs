using System;
using System.Collections.Generic;
using System.IO;

namespace RefactorKata
{
    class Program : BookmarkProcess
    {
        static void Main(string[] args)
        {
            new BookmarkProcess().TranseFerFile();
        }
    }
}