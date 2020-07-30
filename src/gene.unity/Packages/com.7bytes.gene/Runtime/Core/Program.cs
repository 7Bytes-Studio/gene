namespace Gene.Runtime
{
    public class Program
    {
        private Application m_App;
        public Application app => m_App;
        public Program()
        {
            m_App = new Application();
        }
        
        public void Born()
        {
            m_App.Born();
        }

        public void Act()
        {
            m_App.Act();
        }

        public void Die()
        {
            m_App.Die();
        }
    }
}


