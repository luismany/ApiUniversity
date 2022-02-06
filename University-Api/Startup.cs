using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using University.BL.Data;

namespace University_Api
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // configura el dbcontext para que sea usado como una unica instancia por request
            app.CreatePerOwinContext(UniversityDbContext.Create);
        }
    }
}
