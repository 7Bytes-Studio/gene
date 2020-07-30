using System;

namespace Gene.Runtime
{
    public static class IEventComponentEx
    {
        public static void On(this IEventComponent eventComponent,string eventName,object listener,Action<object> callback)
        {
            eventComponent.On(eventName,listener,callback);
        }
        
        public static void On(this IEventComponent eventComponent,string eventName,object listener,Action<object,object> callback)
        {
            eventComponent.On(eventName,listener,callback);
        }
        
    }
}