using System;
using Autofac;
using Autofac.Core;
using UnityEngine;

namespace Gene.Runtime
{
    public class IoCComponent:ComponentBase,IIoCComponent
    {
        private readonly ContainerBuilder m_ContainerBuilder;
        private IContainer m_Container;


        #region Lifetime Scope

        public IoCComponent()
        {
            m_ContainerBuilder = new ContainerBuilder();
        }

        #endregion
        
        
        public void LoadConfig(IoCConfig config)
        {
            foreach (var binding in config.bindings)
            {
                m_ContainerBuilder.RegisterType(binding.implType).As(binding.absType);
            }
        }
        public void Build()
        {
            m_Container = m_ContainerBuilder.Build();
        }
        
        public object Use(Type tp)
        {
            object instance = null;
            m_Container.TryResolve(out instance);
            return instance;
        }
    }
}