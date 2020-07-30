using Gene.Runtime;

public class ConfigManager
{
    public void Load(IConfigModule config)
    {
        config.Load(new LinIoCConfig());
        config.Load(new WKIoCConfig());
    }  
}