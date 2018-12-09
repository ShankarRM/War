using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace GeekTrust.War
{
    public static class Helper
    {
        public static Dictionary<int, Battalion> Process(string input)
        {
            Regex r1 = new Regex(@",?(\d+)\s(\w+),?", RegexOptions.IgnoreCase);

            Dictionary<int, Battalion> Lengaburu = new Dictionary<int, Battalion>();
            Match m = r1.Match(input);
            int matchCount = 0;
            while (m.Success)
            {
                ++matchCount;
                Lengaburu.Add(matchCount, new Battalion(m.Groups[2].Value, Convert.ToInt32(m.Groups[1].Value)));

                m = m.NextMatch();
            }
            return Lengaburu;
        }
        public static void DisplayResult(Dictionary<int, Battalion> lengaburuBattalion)
        {
            foreach (var item in lengaburuBattalion)
            {
                Console.Write($"{item.Value.Deployed,3}{item.Value.Name}, ");
            }
            var result = lengaburuBattalion.Where(p => p.Value.AdditionalUnits > 0).Count() > 0 ? "loses" : "wins";
            Console.WriteLine(result);
        }
    }
}