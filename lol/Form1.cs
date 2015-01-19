using RiotSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lol
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
            test();
		}

        static void test()
        {
            string apiKey = "d9bee8d5-8a4c-4160-930d-d2a52007d8ef";
            var api = RiotApi.GetInstance(apiKey);
            var staticApi = StaticRiotApi.GetInstance(apiKey);
//            var statusApi = StatusRiotApi.GetInstance();
//            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = "thorvairy pade";//ConfigurationManager.AppSettings["Summoner1Name"];
 //           int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
//            string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
 //           string team = ConfigurationManager.AppSettings["Team1Id"];
//            string team2 = ConfigurationManager.AppSettings["Team2Id"];

 //           var shards = statusApi.GetShards();

//            var shardStatus = statusApi.GetShardStatus(RiotSharp.Region.na);

            // Get summoner ID
            var summoner = api.GetSummoner(RiotSharp.Region.na, name);
            var id = summoner.Id;

            var statSummaries = api.GetStatsSummaries(RiotSharp.Region.na, id);

            var championIds = new List<int>();
/*            for (int i = 0; i < 30; i += 15)
            {
                var matches = api.GetMatchHistory(RiotSharp.Region.na, id, i, i + 15, null,
                    new List<Queue>() { Queue.RankedSolo5x5 });
                foreach (var match in matches)
                {
                    championIds.Add(match.Participants[0].ChampionId);
                }
            }
 */           var mostPlayedChampId = championIds.GroupBy(c => c).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            var mostPlayedChamp = staticApi.GetChampion(RiotSharp.Region.na, mostPlayedChampId);
            Console.WriteLine(mostPlayedChamp.Name);

            var games = api.GetRecentGames(RiotSharp.Region.na, id);

            Console.ReadLine();
        }
	}
}
