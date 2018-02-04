using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Game.Data;
using Grimoire.Networking;

namespace Grimoire.Game
{
    public class DropStack : IReadOnlyList<InventoryItem>
    {
        public DropStack()
        {
            World.ItemDropped += OnItemDropped;
        }

        private readonly List<InventoryItem> _drops = new List<InventoryItem>();
        private readonly List<KeyValuePair<int, Stopwatch>> _cooldown = new List<KeyValuePair<int, Stopwatch>>();

        public int Count => _drops.Count;

        public InventoryItem this[int index] => index < _drops.Count ? _drops[index] : null;

        public IEnumerator<InventoryItem> GetEnumerator()
        {
            return _drops.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void OnItemDropped(InventoryItem item)
        {
            if (_drops.All(d => d.Id != item.Id))
                _drops.Add(item);
        }

        public async Task<bool> GetDrop(InventoryItem item)
        {
            return await GetDrop(item.Id);
        }

        public async Task<bool> GetDrop(string itemName)
        {
            InventoryItem drop = 
                _drops.FirstOrDefault(d => d.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            return drop != null && await GetDrop(drop.Id);
        }

        public async Task<bool> GetDrop(int itemId)
        {
            if (Contains(itemId))
            {
                _cooldown.RemoveAll(c => c.Value.ElapsedMilliseconds >= 3000);

                if (!IsCoolingDown(itemId))
                {
                    await Proxy.Instance.SendToServer($"%xt%zm%getDrop%{World.RoomId}%{itemId}%");
                    _cooldown.Add(new KeyValuePair<int, Stopwatch>(itemId, Stopwatch.StartNew()));
                    _drops.RemoveAll(d => d.Id == itemId);
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            _drops.Clear();
            _cooldown.Clear();
        }

        private bool IsCoolingDown(int itemId)
        {
            var kvp = _cooldown.FirstOrDefault(i => i.Key == itemId);
            return kvp.Key != 0 && (int)kvp.Value.ElapsedMilliseconds < 3000;
        }

        public bool Contains(InventoryItem item) => Contains(item.Id);

        public bool Contains(int itemId) => _drops.FirstOrDefault(d => d.Id == itemId) != null;

        public bool Contains(string itemName) =>
            _drops.FirstOrDefault(d => d.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase)) != null;
    }
}
