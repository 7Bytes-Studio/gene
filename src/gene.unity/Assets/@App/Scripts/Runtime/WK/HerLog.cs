using UnityEngine;

namespace App1
{
    public class HerLog:ILog
    {
        public void Output()
        {
            Debug.Log("HerLog");
        }
    }
}