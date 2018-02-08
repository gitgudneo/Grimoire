using System;
using System.Threading;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Botting;
using Grimoire.UI;

namespace Grimoire.Tools
{
    public static class AutoRelogin
    {
        public static bool IsTemporarilyKicked => Flash.Call<bool>("IsTemporarilyKicked");
                
        public static void Login() => Flash.Call("Login");
                
        public static bool ResetServers() => Flash.Call<bool>("ResetServers");
                
        public static bool AreServersLoaded => Flash.Call<bool>("AreServersLoaded");
                
        public static void Connect(Server server) => Flash.Call("Connect", server.Name);
                
        public static async Task Login(Server server, int relogDelay, CancellationTokenSource cts, bool ensureSuccess)
        {
            if (IsTemporarilyKicked)
                await BotManager.Instance.ActiveBotEngine.WaitUntil(
                    () => !IsTemporarilyKicked, () => !cts.IsCancellationRequested, 65);

            if (cts.IsCancellationRequested)
                return;

            ResetServers();
            Login();
            await BotManager.Instance.ActiveBotEngine.WaitUntil(() => AreServersLoaded, () => !cts.IsCancellationRequested, 30);

            if (cts.IsCancellationRequested)
                return;

            Connect(server);
            await BotManager.Instance.ActiveBotEngine.WaitUntil(() => !World.IsMapLoading, () => !cts.IsCancellationRequested, 40);

            if (cts.IsCancellationRequested)
                return;

            await Task.Delay(relogDelay);

            if (ensureSuccess)
                Task.Run(() => EnsureLoginSuccess(cts));
        }

        private static async Task EnsureLoginSuccess(CancellationTokenSource cts)
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(1000);

                if (cts.IsCancellationRequested)
                    return;

                string map = Player.Map;

                if (!string.IsNullOrEmpty(map) &&
                    !map.Equals("name", StringComparison.OrdinalIgnoreCase) &&
                    !map.Equals("battleon", StringComparison.OrdinalIgnoreCase))
                    break;
            }
            if (Player.Map.Equals("battleon", StringComparison.OrdinalIgnoreCase))
                Player.Logout();
        }
    }
}
