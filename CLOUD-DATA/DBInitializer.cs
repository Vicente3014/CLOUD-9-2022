using CLOUD_LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_DATA
{
    public static class DBInitializer
    {
        public static void Seed(this BaseContext baseContext )
        {
            baseContext.Database.EnsureCreated();
            if(!baseContext.Utilizador.Any())
            {
                baseContext.Utilizador.Add(new UtilizadorModel());

            }

        }
    }
}
