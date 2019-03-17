using StrukturaDrzewiasta.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace StrukturaDrzewiasta
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new DatabaseContext()))
            {
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] tail)
        {
            return source.Concat(tail);
        }
    }
}