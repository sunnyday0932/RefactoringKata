using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorKata
{
    public interface IBookmarkRepository
    {
        void Save(List<string> results);
    }
}
