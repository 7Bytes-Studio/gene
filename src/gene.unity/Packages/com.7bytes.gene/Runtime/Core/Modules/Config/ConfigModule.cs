using System;
using System.Collections.Generic;

namespace Gene.Runtime
{
    internal class ConfigModule:ModuleBase,IConfigModule
    {
        private List<IConfigurable> m_Configs = new List<IConfigurable>();
        public void Load(IConfigurable config)
        {
            var result = m_Configs.FindIndex(v => v.id == config.id);
            if (-1==result)
            {
                m_Configs.Add(config);
            }
        }

        public IConfigurable GetConfig(Predicate<IConfigurable> predicate)
        {
            return m_Configs.Find(predicate);
        }

        public IEnumerable<IConfigurable> GetConfigs(Predicate<IConfigurable> predicate)
        {
            return m_Configs.FindAll(predicate);
        }
        
    }
}