using System;
using System.Text.Json.Serialization;

namespace MyApp
{

    [Fritz(OnStream=true)]
    public class FritzHat : BaseHat, IHat, IPresentedOnStream {

        public int Id { get; set; }

        [JsonPropertyName("NameOfFritzsHat")]
        public string Name { get; set; }

        public DateTime AcquiredDate { get; set; }

        public Theme Theme { get; set; }

        public virtual void Wash(DateTime washDate) {

            Console.WriteLine($"Washed the {Name} hat");

        }

        internal double AgeInDays() {
            return DateTime.Now.Subtract(AcquiredDate).TotalDays;
        }

    }


}