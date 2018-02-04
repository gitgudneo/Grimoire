using System.Threading;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdKill : IBotCommand
    {
        public string Monster { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsMonsterAvailable(Monster), null, 3);

            if (instance.Configuration.WaitForSkills)
                await instance.WaitUntil(() => Player.AllSkillsAvailable);

            if (!instance.IsRunning || !Player.IsAlive || !Player.IsLoggedIn)
                return;

            Player.AttackMonster(Monster);
            
            if (instance.Configuration.Skills.Count > 0)
                Task.Run(() => UseSkills(instance));

            await instance.WaitUntil(() => !Player.HasTarget, null, 360);
            Player.CancelTarget();

            _cts?.Cancel(false);
        }

        private CancellationTokenSource _cts;
        private int _skillIndex;
        private async Task UseSkills(IBotEngine instance)
        {
            _cts = new CancellationTokenSource();
            _skillIndex = 0;

            while (!_cts.IsCancellationRequested && Player.IsLoggedIn && Player.IsAlive)
            {
                Skill s = instance.Configuration.Skills[_skillIndex];

                if (s.Type == Skill.SkillType.Safe)
                {
                    if (s.SafeMp)
                    {
                        if ((double) Player.Mana / Player.ManaMax * 100 <= s.SafeHealth)
                            Player.UseSkill(s.Index);
                    }
                    else
                    {
                        if ((double)Player.Health / Player.HealthMax * 100 <= s.SafeHealth)
                            Player.UseSkill(s.Index);
                    }
                }
                else
                {
                    Player.UseSkill(s.Index);
                }

                int count = instance.Configuration.Skills.Count - 1;

                _skillIndex = _skillIndex >= count ? 0 : ++_skillIndex;
                await Task.Delay(instance.Configuration.SkillDelay);
            }
        }

        public override string ToString()
        {
            return $"Kill {Monster}";
        }
    }
}
