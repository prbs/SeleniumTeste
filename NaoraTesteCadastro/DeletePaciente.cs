using AvilaCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaoraTestePerfilUsuario
{
    public class DeletePaciente
    {

        public static void deletePaciente( string procedure,string[] parameterName, string[] parameterValue) {

            //connStr.ConnectionString = ConfigurationManager.ConnectionStrings["NaoraTeste"].ConnectionString;

            AvilaApplication.InitializeHelpers();
            AvilaApplication.DataManipulation.Configure("avilasolucoes@oe0dc5r5n9", "@vil@2015", "oe0dc5r5n9.database.windows.net,1433", "naora_dev", false);
            Assert.IsTrue(AvilaApplication.DataManipulation.CheckConnection());

            AvilaApplication.DataManipulation.ExecuteProcedure("sp_deleteusuario", parameterName, parameterValue);

        }

    }
}
