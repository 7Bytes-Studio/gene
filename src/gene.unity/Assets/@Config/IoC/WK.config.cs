using System.Collections.Generic;
using Gene.Runtime;
using App1;
public class WKIoCConfig : IoCConfig,IConfigurable
{
    public string id => "IoC.WK";
    
    
    public override List<IoCBinding> bindings=>new List<IoCBinding>()
    {
        new IoCBinding<ILog,MyLog>()
    };

}
