
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using WenSharkGenNHibernate.EN.Default_;


namespace InitializeDB
{
class Program
{
static void Main (string[] args)
{
        System.Console.WriteLine ("-----------------------------------------------------------------------------");
        System.Console.WriteLine ("A new database called: WenSharkGenNHibernate will be created (the previous information will be deleted).");
        System.Console.WriteLine ("-----------------------------------------------------------------------------");
        System.Console.WriteLine ("Are you sure?(Y/N) ");
        String ans = Console.ReadLine ();
        try
        {
                if (ans.ToLower () == "y") {
                        CreateDB.Create ("WenSharkGenNHibernate", "nhibernateUser", "nhibernatePass");
                        var cfg = new Configuration ();
                        cfg.Configure ();
                        cfg.AddAssembly (typeof(UserEN).Assembly);
                        new SchemaExport (cfg).Execute (true, true, false);
                        System.Console.WriteLine ("-----------------------------");
                        System.Console.WriteLine ("Database schema created successfully");
                        System.Console.WriteLine ("-----------------------------");
                }
                /*PROTECTED REGION ID(initializeData) ENABLED START*/
                System.Console.WriteLine ("-------------------------------------------------------");
                System.Console.Write ("Do you want to initialize the data of your database?(Y/N) ");
                ans = System.Console.ReadLine ();
                if (ans.ToLower () == "y") {
                        CreateDB.InitializeData ();
                        System.Console.WriteLine ("-----------------------------------------");
                        System.Console.WriteLine ("The data has been inserted successfully!!");
                        System.Console.WriteLine ("-----------------------------------------");
                }
                /*PROTECTED REGION END*/
        }
        catch (Exception e)
        {
                System.Console.WriteLine (e.Message.ToString () + '\n' + e.StackTrace);
        }

        finally
        {
                System.Console.WriteLine ("Powered by OOH4RIA. Press any key to exit....");
                Console.ReadLine ();
        }
}
}
}
