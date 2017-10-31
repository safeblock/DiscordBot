using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace SafeBlock
{
    public class Bot
    {
        DiscordClient Discord;

        public Bot()
        {
            Discord = new DiscordClient();
            Discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var Command = Discord.GetService<CommandService>();

            Command.CreateCommand("btc").Do((e) =>
            {
                using (WebClient Api = new WebClient())
                {
                    string Price = Api.DownloadString("https://bitpay.com/api/rates/eur");
                    dynamic Json = JsonConvert.DeserializeObject(Price);
                    e.Channel.SendMessage(double.Parse(Convert.ToString(Json.rate)).ToString("C"));
                    Api.Dispose();
                }
            });

            Command.CreateCommand("sigmar").Do((e) =>
            {
                e.Channel.SendMessage("https://openclassrooms.com/courses/apprenez-a-developper-en-c");
            });

            Command.CreateCommand("twitter").Do((e) =>
            {
                e.Channel.SendMessage("https://twitter.com/safeblock_io");
            });

            Command.CreateCommand("porn").Do((e) =>
            {
                e.Channel.SendMessage("https://nxxporn.com");
            });

            /*Command.CreateCommand("porn").Do((e) =>
            {
                e.Channel.SendMessage("https://nxxporn.com");
                e.Channel.Client
            });*/

            Command.CreateCommand("eth").Do((e) =>
            {
                using (WebClient Api = new WebClient())
                {
                    string Price = Api.DownloadString("https://api.kraken.com/0/public/Ticker?pair=XETHZEUR");
                    dynamic Json = JsonConvert.DeserializeObject(Price);
                    e.Channel.SendMessage(double.Parse(Convert.ToString(Json.result["XETHZEUR"]["p"][0]), CultureInfo.InvariantCulture).ToString("C"));
                    Api.Dispose();
                }
            });

            Command.CreateCommand("dash").Do((e) =>
            {
                using (WebClient Api = new WebClient())
                {
                    string Price = Api.DownloadString("https://api.kraken.com/0/public/Ticker?pair=DASHZEUR");
                    dynamic Json = JsonConvert.DeserializeObject(Price);
                    e.Channel.SendMessage(double.Parse(Convert.ToString(Json.result.DASHZEUR.p[0]), CultureInfo.InvariantCulture).ToString("C"));
                    Api.Dispose();
                }
            });

            Command.CreateCommand("xrp").Do((e) =>
            {
                using (WebClient Api = new WebClient())
                {
                    string Price = Api.DownloadString("https://api.kraken.com/0/public/Ticker?pair=XXRPZEUR");
                    dynamic Json = JsonConvert.DeserializeObject(Price);
                    e.Channel.SendMessage(double.Parse(Convert.ToString(Json.result.XXRPZEUR.p[0]), CultureInfo.InvariantCulture).ToString("C"));
                    Api.Dispose();
                }
            });

            Command.CreateCommand("ltc").Do((e) =>
            {
                using (WebClient Api = new WebClient())
                {
                    string Price = Api.DownloadString("https://api.kraken.com/0/public/Ticker?pair=XLTCZEUR");
                    dynamic Json = JsonConvert.DeserializeObject(Price);
                    e.Channel.SendMessage(double.Parse(Convert.ToString(Json.result.XLTCZEUR.p[0]), CultureInfo.InvariantCulture).ToString("C"));
                    Api.Dispose();
                }
            });

            Task.Run(() =>
            {
                Discord.Connect("MzcyMTIwNTExNDQ4MzUwNzIw.DM_jww.k9d34kp37kD_xFEIKq7D1-_ADmY", TokenType.Bot);
                Discord.SetStatus(UserStatus.Online);
                Discord.SetGame("NxxPorn.com");
            });

            Console.ReadLine();
        }
    }
}