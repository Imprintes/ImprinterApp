using Plugin_Core;
using System;

namespace TestPluginA
{
    public class PluginA : IPlugin
    {
        public string GetName()
        {
            return "Plugin for A";
        }
    }
}
