using System;
namespace GeekTrust.War
{
    public class SubstitutionWithLowerBattalionRule : IWarRule
    {
        public void CalculateUnits(Battalion Battalion)
        {
            if (Battalion.IsExhausted && Battalion.Previous != null)
            {
                int requiredUnits = Math.Abs(Battalion.AdditionalUnits * 2);
                int availableUnits = (Battalion.Previous.Remaining / 2) * 2;
                int CanUse = availableUnits > requiredUnits ? requiredUnits : availableUnits;

                Battalion.Previous.Deployed += CanUse;
                Battalion.Required -= CanUse / 2;
            }
        }
    }

}
