﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.Botting
{
    public class Bot : IBotEngine
    {
        public event Action<bool> IsRunningChanged;
        public event Action<int> IndexChanged;
        public event Action<Configuration> ConfigurationChanged;

        private int _index;
        public int Index
        {
            get => _index;
            set => _index = value >= Configuration.Commands.Count ? 0 : value;
        }

        private Configuration _config;
        public Configuration Configuration
        {
            get => _config;
            set
            {
                if (value != _config)
                {
                    bool invoke = _config != null && Configuration != value;
                    _config = value;
                    if (invoke)
                        ConfigurationChanged?.Invoke(_config);
                }
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                IsRunningChanged?.Invoke(_isRunning);
            }
        }

        private CancellationTokenSource ctsSkills;
        private CancellationTokenSource _ctsBot;

        private Stopwatch _questDelayCounter;
        private Stopwatch _boostDelayCounter;

        public void Start(Configuration config)
        {
            IsRunning = true;
            Configuration = config;
            Index = 0;
            _ctsBot = new CancellationTokenSource();
            _questDelayCounter = new Stopwatch();
            _boostDelayCounter = new Stopwatch();
            World.ItemDropped += OnItemDropped;
            Player.Quests.QuestsLoaded += OnQuestsLoaded;
            Player.Quests.QuestCompleted += OnQuestCompleted;
            _questDelayCounter.Start();
            this.LoadAllQuests();
            this.LoadBankItems();
            CheckBoosts();
            _boostDelayCounter.Start();
            OptionsManager.Start();
            Task.Factory.StartNew(Activate, _ctsBot.Token, 
                TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public void Stop()
        {
            ctsSkills?.Cancel(false);
            _ctsBot?.Cancel(false);
            World.ItemDropped -= OnItemDropped;
            Player.Quests.QuestsLoaded -= OnQuestsLoaded;
            Player.Quests.QuestCompleted -= OnQuestCompleted;
            _questDelayCounter.Stop();
            _boostDelayCounter.Stop();
            OptionsManager.Stop();
            IsRunning = false;
        }

        private async Task Activate()
        {
            while (!_ctsBot.IsCancellationRequested)
            {
                if (Player.IsLoggedIn && !Player.IsAlive)
                {
                    World.SetSpawnPoint();
                    await this.WaitUntil(() => Player.IsAlive, () => IsRunning && Player.IsLoggedIn, -1);
                    Index = Configuration.RestartUponDeath ? 0 : Index - 1;
                }

                if (!Player.IsLoggedIn)
                {
                    if (Configuration.AutoRelogin)
                    {
                        OptionsManager.Stop();
                        await AutoRelogin.Login(Configuration.Server, Configuration.RelogDelay, _ctsBot, Configuration.RelogRetryUponFailure);
                        Index = 0;
                        this.LoadAllQuests();
                        this.LoadBankItems();
                        OptionsManager.Start();
                    }
                    else
                    {
                        Stop();
                        return;
                    }
                }

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.RestIfHp)
                    await RestHealth();

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.RestIfMp)
                    await RestMana();

                if (_ctsBot.IsCancellationRequested)
                    return;

                IndexChanged?.Invoke(Index);
                IBotCommand cmd = Configuration.Commands[Index];

                await cmd.Execute(this);

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.BotDelay > 0)
                    if (!Configuration.SkipDelayIndexIf || Configuration.SkipDelayIndexIf && cmd.RequiresDelay())
                        await Task.Delay(_config.BotDelay);

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.Quests.Count > 0)
                   await CheckQuests();

                if (Configuration.Boosts.Count > 0)
                    CheckBoosts();

                Index++;
            }
        }

        private async Task RestHealth()
        {
            if ((double)Player.Health / Player.HealthMax <= (double)Configuration.RestHp / 100)
            {
                if (Configuration.ExitCombatBeforeRest)
                {
                    Player.MoveToCell(Player.Cell, Player.Pad);
                    await Task.Delay(500);
                }
                Player.Rest();
                await this.WaitUntil(() => Player.Health >= Player.HealthMax);
            }
        }

        private async Task RestMana()
        {
            if ((double)Player.Mana / Player.ManaMax <= (double)Configuration.RestMp / 100)
            {
                if (Configuration.ExitCombatBeforeRest)
                {
                    Player.MoveToCell(Player.Cell, Player.Pad);
                    await Task.Delay(500);
                }
                Player.Rest();
                await this.WaitUntil(() => Player.Mana >= Player.ManaMax);
            }
        }

        private void CheckBoosts()
        {
            if (_boostDelayCounter.ElapsedMilliseconds >= 10000)
            {
                foreach (InventoryItem boost in Configuration.Boosts)
                    if (!Player.HasActiveBoost(boost.Name))
                        Player.UseBoost(boost.Id);
                _boostDelayCounter.Restart();
            }   
        }

        private async Task CheckQuests()
        {
            if (World.IsActionAvailable(LockActions.TryQuestComplete))
            {
                if (_questDelayCounter.ElapsedMilliseconds >= 3000)
                {
                    Quest quest = Configuration.Quests.FirstOrDefault(q => q.CanComplete);
                    if (quest != null)
                    {
                        if (_config.ExitCombatBeforeQuest)
                        {
                            Player.MoveToCell(Player.Cell, Player.Pad);
                            await this.WaitUntil(() => Player.CurrentState != Player.State.InCombat);
                            await Task.Delay(1000);
                        }
                        quest.Complete();
                        _questDelayCounter.Restart();
                    }
                }
            }
        }

        private void OnItemDropped(InventoryItem drop)
        {
            NotifyDrop(drop);

            bool isInWhitelist =
                Configuration.Drops.Any(d =>
                    d.Equals(drop.Name, StringComparison.OrdinalIgnoreCase));

            if (Configuration.EnablePickup && isInWhitelist)
                World.DropStack.GetDrop(drop.Id);
        }

        private void NotifyDrop(InventoryItem drop)
        {
            if (Configuration.NotifyUponDrop.Count > 0)
                if (Configuration.NotifyUponDrop.Any(d => d.Equals(drop.Name, StringComparison.OrdinalIgnoreCase)))
                    for (int i = 0; i < 10; i++)
                        Console.Beep();
        }

        private void OnQuestsLoaded(List<Quest> quests)
        {
            List<Quest> qs = 
                quests.Where(q => Configuration.Quests.Any(qq => qq.Id == q.Id)).ToList();

            int len = qs.Count;

            if (qs.Count > 0)
            {
                if (len == 1) qs[0].Accept();
                else // Accepting multiple quests instantly causes a disconnection
                {
                    for (int i = 0; i < len; i++)
                    {
                        int ii = i;
                        Task.Run(async () =>
                        {
                            await Task.Delay(1000 * ii);
                            qs[ii].Accept();
                        });
                    }
                }
            }
        }

        private void OnQuestCompleted(CompletedQuest quest)
        {
            Configuration.Quests.FirstOrDefault(q => q.Id == quest.Id)?.Accept();
        }
    }
}
