using System;

namespace Gene.Runtime
{
    public interface IEventComponent
    {
        void On(string eventName,object listener,Delegate callback);
        void Off(string eventName,object listener);
        void Off(string eventName);
        void Fire(string eventName,params object[] args);
    }
}