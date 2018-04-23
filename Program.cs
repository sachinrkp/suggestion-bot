using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionBot
{
    class Program
    {    
        static void Main(string[] args)
        {
            new Program().StartAsync().GetAwaiter().GetResult();
            // Console.WriteLine("Hello World");

        }
        private DiscordSocketClient _client;

        private CommandHandler _handler;

        

        public async Task StartAsync()
        {

            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, "NDI5MjQ1OTU4Mzg0MTIzOTI0.DZ_GVg.Pnv1a6bubZw27BHiCUDG9_mgvSA");

            await _client.StartAsync();

            _handler = new CommandHandler(_client);

          

            await Task.Delay(-1);

        }

    }
}
