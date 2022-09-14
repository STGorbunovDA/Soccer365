using System;
using System.Collections.Generic;
using System.IO;

namespace Soccer365
{
    internal class Setting
    {
        static volatile Setting Class;
        static object SyncObject = new object();
        public static Setting GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        if (Class == null)
                            Class = new Setting();
                    }
                return Class;
            }
        }
        internal void CheckingFileAvailability(string cmB_years_game)
        {
            if (!Directory.Exists($"C:\\Soccer\\"))
            {
                Directory.CreateDirectory($"C:\\Soccer\\");
            }

            //var fileName = $"C:\\Soccer\\{cmB_years_game.Replace('/', '.')}.txt";
            //if (!Directory.Exists(fileName))
            //{
            //    try
            //    {
            //        File.Delete(fileName);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("The deletion failed: {0}", e.Message);
            //    }
            //}
        }

    }
}
