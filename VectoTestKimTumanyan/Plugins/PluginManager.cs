using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace VectoTestKimTumanyan.Plugins
{
    public class PluginManager
    {
        public void LoadPlugins(string jsonPath)
        {
            string configFileContent = File.ReadAllText(jsonPath);
            var config = JsonConvert.DeserializeObject<PluginConfig>(configFileContent);


            foreach (var pluginInfo in config.Plugins)
            {
                try
                {

                    var assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pluginInfo.AssemblyPath));

                    Type pluginType = assembly.GetType(pluginInfo.TypeName);
                    var plugin = (IPlugin)Activator.CreateInstance(pluginType);

                    plugin.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading plugin {pluginInfo.Name}: {ex.Message}");
                }
            }
        }

    }
}
