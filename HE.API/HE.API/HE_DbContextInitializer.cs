using HE.API.DbContexts;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace HE.API
{
    /// <summary>
    /// Database Initializer copied from http://www.drowningintechnicaldebt.com/ShawnWeisfeld/archive/2011/07/15/entity-framework-code-first-executing-sql-files-on-database-creation.aspx
    /// 
    /// </summary>

    public class HE_DbContextInitializer : CreateDatabaseIfNotExists<HE_IdentityDbContext>
    {
        #region Insert default records into Homemade Eats database
        protected override void Seed(HE_IdentityDbContext context)
        {
            //Create Database
            var dbSetupFilePath = HttpContext.Current.Server.MapPath("~/Schema/Structure/1_HomemadeEats_CreateDB.sql");
            context.Database.ExecuteSqlCommand(File.ReadAllText(dbSetupFilePath));

            //Create Database Tables
            dbSetupFilePath = HttpContext.Current.Server.MapPath("~/Schema/Structure/2_Tables");
            var sqlFiles = Directory.GetFiles(dbSetupFilePath);
            foreach (string sqlFile in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFile));
            }

            //Create Database Table Indexes
            dbSetupFilePath = HttpContext.Current.Server.MapPath("~/Schema/Structure/3_HomemadeEats_CreateTableIndexes.sql");
            context.Database.ExecuteSqlCommand(File.ReadAllText(dbSetupFilePath));

            //Create Database Table Constraints & Keys
            dbSetupFilePath = HttpContext.Current.Server.MapPath("~/Schema/Structure/4_Constraints&Keys");
            sqlFiles = Directory.GetFiles(dbSetupFilePath);
            foreach (string sqlFile in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFile));
            }

            //Create Database Views
            dbSetupFilePath = HttpContext.Current.Server.MapPath("~/Schema/Structure/5_Views");
            sqlFiles = Directory.GetFiles(dbSetupFilePath);
            foreach (string sqlFile in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(sqlFile));
            }

            //Insert Default Data records into database
            dbSetupFilePath = HttpContext.Current.Server.MapPath("~/Schema/Structure/6_Data");
            //for MVC4 only:
            //HttpContext.Server.MapPath("~/App_Data/Schema/Data");

            sqlFiles = Directory.GetFiles(dbSetupFilePath);
            foreach (string dataFile in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(dataFile));
            }

            base.Seed(context);
        }
        #endregion
    }
}