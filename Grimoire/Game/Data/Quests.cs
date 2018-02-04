using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
    public class Quests
    {
        public event Action<List<Quest>> QuestsLoaded;

        public event Action<CompletedQuest> QuestCompleted;

        public void OnQuestsLoaded(List<Quest> quests) => QuestsLoaded?.Invoke(quests);

        public void OnQuestCompleted(CompletedQuest quest) => QuestCompleted?.Invoke(quest);

        public List<Quest> QuestTree => Flash.Call<List<Quest>>("GetQuestTree");
               
        public List<Quest> AcceptedQuests => QuestTree.Where(q => q.IsInProgress).ToList();
               
        public List<Quest> UnacceptedQuests => QuestTree.Where(q => !q.IsInProgress).ToList();
               
        public List<Quest> CompletedQuests => QuestTree.Where(q => q.CanComplete).ToList();
               
        public void Accept(int questId) => Flash.Call("Accept", questId.ToString());

        public void Accept(string questId) => Flash.Call("Accept", questId);

        public void Complete(int questId) => Flash.Call("Complete", questId.ToString());

        public void Complete(string questId) => Flash.Call("Complete", questId);

        public void Complete(string questId, string itemId) => Flash.Call("Complete", itemId, bool.TrueString);

        public void Load(int id) => Flash.Call("LoadQuest", id.ToString());
               
        public void Load(List<int> ids) => Flash.Call("LoadQuests", string.Join(",", ids));

        public void Get(List<int> ids) => Flash.Call("GetQuests", string.Join(",", ids.Select(i => i.ToString())));
               
        public bool IsInProgress(int id) => Flash.Call<bool>("IsInProgress", id.ToString());

        public bool IsInProgress(string id) => Flash.Call<bool>("IsInProgress", id);

        public bool CanComplete(int id) => Flash.Call<bool>("CanComplete", id.ToString());

        public bool CanComplete(string id) => Flash.Call<bool>("CanComplete", id);
    }
}
