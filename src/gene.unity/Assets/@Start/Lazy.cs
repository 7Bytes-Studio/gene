using Gene.Runtime;

public static class Lazy
{
      private static Application s_App;
      public static Application App => s_App;
      
      public static void SetApp(Application app)
      {
            if (null==s_App)
            {
                  s_App = app;
            }
      }
      
}