using System;
using System.Collections.Generic;

namespace Gene.Runtime
{
    public interface IConfigModule
    {
        void Load(IConfigurable config);
        IConfigurable GetConfig(Predicate<IConfigurable> predicate);
        IEnumerable<IConfigurable> GetConfigs(Predicate<IConfigurable> predicate);
    }
}