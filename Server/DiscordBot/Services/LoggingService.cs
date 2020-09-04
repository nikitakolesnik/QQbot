﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
//using System.IO;
using System.Threading.Tasks;

public class LoggingService
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commands;

    //private string LogDirectory { get; }
    //private string LogFile => Path.Combine(LogDirectory, $"{DateTime.UtcNow:yyyy-MM-dd}.txt");

    public LoggingService(DiscordSocketClient client, CommandService commands)
    {
        //LogDirectory = Path.Combine(AppContext.BaseDirectory, "logs");

        _client = client;
        _commands = commands;

        _client.Log += OnLogAsync;
        _commands.Log += OnLogAsync;
    }

    private Task OnLogAsync(LogMessage msg)
    {
        //if (!Directory.Exists(LogDirectory))     // Create the log directory if it doesn't exist
        //    Directory.CreateDirectory(LogDirectory);
        //if (!File.Exists(LogFile))               // Create today's log file if it doesn't exist
        //    File.Create(LogFile).Dispose();

        //string logText = $"{DateTime.UtcNow:hh:mm:ss} [{msg.Severity}] {msg.Source}: {msg.Exception?.ToString() ?? msg.Message}";
        //File.AppendAllText(LogFile, logText + "\n");     // Write the log text to a file

        return Console.Out.WriteLineAsync(msg.ToString());       // Write the log text to the console
    }
}