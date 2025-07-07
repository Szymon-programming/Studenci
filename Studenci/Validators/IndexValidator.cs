using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Studenci.Models;

namespace Studenci.Validators
{
    public class IndexValidator
    {
        private HashSet<string> usedIndexes = new HashSet<string>();

        public bool TryAddIndex(string index)
        {
            if (!Regex.IsMatch(index, @"S\d{3}$")) return false;
            if (Exists(index)) return false;
            usedIndexes.Add(index); return true;
        }

        public bool Exists(string index)
        {
            return usedIndexes.Contains(index);
        }

        public IEnumerable<string> GetAllIndexes()
        {
            return usedIndexes;
        }

        public void LoadUsedIndexes(IEnumerable<Student> loadedStudents)
        {
            usedIndexes = new HashSet<string>(loadedStudents.Select(s => s.Index));
        }

        public void RemoveIndexWithStudent(string index)
        {
            usedIndexes.Remove(index);
        }

        public void ReturnUsedIndexes()
        {
            Console.WriteLine("Zapisane indeksy:");
            foreach (var index in usedIndexes)
            {
                Console.WriteLine(index);
            }
        }
    }
}
