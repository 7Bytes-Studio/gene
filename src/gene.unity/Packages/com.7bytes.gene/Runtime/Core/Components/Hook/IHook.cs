using System;

namespace Gene.Runtime
{
    public interface IHook
    {
        void AddHook(string hookName,string id,Action<object> hookCallback);
        void RemoveHook(string hookName,string id);
    }
}