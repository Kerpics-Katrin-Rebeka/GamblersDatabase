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
        public string CardNum { get; set; }
        public string CardExp { get; set; }
        public string CardCVC { get; set; }
        public string Address { get; set; }
        //public string City { get; set; }
        //public string Street { get; set; }
        //public string House { get; set; }
        // nem mindenhol lehet, hibas txt
        public float Debt { get; set; }
        public string Birthday { get; set; }
        public string BirthYear { get; set; }
        public string BirthMonth { get; set; }
        public string BirthDay { get; set; }
        public bool isMinor { get; set; }

        public Gamblers(string Name, float CreditScore, string CardInfo, string Address, float Debt, string Birthday, bool isMinor)
        {
            this.Name = Name;
            this.CreditScore = CreditScore;
            this.CardInfo = CardInfo;
            this.CardNum = this.CardInfo.Split(",")[0];
            this.CardExp = this.CardInfo.Split(",")[1];
            this.CardCVC = this.CardInfo.Split(",")[2];
            this.Address = Address;
            this.Birthday = Birthday;
            this.BirthYear = this.Birthday.Split(".")[0];
            this.BirthMonth = this.Birthday.Split(".")[1];
            this.BirthDay = this.Birthday.Split(".")[2];
            this.Address = Address;
            this.isMinor = isMinor;
        }
    }
}
