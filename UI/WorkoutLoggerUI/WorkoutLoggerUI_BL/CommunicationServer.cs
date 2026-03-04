using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WorkoutLoggerUI_BL
{
    public class CommunicationServer
    {
        public static void AddSport(string name, string fields)
        {
            Console.WriteLine("Add sport successfully");
        }

        // TODO: Not avaiable in Python
        public static void RemoveSport(string name)
        {
            Console.WriteLine("Remove sport successfully");
        }

        public static void AddTrain(string year, string sport, string data)
        {
            Console.WriteLine("Add train successfully");
        }

        // TODO: Not avaiable in Python
        public static void RemoveTrain()
        {
            Console.WriteLine("Remove train successfully");
        }

        public static void GetTrain(string sport, string year, string month, string day)
        {
            Console.WriteLine("Get Successuflly");
        }
    }
}
