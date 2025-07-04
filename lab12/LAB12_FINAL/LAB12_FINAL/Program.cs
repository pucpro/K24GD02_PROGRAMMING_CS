using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace LAB12_FINAL
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int Coins { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }

    internal class Program
    {
        static string jsonUrl = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/lab12_players.json";
        static string firebaseUrl = "https://lab12-5e10e-default-rtdb.firebaseio.com/";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
            });

            DateTime now = new DateTime(2025, 07, 01, 0, 0, 0, DateTimeKind.Utc);

            var players = await GetPlayersAsync();
            await InactiveLowLevelPlayers(players, now);
            await HighLevelRichPlayers(players);
            await Top3ActiveCoinAward(players, now);
        }

        static async Task<List<Player>> GetPlayersAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string json = await client.GetStringAsync(jsonUrl);
                    return JsonConvert.DeserializeObject<List<Player>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Lỗi khi tải JSON: {ex.Message}");
                return new List<Player>();
            }
        }

        static async Task InactiveLowLevelPlayers(List<Player> players, DateTime now)
        {
            var result = players
                .Where(p => (!p.IsActive || (now - p.LastLogin).TotalDays > 10) && p.Level <= 8)
                .Select(p => new
                {
                    p.Name,
                    p.IsActive,
                    p.Level,
                    LastLogin = p.LastLogin.ToString("yyyy-MM-ddTHH:mm:ssZ")
                })
                .ToList();


            Console.WriteLine("\n Người chơi không hoạt động và cấp thấp:");
            foreach (var p in result)
                Console.WriteLine($"- {p.Name}, Active: {p.IsActive}, Level: {p.Level}, Login: {p.LastLogin}");

            var firebase = new FirebaseClient(firebaseUrl);
            await firebase.Child("inactive_low_level_players").PutAsync(result);

        }

        static async Task HighLevelRichPlayers(List<Player> players)
        {
            var result = players
                .Where(p => p.Level >= 12 && p.Gold > 2000)
                .Select(p => new
                {
                    p.Name,
                    p.Level,
                    CurrentGold = p.Gold
                })
                .ToList();

            Console.WriteLine("\n Người chơi cấp cao và giàu có:");
            foreach (var p in result)
                Console.WriteLine($"- {p.Name}, Level: {p.Level}, Gold: {p.CurrentGold}");

            var firebase = new FirebaseClient(firebaseUrl);
            await firebase.Child("highlevel_rich_players").PutAsync(result);
        
        }

        static async Task Top3ActiveCoinAward(List<Player> players, DateTime now)
        {
            var top3 = players
                .Where(p => p.IsActive && (now - p.LastLogin).TotalDays <= 3)
                .OrderByDescending(p => p.Coins)
                .Take(3)
                .Select((p, index) =>
                {
                    int rank = index + 1;
                    int award = rank == 1 ? 3000 : rank == 2 ? 2000 : 1000;

                    return new
                    {
                        p.Name,
                        p.Level,
                        p.Coins,
                        Rank = rank,
                        AwardedCoinAmount = award
                    };
                })
                .ToList();

            Console.WriteLine("\n Top 3 người chơi hoạt động nhận thưởng:");
            foreach (var p in top3)
                Console.WriteLine($"- Rank {p.Rank}: {p.Name}, Level: {p.Level}, Coins: {p.Coins}, Award: {p.AwardedCoinAmount}");

            var firebase = new FirebaseClient(firebaseUrl);
            await firebase.Child("top3_active_coin_awards").PutAsync(top3);
        }
    }
}