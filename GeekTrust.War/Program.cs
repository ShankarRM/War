using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeekTrust.War
{
    public class Program
    {
        static void Main(string[] args)
        {
            Army AIFalicornia = new Army();
            Army KingShan = new Army();

            string lengaBuruBattalions = "100 H,50 E,10 AT,5 SG";

            List<string> falicorniaBattalions = new List<string> {
                "100 H, 101 E, 20 AT, 5 SG",
                "150 H, 96 E, 26 AT, 8 SG",
                "250 H, 50 E, 20 AT, 15 SG"
            };
            foreach (var item in falicorniaBattalions)
            {
                KingShan.Add(Helper.Process(lengaBuruBattalions));
                AIFalicornia.Add(Helper.Process(item));
                BattleGround battleGround = new BattleGround(KingShan, AIFalicornia);
                battleGround.Fight();
                Helper.DisplayResult(KingShan.Battalions);
            }
        }





    }

}
