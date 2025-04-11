using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblersDatabase
{
    internal class Gamblers
    {
        public string Name { get; set; }
        public float CreditScore { get; set; }
        public string CardInfo { get; set; }
        public string Address { get; set; }
        public float Debt { get; set; }
        public string Birthday { get; set; }
        public bool isMinor { get; set; }

        public Gamblers(string name, float creditscore, string cardinfo, string address, float debt, string birthday, bool isminor)
        {
            name = Name;
            creditscore = CreditScore;
            cardinfo = CardInfo;
            address = Address;
            debt = Debt;
            birthday = Birthday;
            isminor = isMinor;
        }
    }
}
