using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soardibot.Dto;
using Telegram.Bot;
using Telegram.Bot.Types;
using TeleSharp.TL;
using Xunit;

namespace Soardibot.Tests.Acceptance
{
    public class TheBotListensForCommands
    {
        const long SoardiBotSpammerId = 783918937;
        const long SoardiBotId = 780264154;

        //[Fact]
        public async void MyidCommand_GivesYouBack_YourTelegramId()
        {
            SoardiBotServer server = new SoardiBotServer();
            server.Start();

            var secrets = Secrets.FromXml("secrets.xml");

            //var client = new TelegramClient(secrets.Telegram.TestAppId, secrets.Telegram.TestAppHash);
            //await client.ConnectAsync();

            //string phoneNumber = secrets.Telegram.PhoneNumber;
            //string code = secrets.Telegram.Code;
            //var hash = await client.SendCodeRequestAsync(phoneNumber);
            //var user = await client.MakeAuthAsync(phoneNumber, hash, code);

            //var response = await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "/myid");
        }
    }

    public class SoardiBotServer
    {
        public void Start()
        {
        }
    }
}
