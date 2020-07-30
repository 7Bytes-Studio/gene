using UnityEngine;

namespace App1
{
    public class MyLog:ILog
    {
        public void Output()
        {
            Debug.Log("MyLog");
        }
    }
}