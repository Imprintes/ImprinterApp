using McMaster.NETCore.Plugins;
using System.Reflection;

namespace Plugin_Core
{
    public class PluginCore
    {
        public static void LoadPlugin(out List<PluginLoader> loaders, out List<IPlugin> plugins)
        {
            loaders = new List<PluginLoader>();
            // create plugin loaders
            var pluginsDir = Path.Combine(AppContext.BaseDirectory, @"tData/Plugins");
            if (!Directory.Exists(pluginsDir))
                Directory.CreateDirectory(pluginsDir);
            foreach (var dir in Directory.GetDirectories(pluginsDir))
            {
                var dirName = Path.GetFileName(dir);
                var pluginDll = Path.Combine(dir, dirName + ".dll");
                if (File.Exists(pluginDll))
                {
                    var loader = PluginLoader.CreateFromAssemblyFile(
                        pluginDll, config => config.PreferSharedTypes = true);
                //sharedTypes: new[] { typeof(IPlugin) });
                    loaders.Add(loader);
                }
            }
            plugins = new List<IPlugin>();
            // Create an instance of plugin types
            foreach (var loader in loaders)
            {
                foreach (var pluginType in loader
                    .LoadDefaultAssembly()
                    .GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract))
                {
                    // This assumes the implementation of IPlugin has a parameterless constructor
                    var plugin = Activator.CreateInstance(pluginType) as IPlugin;
                        Console.WriteLine($"Created plugin instance '{plugin?.GetName()}'.");
                        plugins.Add(plugin);
                }
            }
        }
    }
    public interface IPlugin
    {
        string GetName();
    }
}