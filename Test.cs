using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionBot.Modules
{     
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("bello")]
        public async Task fun1()
        {
            await Context.Channel.SendMessageAsync("Hello! Human");
        }
        //------------------------------
        [Command("test")]
        public async Task fun2(IRole user)
        {
          /*  var guild = user.Guild;
            var channel = guild.DefaultChannel;
            await channel.SendMessageAsync($"welcome, {user.Mention}"); */
            await Context.Channel.SendMessageAsync(user.ToString());
        }
        //---------------------------
        [Command("helpsug")]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.AddField("<< Suggestion Bot Commands >>", "These are commands available for Suggestion_Bot")
                .AddInlineField("!invitesug", "Use this command to invite this bot")
                .AddInlineField("!leavesug", "Use this command (user who Manages Server) can make bot to leave this server")
                .AddInlineField("!bello", "This command makes the Bot to say Hello back to user")
                .AddInlineField("!helpsug", "This command gives the entire list of commands available for Suggestion Bot")
                .AddInlineField("!say", "This command makes the Bot to say whatever user has typed")
                .AddInlineField("!pingsb", "This command makes the Bot to reply with Pong! message if user pings the bot")
                .AddInlineField("!purgesug", "This command makes the Bot to delete the number of messages . It must have the permission to manage messages")
                .AddInlineField("!pings1","This command displays the Bot Name || User who sent command and what message was sent");


            await ReplyAsync("", false, builder.Build());
        }
        /////////////////////////
        [Command("pings1")]
        public async Task PingAsync1()
        {

            await ReplyAsync($"{Context.Client.CurrentUser.Mention} || {Context.User.Mention} sent {Context.Message.Content} in {Context.Guild.Name}! server");

        }
        ///////////////////////////////////
        [Command("say")]     //similar command as saysug
        public async Task PingAsync2([Remainder] string StuffToSay)
        {
            await ReplyAsync(StuffToSay);
        }
        ///////////////////////////////
        [Command("saysug")]      // similar command as say
        [Alias("echo")]
        [Summary("Echos the provided input")]
        public async Task Say([Remainder] string input)
        {
            await ReplyAsync(input);
        }
        /////////////////////////////////

        [Command("leadersays"),RequireUserPermission(GuildPermission.BanMembers)]
        public async Task PingAsync3([Remainder] string StuffToSay)
        {

            // Context.User;
            // Context.Client;
            // Context.Guild;
            // Context.Message;
            // Context.Channel;
            //   await ReplyAsync($"{name} is a Noob ");
            await ReplyAsync(StuffToSay);
        }

        [Group("pingsb")]
        public class ping : ModuleBase<SocketCommandContext>
        {
            [Command]
            public async Task DefaultPing()
            {
                await ReplyAsync(" Pong! ");
            }

            [Command("user")]
            public async Task PingUser(SocketGuildUser user)
            {
                await ReplyAsync($" Pong ! {user.Mention}");
            }
        }


        //////////////
        [Command("invitesug")]
        [Summary("Returns the OAuth2 Invite URL of the bot")]
        public async Task Invite()
        {
            var application = await Context.Client.GetApplicationInfoAsync();
            await ReplyAsync(
                $"A user with `MANAGE_SERVER` can invite me to your server here: <https://discordapp.com/oauth2/authorize?client_id={429245958384123924}&scope=bot>");
        }

        [Command("leavesug")]
        [Summary("Instructs the bot to leave this Guild.")]
        [RequireUserPermission(GuildPermission.ManageGuild)]
        public async Task Leave()
        {
            if (Context.Guild == null) { await ReplyAsync("This command can only be ran in a server."); return; }
            await ReplyAsync("Leaving, Bye ! ");
            await Context.Guild.LeaveAsync();
        }
        //////////////////////
        [Command("purge")]
        [Name("purge <amount>")]
        [Summary("Deletes a specified amount of messages")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DelMesAsync(int delnum)
        {
            var items = await Context.Channel.GetMessagesAsync(delnum + 1).Flatten();
            await Context.Channel.DeleteMessagesAsync(items);
        }


    }
}
