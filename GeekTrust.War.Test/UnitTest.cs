using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GeekTrust.War.Test
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void PowerRule()
        {
            string lengaBuruBattalions = "100 H,50 E,10 AT,5 SG";
            string enemyBattalion = "175 H,60 E,10 AT,5 SG";
            Dictionary<int, Battalion> battalion = Helper.Process(lengaBuruBattalions);
            Dictionary<int, Battalion> ebattalion = Helper.Process(enemyBattalion);

            Battalion current = battalion[1];
            Battalion next = battalion[3];
            

            IWarRule warRule = new PowerRule(ebattalion[1]);
            warRule.CalculateUnits(current);
            Assert.AreEqual(88, current.Required);
            
        }

        [TestMethod]
        public void Like_To_Like_Rule()
        {
            string lengaBuruBattalions = "100 H,50 E,10 AT,5 SG";
            string enemyBattalion = "175 H,60 E,10 AT,5 SG";
            Dictionary<int, Battalion> battalion = Helper.Process(lengaBuruBattalions);
            Dictionary<int, Battalion> ebattalion = Helper.Process(enemyBattalion);

            Battalion current = battalion[1];
            current.Required = 88;


            IWarRule warRule = new Like_To_Like_Rule();
            warRule.CalculateUnits(current);
            Assert.AreEqual(88, current.Deployed);

        }

        [TestMethod]
        public void GetHelpFromLowerBattaliion()
        {
            string lengaBuruBattalions = "100 H,50 E,10 AT,5 SG";
            Dictionary<int, Battalion> battalion = Helper.Process(lengaBuruBattalions);
            Battalion previous = battalion[1];
            Battalion current = battalion[2];
            current.Previous = previous;

            current.Deployed = 50;
            current.Required = 51;

            IWarRule warRule = new SubstitutionWithLowerBattalionRule();
            warRule.CalculateUnits(battalion[2]);
            Assert.AreEqual(2, previous.Deployed);
        }

        [TestMethod]
        public void GetHelpFromHigherBattaliion()
        {
            string lengaBuruBattalions = "100 H,50 E,10 AT,5 SG";
            Dictionary<int, Battalion> battalion = Helper.Process(lengaBuruBattalions);

            Battalion current = battalion[2];
            Battalion next = battalion[3];
            current.Next = next;

            current.Deployed = 50;
            current.Required = 54;

            IWarRule warRule = new SubstituteWithHigherBattalionRule();
            warRule.CalculateUnits(current);
            //Assert.AreEqual(0, current.AdditionalUnits);
            Assert.AreEqual(false, current.IsExhausted);
            Assert.AreEqual(2, next.Deployed);
            Assert.AreEqual(8, next.Remaining);
        }

    }
}
