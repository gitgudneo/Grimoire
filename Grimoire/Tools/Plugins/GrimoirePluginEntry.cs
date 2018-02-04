using System;

namespace Grimoire.Tools.Plugins
{
    /* TODO: Re-evaluate whether we actually need this attribute,
       it is not required to find the type that implements IGrimoirePlugin */
    [AttributeUsage(AttributeTargets.Class)]
    public class GrimoirePluginEntry : Attribute
    {

    }
}
