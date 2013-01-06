using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch19.ex06
{
    public class Frameworks
    {
        public enum ApplicationSerers
        {
            GlassFish,
            Tomcat,
            JBoss
        }

        public enum Databases
        {
            Oracle,
            DB2,
            PostgreSQL,
            MySQL
        }

        public static bool IsSupport(ApplicationSerers appServer,
                                     Databases database)
        {
            switch (appServer)
            {
                case ApplicationSerers.GlassFish:
                    return true;

                case ApplicationSerers.Tomcat:
                    return database == Databases.MySQL;

                case ApplicationSerers.JBoss:
                    return database == Databases.DB2 || database == Databases.PostgreSQL;

                default:
                    return false;
            }
        }
    }
}
