using System;

namespace MyApp
{

    [Fritz(true)]
    public class FritzHat : BaseHat, IHat {

        public int Id { get; set; }

        public string Name { get; init; }

        public DateTime AcquiredDate { get; set; }

        public Theme Theme { get; set; }

        public void Wash(DateTime washDate) {

            Console.WriteLine($"Washed the {Name} hat");

        }

        internal double AgeInDays() {
            return DateTime.Now.Subtract(AcquiredDate).TotalDays;
        }

    }


}