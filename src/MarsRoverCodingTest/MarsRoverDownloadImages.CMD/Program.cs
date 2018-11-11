using System;
using System.Collections.Generic;
using ManyConsole;
using MarsRover.Data.Mapper;
using MarsRover.Unity;

namespace MarsRoverDownloadImages.CMD
{
    public static class Program
    {

        public static int Main(string[] args)
        {

            StartUp();

            var commands = GetCommands();

            return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);


        }

        private static void StartUp()
        {
            UnitySetup.RegisterComponents();
            AutoMapperConfig.Initialize();
        }

        public static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
        }
    }
}