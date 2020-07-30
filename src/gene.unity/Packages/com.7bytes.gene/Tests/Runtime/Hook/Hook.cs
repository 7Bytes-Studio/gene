using System.Collections;
using System.Collections.Generic;
using Gene.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Gene.Runtime.Tests
{
    public class Hook
    {
        [Test]
        public void Hook_Passes()
        {
            var gene = new Program();
            Debug.Log(null==gene.app.Use<IHookComponent>());
            IHookComponent hookComponent = gene.app.Use<IHookComponent>();
            hookComponent.Init("宿主");
            hookComponent.Add("BeforeCreate");
            hookComponent.Add("BeforeCreate");
            hookComponent.Add("AfterCreate");
            
            hookComponent.AddHook("BeforeCreate","1",o=>{ Debug.Log("1: "+o); });
            hookComponent.Execute("BeforeCreate");
            
            hookComponent.RemoveHook("BeforeCreate","1");
            hookComponent.Execute("BeforeCreate");
            
            hookComponent.AddHook("BeforeCreate","2",o=>{ Debug.Log("2: "+o); });
            hookComponent.AddHook("BeforeCreate","3",o=>{ Debug.Log("3: "+o); });
            hookComponent.AddHook("BeforeCreate","4",o=>{ Debug.Log("4: "+o); });
            hookComponent.AddHook("BeforeCreate","5",o=>{ Debug.Log("5: "+o); });
            hookComponent.AddHook("BeforeCreate","6",o=>{ Debug.Log("6: "+o); });
            hookComponent.AddHook("AfterCreate", "7",o=>{ Debug.Log("7: "+o); });
            hookComponent.Execute("BeforeCreate");
            hookComponent.Execute("AfterCreate");
            // hookComponent.Execute("BeforeCreateXxx"); error
            
        }
    }
}
