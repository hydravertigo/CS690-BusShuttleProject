namespace BusShuttle;

using Spectre.Console;

public class ConsoleUI
{
    DataManager dataManager;

    public ConsoleUI()
    {
        dataManager = new DataManager();
    }

    public void Show()
    {
        //string mode = AskForInput("Please select mode (driver OR manager): ");

        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    "driver","manager"
                }));

        if (mode == "driver")
        {
            var selectedDriver = AnsiConsole.Prompt(
                    new SelectionPrompt<Driver>()
                        .Title("Select a driver")
                        .AddChoices(dataManager.Drivers));

            Console.WriteLine("Now you are driving as " + selectedDriver.Name);

            Loop selectedLoop = AnsiConsole.Prompt(
                    new SelectionPrompt<Loop>()
                        .Title("Select a loop")
                        .AddChoices(dataManager.Loops));

            Console.WriteLine("You selected " + selectedLoop.Name + " loop!");

            string command;

            do
            {
                Stop selectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                        .Title("Select a stop")
                        .AddChoices(selectedLoop.Stops));

                Console.WriteLine("You selected " + selectedStop.Name + " stop!");


                //int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));
                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of boarded passengers: "));

                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);

                dataManager.AddNewPassengerData(data);
                            
                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "continue", "end"
                        }));

            } while (command != "end");
        }
    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

}
