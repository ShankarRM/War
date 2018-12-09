namespace GeekTrust.War
{
    public class Like_To_Like_Rule : IWarRule
    {
        public void CalculateUnits(Battalion Battalion)
        {
            Battalion.Deployed += Battalion.IsExhausted ? Battalion.Units : Battalion.Required;
        }
    }

}
