using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RiotSharp;

namespace lol_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = "d9bee8d5-8a4c-4160-930d-d2a52007d8ef";
            var api = RiotApi.GetInstance(apiKey);
            var staticApi = StaticRiotApi.GetInstance(apiKey);

            string name = "thorvairy pade";


            //           var shards = statusApi.GetShards();

            //            var shardStatus = statusApi.GetShardStatus(RiotSharp.Region.na);

            // Get summoner ID
            var summoner = api.GetSummoner(RiotSharp.Region.na, name);
            var id = summoner.Id;

            var statSummaries = api.GetStatsSummaries(RiotSharp.Region.na, id);

            var championIds = new List<int>();
        }
    }
}
