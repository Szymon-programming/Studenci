using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Studenci
{
    public class IndexValidator
    {
        private HashSet<string> usedIndexes = new HashSet<string>();

        public bool TryAddIndex(string index)
        {
            //Do Poprawy
            if (!Regex.IsMatch(index, @"S\d{3}$") && Exists(index)) return false; 
            return usedIndexes.Add(index);
        }

        public bool Exists(string index)
        {
            return usedIndexes.Contains(index);
        }

        public IEnumerable<string> GetAllIndexes()
        {
            return usedIndexes;
        }
    }
}
