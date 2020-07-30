using System;
using System.Collections.Generic;

namespace Gene.Runtime
{
    internal class EventComponent:ComponentBase,IEventComponent
    {
        private class EventInfo
        {
            public object listener;
            public Delegate callback;
        }
        private Dictionary<string,List<EventInfo>> m_EventDic = new Dictionary<string, List<EventInfo>>();
        private void CheckListenerOrThrow(object listener)
        {
            if (null==listener)
            {
                throw new GeneException("监听者不能为空。");
            }
        }
        
        public void On(string eventName, object listener,Delegate callback)
        {
            CheckListenerOrThrow(listener);
            
            if (!m_EventDic.ContainsKey(eventName))
            {
                m_EventDic.Add(eventName,new List<EventInfo>());
            }
            var result = m_EventDic[eventName].FindIndex(v=>object.Equals(v.listener,listener));
            if (-1==result)
            {
                m_EventDic[eventName].Add(new EventInfo()
                {
                    listener = listener,
                    callback = callback
                });
            }
            else
            {
                m_EventDic[eventName][result].callback = callback;
            }
        }

        public void Off(string eventName, object listener)
        {
            CheckListenerOrThrow(listener);
            
            if (m_EventDic.ContainsKey(eventName))
            {
                var result = m_EventDic[eventName].FindIndex(v=>object.Equals(v.listener,listener));
                if (-1<result)
                {
                    m_EventDic[eventName].RemoveAt(result);
                }
            }
        }

        public void Off(string eventName)
        {
            if (m_EventDic.ContainsKey(eventName))
            {
                m_EventDic.Remove(eventName);
            }
        }
        
        
        public void Fire(string eventName,params object[] args)
        {
            if (m_EventDic.ContainsKey(eventName))
            {
                foreach (var eventInfo in m_EventDic[eventName])
                {
                    var pis = eventInfo.callback.Method.GetParameters(); //获取方法参数列表。
                    var pars = new object[pis.Length]; //定义参数列表。
                    if (0 != pis.Length)
                    {
                        for (int i = 0; i < pars.Length; i++)
                        {
                            pars[i] = i<args.Length?args[i]:null;
                        }
                        eventInfo.callback?.DynamicInvoke(pars);
                    }
                    else
                    {
                        eventInfo.callback?.DynamicInvoke(null);
                    }
                }
            }
        }
    }
    
}