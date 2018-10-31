using System;
using System.ComponentModel.DataAnnotations;

namespace Days2GoGo
{
    using McMaster.Extensions.CommandLineUtils;
    
    [Command(Description = "Get a count down to a big date you are waiting for")]
    public class UntilCommand
    {
        [Argument(1, Name = "EventName", Description = "Name of the event you wish to count down to.")]
        [Required]
        public string EventName { get; } = "your big day";

        [Option(CommandOptionType.SingleValue, Description = "The date you are counting down to.")]
        public string Date { get; }

        [Option(CommandOptionType.MultipleValue, Description = "Any messages that relate to the event.")]
        public string[] Messages { get; }

        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            if (!DateTime.TryParse(Date, out var eventDate))
            {
                console.WriteLine("Invalid date.");
                return 0;
            }

            var today = DateTime.Today;

            var totalDays = (eventDate - today).TotalDays;

            console.WriteLine($"Only {totalDays} days to go before {EventName}.");

            foreach (var message in Messages)
            {
                console.WriteLine(message);
            }

            return 0;
        }
    }

    public class HelloCommand
    {
        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("Hello World!");

            return 0;
        }
    }
}