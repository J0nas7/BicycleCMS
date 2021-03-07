using System.Web;

namespace BicycleCMS
{
    public class Global : HttpApplication
    {
        public static DatabaseController DB = DatabaseController.getInstance();

        protected void Application_Start()
        {
        }
    }
}
