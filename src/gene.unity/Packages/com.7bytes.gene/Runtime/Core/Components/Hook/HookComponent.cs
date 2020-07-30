using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gene.Runtime
{
    internal class HookComponent:ComponentBase,IHookComponent
    {
        private readonly IEventComponent m_EventComponent = new EventComponent();
        
        private object m_Target;
        private void CheckInitOrThrow()
        {
            if (null==m_Target)
            {
                throw new GeneException("请调用Init方法，并初始化target。");
            }
        }

        private List<string> m_DefinedHookNames = new List<string>();
        private void CheckHookIsRegisterOrThrow(string hookName)
        {
            if (!m_DefinedHookNames.Contains(hookName))
            {
                throw new GeneException($"未定义‘{hookName}’，操作无效。");
            }
        }
        
        
        
        public void Init(object target)
        {
            m_Target = target;
        }
        public void Add(string hookName)
        {
            if (!m_DefinedHookNames.Contains(hookName))
            {
                m_DefinedHookNames.Add(hookName);
            }
        }
        public void Remove(string hookName)
        {
            CheckInitOrThrow();
            CheckHookIsRegisterOrThrow(hookName);
            m_EventComponent.Off(hookName);
        }
        public void Execute(string hookName)
        {
            CheckInitOrThrow();
            CheckHookIsRegisterOrThrow(hookName);
            m_EventComponent.Fire(hookName,m_Target);
        }
        
        
        
        
        public void AddHook(string hookName, string id,Action<object> hookCallback)
        {
            CheckInitOrThrow();
            CheckHookIsRegisterOrThrow(hookName);
            m_EventComponent.On(hookName,id,hookCallback);
        }
        public void RemoveHook(string hookName, string id)
        {
            CheckInitOrThrow();
            CheckHookIsRegisterOrThrow(hookName);
            m_EventComponent.Off(hookName,id);
        }
        
    }
}