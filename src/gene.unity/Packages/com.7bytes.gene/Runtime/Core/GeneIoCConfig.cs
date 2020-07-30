using System.Collections.Generic;
using UnityEngine;

namespace Gene.Runtime
{
    internal class GeneIoCConfig:IoCConfig
    {
        public override List<IoCBinding> bindings => new List<IoCBinding>()
        {
            //Modules
            new IoCBinding<IConfigModule,ConfigModule>(),
            //Components
            new IoCBinding<IEventComponent,EventComponent>(),
            new IoCBinding<IHookComponent,HookComponent>()
        };
    }
}