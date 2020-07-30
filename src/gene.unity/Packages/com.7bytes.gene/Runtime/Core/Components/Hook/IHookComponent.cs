using System;

namespace Gene.Runtime
{
    public interface IHookComponent
    {
        void Init(object target);
        void Add(string hookName);
        void Remove(string hookName);
        void Execute(string hookName);
        
        void AddHook(string hookName,string id,Action<object> hookCallback);
        void RemoveHook(string hookName,string id);
    }
}