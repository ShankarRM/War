using System;
namespace GeekTrust.War
{
    public class PowerRule : IWarRule
    {
        private readonly Battalion opponent;
        public PowerRule(Battalion opponent)
        {
            this.opponent = opponent;
        }
        public void CalculateUnits(Battalion Battalion)
        {
            Battalion.Required = ((int)Math.Ceiling((decimal)this.opponent.Units / 2));
        }
    }

}
