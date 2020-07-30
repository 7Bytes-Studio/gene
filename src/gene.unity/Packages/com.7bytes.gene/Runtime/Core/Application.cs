using System;

namespace Gene.Runtime
{
    public class Application:IHook
    {
        private IIoCComponent m_GeneIoC;
        private IIoCComponent m_AppIoC;
        
        #region Lifetime Scope
        
        
        private IHookComponent m_HookComponent; 
        private void Hooks_Init()
        {
            m_HookComponent = m_GeneIoC.Use<IHookComponent>();
            m_HookComponent.Init(this);
            
            m_HookComponent.Add("BeforeInit");
            m_HookComponent.Add("AfterInit");
            
            m_HookComponent.Add("BeforeUpdate");
            m_HookComponent.Add("AfterUpdate");
            
            m_HookComponent.Add("BeforeDestroy");
            m_HookComponent.Add("AfterDestroy");
        }
        public void AddHook(string hookName, string id, Action<object> hookCallback)
        {
            m_HookComponent.AddHook(hookName,id,hookCallback);
        }
        public void RemoveHook(string hookName, string id)
        {
            m_HookComponent.RemoveHook(hookName,id);
        }
        
        
        public Application()
        {
            //实例化框架层IoC模块。
            m_GeneIoC = new IoCComponent();
            //加载框架层IoC配置文件。
            m_GeneIoC.LoadConfig(new GeneIoCConfig());
            m_GeneIoC.Build();
            //初始化生命周期钩子。
            Hooks_Init();
        }
        
        internal void Born()
        {
            m_HookComponent.Execute("BeforeInit");
            
            //实例化应用层IoC模块。
            m_AppIoC = new IoCComponent();
            //加载应用层IoC配置文件。
            var config = m_GeneIoC.Use<IConfigModule>();
            foreach (var conf in config.GetConfigs(v=>v is IoCConfig))
            {
                m_AppIoC.LoadConfig(config as IoCConfig);
            }
            m_AppIoC.Build();
            
            m_HookComponent.Execute("AfterInit");
        }

        internal void Act()
        {
            
        }

        internal void Die()
        {
            
        }

        #endregion

        #region Public
        
        public object Use(Type tp)
        {
            return m_AppIoC.Use(tp)??m_GeneIoC.Use(tp);
        }

        public T Use<T>()
        {
            return (T)Use(typeof(T));
        }

        #endregion
        
        
    }
}