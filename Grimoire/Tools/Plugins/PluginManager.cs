using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grimoire.Tools.Plugins
{
    public class PluginManager
    {
        public List<GrimoirePlugin> LoadedPlugins = new List<GrimoirePlugin>();

        public string LastError { get; private set; }

        public bool Load(string path)
        {
            GrimoirePlugin plugin = null;

            if (File.Exists(path))
            {
                plugin = new GrimoirePlugin(path);

                if (plugin.Load())
                {
                    LoadedPlugins.Add(plugin);
                    return true;
                }
            }

            LastError = plugin?.LastError;
            return false;
        }

        public bool Unload(GrimoirePlugin plugin)
        {
            if (plugin.Unload())
            {
                LoadedPlugins.Remove(plugin);
                return true;
            }

            LastError = plugin.LastError;
            return false;
        }

        public bool LoadRange(string[] paths) => paths.All(Load);

        public bool UnloadAll() => LoadedPlugins.All(p => p.Unload());
    }
}
