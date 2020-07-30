using System;
using NUnit.Framework;
using UnityEngine;

namespace Gene.Runtime.Tests
{
    public class EventComponent
    {
        [Test]
        public void EventComponent_Passes()
        {
            var gene = new Program();
            
            IEventComponent eventComponent = gene.app.Use<IEventComponent>();
            //监听者 1 添加监听。
            eventComponent.On("test",1, e =>
            {
                Debug.Log("01: "+e);
            });
            //监听者 1 添加新的监听，但是会覆盖之前的监听。
            eventComponent.On("test",1, e =>
            {
                Debug.Log("1: "+e);
            });
            
            //监听者 2 添加监听。
            eventComponent.On("test",2, e =>
            {
                Debug.Log("2: "+e);
            });
            
            //监听者 banana 添加监听。
            eventComponent.On("banana",3, e =>
            {
                Debug.Log("3: "+e);
            });
            
            eventComponent.Fire("test",new { a=123,b="abc" });
            eventComponent.Off("test",1);
            eventComponent.Fire("test",123,"abc");
            
            eventComponent.Fire("banana",456,"abc");
        }

        [Test]
        public void EventComponent_Pars_Passes()
        {
            Delegate d = new Action<int,float,string>(Demo);
            // d.DynamicInvoke(new object[] { 1,1.1f,"ccc",666 }); error
            // d.DynamicInvoke(new object[] { 1,1.1f,"ccc" }); pass 
            // d.DynamicInvoke(new object[] { 1,1.1f });  error
            d.DynamicInvoke(new object[] { 1,null,null });  //参数不够，可以用null来进行填充。
        }


        private void Demo(int a,float b,string c)
        {
            Debug.Log(a+"  "+b+"  "+c);
        }
        
    }
}
