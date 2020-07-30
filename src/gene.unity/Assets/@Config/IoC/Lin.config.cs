using System.Collections.Generic;
using Gene.Runtime;
using App1;
public class LinIoCConfig : IoCConfig,IConfigurable
{
    public string id => "IoC.Lin";
    
    
    public override List<IoCBinding> bindings=>new List<IoCBinding>()
    {
        new IoCBinding<IFly,LinFly>(),
        new IoCBinding<IRun,LinRun>()
    };

}
