using System.Collections.Generic;

namespace GeekTrust.War
{
    public class Battalion
    {

        public string Name { get; private set; }
        public int Units { get; private set; }
        public int Required { get; set; }
        public int Remaining
        {
            get
            {
                return this.Required == 0 ? this.Units - this.Deployed : 
                    this.Units - this.Required;
            }
        }
        public int AdditionalUnits
        {
            get
            {

                return this.Required == 0 ? 0 : this.Required - this.Deployed;
            }
        }
        public int Deployed { get; set; }
        public bool IsExhausted { get { return this.Remaining < 0; } }

        public Battalion Previous { get; set; }
        public Battalion Next { get; set; }
        public Battalion(string Name, int Units)
        {
            this.Name = Name;
            this.Units = Units;
        }


    }

}
