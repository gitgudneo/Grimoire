using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Grimoire.Tools.Plugins
{
    public class GrimoirePlugin
    {
        private readonly string _path;
        private IGrimoirePlugin _plugin;

        public string Name { get; }
        public string Author => _plugin?.Author ?? string.Empty;
        public string Description => _plugin?.Description ?? string.Empty;
        public string LastError { get; private set; }

        public GrimoirePlugin(string path)
        {
            _path = path;
            Name = Path.GetFileName(path);
        }

        public bool Load()
        {
            Assembly asm;
            Type loader;
            Type[] types;

            try
            {
                asm = Assembly.LoadFile(_path);
            }
            catch (FileLoadException)
            {
                LastError = "An error occurred when loading the file.";
                return false;
            }
            catch (BadImageFormatException)
            {
                LastError = "The assembly specified is invalid.";
                return false;
            }

            try
            {
                types = asm.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }

            if (types.Length == 0)
            {
                LastError = "Unable to retrieve any types in the assembly.";
                return false;
            }

            if ((loader = types.FirstOrDefault(t =>
                    t.IsDefined(typeof(GrimoirePluginEntry), true))) == null)
            {
                LastError = "Could not find a class marked with the GrimoirePluginEntry attribute.";
                return false;
            }

            try
            {
                _plugin = (IGrimoirePlugin) Activator.CreateInstance(loader);
                _plugin.Load();
            }
            catch (Exception exc)
            {
                LastError = $"Unknown error: {exc.Message}";
                return false;
            }

            return true;
        }

        public bool Unload()
        {
            try
            {
                _plugin.Unload();
                return true;
            }
            catch (Exception exc)
            {
                LastError = $"Unknown error: {exc.Message}";
                return false;
            }
        }
    }
}
