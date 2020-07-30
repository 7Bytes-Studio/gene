// using System.Collections;
// using Autofac;
// using NUnit.Framework;
// using UnityEngine.TestTools;
// using UnityEngine;
//
// namespace Gene.Runtime.Tests
// {
//     public class Autofac
//     {
//         public interface ILog
//         {
//             void Output();
//         }
//         
//         public class MyLog:ILog
//         {
//             public void Output()
//             {
//                Debug.Log("MyLog");
//             }
//         }
//         
//         public class HerLog:ILog
//         {
//             public void Output()
//             {
//                 Debug.Log("HerLog");
//             }
//         }
//         
//         [Test]
//         public void ContainerBuilder_Passes()
//         {
//             var builder = new ContainerBuilder();
//             builder.RegisterInstance(new MyLog()).As<ILog>();
//             var container = builder.Build();
//             var log = container.Resolve<ILog>();
//             Debug.Log(log.GetType());
//         }
//         
//         [UnityTest]
//         public IEnumerator AutofacWithEnumeratorPasses()
//         {
//             yield return null;
//         }
//     }
// }
