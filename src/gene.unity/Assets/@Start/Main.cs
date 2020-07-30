using Gene.Runtime;
using UnityEngine;

public class Main : MonoBehaviour
{
        
    #region Lifetime Scope

    private Program m_Gene;
    private void Start()
    {
        //实例化框架程序。
        m_Gene = new Program();
        //加载配置文件清单。
        new ConfigManager().Load(m_Gene.app.Use<IConfigModule>());
        //生命周期开始。
        m_Gene.Born();
    }

    private void Update()
    {
        m_Gene.Act();
    }

    private void OnDestroy()
    {
        m_Gene.Die();
    }
            
    #endregion

    
}


