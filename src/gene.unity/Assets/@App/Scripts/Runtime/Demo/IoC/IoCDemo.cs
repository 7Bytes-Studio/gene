using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gene.Runtime;
using UnityEngine;

namespace App1
{
    public class IoCDemo : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return null;
            
            var log = Lazy.App.Use<ILog>();
            log.Output();
            
            var fly = Lazy.App.Use<IFly>();
            fly.Fly();
            
            var run = Lazy.App.Use<IRun>();
            run.Run();
        }
    }
}