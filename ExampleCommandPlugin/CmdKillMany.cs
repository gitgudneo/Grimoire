using System.Threading.Tasks;
using Grimoire.Botting;
using Grimoire.Botting.Commands.Combat;

namespace ExampleCommandPlugin
{
    public class CmdKillMany : IBotCommand // Implement IBotCommand, required for all bot commands
    {
        public string Monster { get; set; } // The monster to kill
        public int Kills { get; set; } // Number of times to kill it

        public async Task Execute(IBotEngine instance) // The method that executes the command
        {
            CmdKill kill = new CmdKill { Monster = Monster }; // Use the default kill command

            for (int i = 0; i < Kills; i++)
            {
                if (!instance.IsRunning) // Ensure that the bot has not been stopped
                    return;

                await kill.Execute(instance);
                await Task.Delay(500);
            }
        }

        public override string ToString() // The text to display in the bot manager command list
        {
            return $"Kill {Monster} {Kills} times";
        }
    }
}
