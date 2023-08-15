using System.Collections.Generic;

namespace EXE02_EFood_API.BusinessObject
{
    public class ChartApiModel
    {
        public int user { get; set; }
        public int premium { get; set; }
        public int newUser { get; set; }
        public int newPremium { get; set; }
        public int premiumUnexpired { get; set; }
        public int rest { get; set; }
        public int pers { get; set; }
        public int pending { get; set; }
        public int twomonth { get; set; }
        public int onemonth { get; set; }
        public int thismonth { get; set; }
        
    }
}
