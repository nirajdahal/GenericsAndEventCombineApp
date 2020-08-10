using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library.DataAccess
{
    public class DataAccess<T> where T : new()
    {
        public event EventHandler<T> BadWordsDetected;
        
        public void SaveToCSV( List<T> items, string filePath) 
        {
            List<string> rows = new List<string>();
            T entry = new T();

            //var colums returns list of columns
            var cols = entry.GetType().GetProperties();
            string row = "";
            foreach (var col in cols)
            {
                row += $",{col.Name} ";
            }

            row = row.Substring(1);
            rows.Add(row);

            
            foreach (var item in items)
            {
                
                row = "";
                bool badValues = false;
                foreach (var col in cols)
                {
                    badValues = CheckBadValue.BadWordDetector(row);
                    if (badValues == true)
                    {
                        BadWordsDetected?.Invoke(this, item);
                        break;
                    }
                    row += $",{col.GetValue(item, null)}";
                }
                
                if (badValues == false)
                {
                    row = row.Substring(1);
                    rows.Add(row);
                }
                
            }

            File.WriteAllLines(filePath, rows);


        }
    }


    public static class CheckBadValue
    {
        
        public static bool BadWordDetector(string stringToCheck)
        {
            bool output = false;
            string lowerString = stringToCheck.ToLower();
            var values = Enum.GetValues(typeof(BadWords));
            foreach (var badWord in values)
            {
                if (lowerString.Contains(badWord.ToString()))
                {
                    output = true;
                }
            }

            return output;

        }

    }

    internal enum BadWords
    {
        heck,
        shit,
        damn
    }
}
