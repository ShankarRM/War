using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace GeekTrust.War
{
    public class Army
    {
        public Dictionary<int, Battalion> Battalions { get; set; }

        public Army()
        {
            this.Battalions = new Dictionary<int, Battalion>();
        }
        public void Add(Dictionary<int, Battalion> Battalion)
        {
            this.Battalions = Battalion;
            SetLowerAndHigherBattalion();
        }

        private void SetLowerAndHigherBattalion()
        {
            foreach (var item in Battalions.Select((value, index) => new { value, index }))
            {
                int index = item.index + 1;
                if (item.index > 0)
                {
                    Battalions[index].Previous = Battalions[index - 1];
                    Battalions[index - 1].Next = Battalions[index];
                }
            }
        }



    }
}
