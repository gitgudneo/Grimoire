using System;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Networking;
using Grimoire.Networking.Handlers;
using Grimoire.Tools;

namespace Grimoire.Botting
{
    // TODO: Re-evaluate whether this class should be static (store instance in the bot config?)
    public static class OptionsManager
    {
        private static bool _isRunning;
        public static bool IsRunning
        {
            get => _isRunning;
            private set
            {
                _isRunning = value;
                StateChanged?.Invoke(value);
            }
        }

        public static event Action<bool> StateChanged;

        public static bool ProvokeMonsters { get; set; }
        public static bool EnemyMagnet { get; set; }
        public static bool LagKiller { get; set; }
        public static bool SkipCutscenes { get; set; }

        private static IJsonMessageHandler HandlerDisableAnimations { get; } = new HandlerAnimations();
        private static bool _disableAnimations;
        public static bool DisableAnimations
        {
            get => _disableAnimations;
            set
            {
                _disableAnimations = value;
                if (value) Proxy.Instance.RegisterHandler(HandlerDisableAnimations);
                else Proxy.Instance.UnregisterHandler(HandlerDisableAnimations);
            }
        }

        private static IXtMessageHandler HandlerHidePlayers { get; } = new HandlerPlayers();
        private static bool _hidePlayers;
        public static bool HidePlayers
        {
            get => _hidePlayers;
            set
            {
                _hidePlayers = value;
                if (value)
                {
                    Proxy.Instance.RegisterHandler(HandlerHidePlayers);
                    DestroyPlayers();
                }
                else Proxy.Instance.UnregisterHandler(HandlerHidePlayers);
            }
        }

        private static IJsonMessageHandler HandlerRange { get; } = new HandlerSkills();
        private static bool _infRange;

        public static bool InfiniteRange
        {
            get => _infRange;
            set
            {
                _infRange = value;
                if (value)
                {
                    Proxy.Instance.RegisterHandler(HandlerRange);
                    SetInfiniteRange();
                }
                else Proxy.Instance.UnregisterHandler(HandlerRange);
            }
        }

        public static int WalkSpeed { get; set; } = 8;

        private static void SetInfiniteRange() => Flash.Call("SetInfiniteRange");
        private static void SetProvokeMonsters() => Flash.Call("SetProvokeMonsters");
        private static void SetEnemyMagnet() => Flash.Call("SetEnemyMagnet");
        private static void SetLagKiller() => Flash.Call("SetLagKiller", LagKiller ? bool.TrueString : bool.FalseString);
        public static void DestroyPlayers() => Flash.Call("DestroyPlayers");
        private static void SetSkipCutscenes() => Flash.Call("SetSkipCutscenes");
        public static void SetWalkSpeed() => Flash.Call("SetWalkSpeed", WalkSpeed.ToString());

        public static void Start()
        {
            if (!IsRunning)
                ApplySettings();
        }

        public static void Stop() => IsRunning = false;

        private static async Task ApplySettings()
        {
            IsRunning = true;

            while (IsRunning)
            {
                if (!Player.IsLoggedIn)
                    return;

                if (ProvokeMonsters)
                    SetProvokeMonsters();
                if (EnemyMagnet)
                    SetEnemyMagnet();
                SetWalkSpeed();
                SetLagKiller();
                if (SkipCutscenes)
                    SetSkipCutscenes();

                await Task.Delay(1000);
            }
        }
    }
}
