using System;
namespace GeekTrust.War
{
    public class SubstituteWithHigherBattalionRule : IWarRule
    {
        public void CalculateUnits(Battalion Battalion)
        {
            if (Battalion.IsExhausted && Battalion.Next != null)
            {
                int requiredUnits = Convert.ToInt32(Math.Ceiling((decimal)Math.Abs(Battalion.AdditionalUnits) / 2));

                int CanUse = Battalion.Next.Remaining > requiredUnits ? requiredUnits : Battalion.Next.Remaining;

                Battalion.Next.Deployed += CanUse;
                Battalion.Required -= requiredUnits == CanUse ? Battalion.AdditionalUnits  : CanUse;
            }
        }
    }

}
