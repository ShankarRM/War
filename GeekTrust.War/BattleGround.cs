using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace GeekTrust.War
{
    public class BattleGround
    {
        private readonly Army defendend;
        private readonly Army enemy;
        
        public BattleGround(Army defendend, Army enemy)
        {
            this.defendend = defendend;
            this.enemy = enemy;
            
        }
        public void Fight()
        {
            foreach (var battalion in defendend.Battalions)
            {
                WarRules(battalion.Value);
            }
        }
        private void WarRules(Battalion defendendBattalion)
        {
            IList<IWarRule> warRules = new List<IWarRule>();
            Func<KeyValuePair<int, Battalion>, bool> findBattalion = p => p.Value.Name.Equals(defendendBattalion.Name);
            Battalion battalion = enemy.Battalions.Where(findBattalion).FirstOrDefault().Value;
            warRules.Add(new PowerRule(battalion));
            warRules.Add(new Like_To_Like_Rule());
            warRules.Add(new SubstitutionWithLowerBattalionRule());
            warRules.Add(new SubstituteWithHigherBattalionRule());
            foreach (var rules in warRules)
            {
                rules.CalculateUnits(defendendBattalion);
            }
        }
    }
}
