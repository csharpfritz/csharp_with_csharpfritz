using System.Linq;
using Microsoft.AspNetCore.Components;

namespace demo.Pages {

    public partial class Counter {

    private int currentCount = 0;

    [Inject] public Data.HatRepository Repository { get; set; }

    private void IncrementCount()
    {
        currentCount++;
    }
        
    }

}