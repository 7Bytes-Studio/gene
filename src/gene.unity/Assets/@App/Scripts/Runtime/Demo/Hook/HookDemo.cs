using System.Collections;
using Gene.Runtime;
using UnityEngine;

namespace System
{
    public class HookDemo : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return null;
            Lazy.App.AddHook("BeforeUpdate","HookDemo1",app=>{ Debug.Log("BeforeUpdate"); });
        }
    }
}