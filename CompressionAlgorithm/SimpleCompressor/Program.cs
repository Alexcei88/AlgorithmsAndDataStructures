// See https://aka.ms/new-console-template for more information

using System;
using ManyConsole;
using SimpleCompressor.Commands;

ConsoleCommandDispatcher.DispatchCommand(new ConsoleCommand[]
{
    new EncodingCommand(),
    new DecodingCommand(),
}, args, Console.Out);
