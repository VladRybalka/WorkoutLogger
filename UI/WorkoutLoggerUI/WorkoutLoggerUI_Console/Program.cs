using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutLoggerUI_BL;

namespace WorkoutLoggerUI_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Menu:\n1 - add sport;\n2 - remove sport;" +
                              "\n3 - add train;\n4 - remove train;\n5 - get train;" +
                              "\n0 - Exit\nEnter => ");
                int menu = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine();

                switch (menu)
                {
                    case 0:
                        break;
                    case 1:
                        CommunicationServer.AddSport();
                        break;
                    case 2:
                        CommunicationServer.RemoveSport();
                        break;
                    case 3:
                        CommunicationServer.AddTrain();
                        break;
                    case 4:
                        CommunicationServer.RemoveTrain();
                        break;
                    case 5:
                        CommunicationServer.GetTrain();
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
