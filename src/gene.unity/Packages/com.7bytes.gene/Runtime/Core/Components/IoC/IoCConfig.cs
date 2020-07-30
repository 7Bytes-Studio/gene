using System.Collections.Generic;

namespace Gene.Runtime
{
    public abstract class IoCConfig
    {
        public abstract List<IoCBinding> bindings { get; }
    }
}