using System;

namespace Days2GoGo
{
    using McMaster.Extensions.CommandLineUtils;
    
    [Subcommand("Hello", typeof(HelloCommand))]
    [Subcommand("Until", typeof(UntilCommand))]
    public class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication<Program>();
            app.Conventions.UseDefaultConventions();

            try
            {
                return app.Execute(args);
            }
            catch (CommandParsingException cpe)
            {
                Console.WriteLine(cpe.Message);
                return -1;
            }
            finally
            {
#if DEBUG
                Console.ReadLine();
#endif
            }
        }
    }
}