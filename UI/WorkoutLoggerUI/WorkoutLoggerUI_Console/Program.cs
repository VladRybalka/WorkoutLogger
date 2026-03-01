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

                if (menu == 0) break;
                else if(menu == 1)
                {
                    Console.Write("Sport name: ");
                    string name = Console.ReadLine();

                    Console.Write("Fields: ");
                    string fields = Console.ReadLine();

                    CommunicationServer.AddSport(name, fields);
                }
                else if(menu == 2)
                {
                    Console.Write("Sport name: ");
                    string name = Console.ReadLine();

                    CommunicationServer.RemoveSport(name);
                }
                else if (menu == 3)
                {
                    Console.Write("Year: ");
                    string year = Console.ReadLine();

                    Console.Write("Sport name: ");
                    string name = Console.ReadLine();

                    Console.Write("Data: ");
                    string data = Console.ReadLine();

                    CommunicationServer.AddTrain(year, name, data);
                }
                else if (menu == 4)
                {
                    CommunicationServer.RemoveTrain();
                }
                else if (menu == 5)
                {
                    Console.Write("Sport name: ");
                    string name = Console.ReadLine();

                    Console.Write("Year: ");
                    string year = Console.ReadLine();

                    Console.Write("Month: ");
                    string month = Console.ReadLine();

                    Console.Write("Day: ");
                    string day = Console.ReadLine();

                    CommunicationServer.GetTrain(name, year, month, day);
                }

                Console.WriteLine();
            }
        }
    }
}
