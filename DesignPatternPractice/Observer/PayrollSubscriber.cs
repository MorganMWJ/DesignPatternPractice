using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPractice.Observer;
internal class PayrollSubscriber : ISubscriber
{
    public void OnPublisherNotify(object? sender, Dictionary<string, object> eventArgs)
    {
        if (sender != null && sender is PersonPublisher)
        {
            if(eventArgs.TryGetValue("OnBoard", out var value))
            {
                var newPeople = value as List<Person>;
                Console.WriteLine($"Adding to Payroll {newPeople!.Count} people");
            }
            else if (eventArgs.TryGetValue("OffBoard", out var value2))
            {
                var leavers = value as List<Person>;
                Console.WriteLine($"Removing from Payroll {leavers!.Count} people");
            }
            else if (eventArgs.TryGetValue("Birthday", out var value3))
            {
                var p = value3 as Person;
                Console.WriteLine($"Paying {p!.Name}'s Birthday Bonus :-)");
            }
        }
    }
}
