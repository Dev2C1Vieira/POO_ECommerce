/*
 * <copyright file = "MainMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 5:11:47 PM </date>
 * <description></description>
 * 
 * */

using StaffMenu;
using System;
using System.Diagnostics;

namespace ECMenus
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MainMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Clear() { Console.Clear(); }

        /// <summary>
        /// 
        /// </summary>
        public static void Flushtdin() { while (Console.In.Peek() != -1 && Console.In.ReadLine() != null) { } }

        /// <summary>
        /// 
        /// </summary>
        public static void Pause()
        {
            Flushtdin();
            Console.WriteLine("\n\nPress ");
            Console.WriteLine("any key ");
            Console.WriteLine("to continue...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void Menu()
        {
            int op = 1;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to ECommerce Application ---------\n");
                        if (op < 1 || op > 3)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-3]\n");
                        }
                        Console.WriteLine("\nHere you need to login to your account!");
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. I am an employee.                     |");
                        Console.WriteLine("  |  2. I am a manager.                       |");
                        Console.WriteLine("  |  3. Exit Application!                     |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 3);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            EmployeeMenu.Menu();
                            break;
                        case 2:
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            catch (FormatException E)
            {
                Console.WriteLine(E.Message);
                Pause();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                Pause();
            }
            finally
            {
                Menu();
            }
        }
    }
}
