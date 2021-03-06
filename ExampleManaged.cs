﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;

namespace Test.MODP.net
{
    
    class ExampleManaged
    {
        public static OracleConnection con; // do not do this in real live
        void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = "User Id=scott;Password=TIGER;Data Source=XE";
            con.Open();
           
            Console.WriteLine("Connected to Oracle using Managed OPD.net " + con.ServerVersion);
        }
        void Close()
        {
            con.Close();
            con.Dispose();
        }
        static void Main()
        {
            ExampleManaged exampleManaged = new ExampleManaged();
            exampleManaged.Connect();
            // Reads EMPS
            var command = new OracleCommand("select EMPNO, ENAME from EMP", con);
            int i = 0;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.Out.WriteLine(String.Format("Employee: {0} Emp#: {1}", reader.GetString(1), reader.GetInt32(0)));
                    i++;
                }
                Console.WriteLine(String.Format("{0} employees read",i));
            }

            exampleManaged.Close();
            Console.WriteLine("Connection closed" );
            Console.WriteLine("STOP");

        }
    }
}