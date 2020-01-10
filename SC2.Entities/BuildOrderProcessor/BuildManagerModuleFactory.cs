using System.Collections.Generic;
using SC2.Entities.BuildOrderProcessor.Modules;

namespace SC2.Entities.BuildOrderProcessor
{
    public class BuildManagerModuleFactory
    {
        private static readonly Dictionary<string, IBuildOrderProcessorModule> ModulesDictionary;

        static BuildManagerModuleFactory()
        {
            ModulesDictionary = new Dictionary<string, IBuildOrderProcessorModule>();
            AddModule(new CastModule());
            AddModule(new LarvaModule());
            AddModule(new ChronoboostModule());
            AddModule(new ResourceModule());
            AddModule(new IdleModule());
            AddModule(new LotvChronoboostModule());
            AddModule(new LotvLarvaModule());
        }

        private static void AddModule(IBuildOrderProcessorModule module)
        {
            ModulesDictionary[module.ModuleName] = module;
        }

        public static IBuildOrderProcessorModule GetModule(string moduleName)
        {
            return ModulesDictionary[moduleName];
        }
    }
}
