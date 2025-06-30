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

namespace LAB11
{
    public class Player
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Coins { get; set; }
        public int VipLevel { get; set; }
        public string Region { get; set; }
        public DateTime LastLogin { get; set; }
    }

    internal class Program
    {

        static string jsonUrl = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
        static string firebaseUrl = "https://lab11-7f500-default-rtdb.firebaseio.com/"; 


        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
            });

            Console.WriteLine(" Đang tải dữ liệu người chơi...");
            var players = await GetPlayersAsync();

            await quiz_bai1_richPlayers(players);
            await quiz_bai2_recentVipPlayers(players);
            await DangMaSoSinhVien("124010124099");
        }
        static async Task DangMaSoSinhVien(string mssv)
        {
            var firebase = new FirebaseClient(firebaseUrl);
            await firebase.Child("Masosinhvien").PutAsync(mssv);
            Console.WriteLine($" Mã số sinh viên {mssv} ");
        }

        static async Task<List<Player>> GetPlayersAsync()
        {
            using (var client = new HttpClient())
            {
                string json = await client.GetStringAsync(jsonUrl);
                return JsonConvert.DeserializeObject<List<Player>>(json);
            }
        }

        static async Task quiz_bai1_richPlayers(List<Player> players)
        {
            var richPlayers = players
                .Where(p => p.Gold > 1000 && p.Coins > 100)
                .OrderByDescending(p => p.Gold)
                .Select(p => new
                {
                    p.Name,
                    p.Gold,
                    p.Coins
                })
                .ToList();

            Console.WriteLine("\n Người chơi giàu có:");
            foreach (var p in richPlayers)
            {
                Console.WriteLine($"Tên: {p.Name}, Gold: {p.Gold}, Coins: {p.Coins}");
            }

            var firebase = new FirebaseClient(firebaseUrl);
            await firebase.Child("quiz_bai1_richPlayers").PutAsync(richPlayers);
        }

        static async Task quiz_bai2_recentVipPlayers(List<Player> players)
        {
            var firebase = new FirebaseClient(firebaseUrl);


            int vipCount = players.Count(p => p.VipLevel > 0);
            Console.WriteLine($"\n Tổng số người chơi VIP: {vipCount}");

            var groupedVip = players
                .Where(p => p.VipLevel > 0)
                .GroupBy(p => p.Region)
                .Select(g => new
                {
                    Region = g.Key,
                    Count = g.Count()
                })
                .ToList();

            Console.WriteLine("\n Số lượng người chơi VIP theo khu vực:");
            foreach (var g in groupedVip)
            {
                Console.WriteLine($"- Khu vực: {g.Region}, Số người chơi VIP: {g.Count}");
            }
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);

            var recentVip = players
                .Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
                .Select(p => new
                {
                    p.Name,
                    p.VipLevel,
                    LastLogin = p.LastLogin.ToString("yyyy-MM-dd HH:mm:ss")
                })
                .ToList();

            Console.WriteLine("\n VIP mới đăng nhập (trong 2 ngày):");
            foreach (var p in recentVip)
            {
                Console.WriteLine($"Tên: {p.Name}, VIP: {p.VipLevel}, LastLogin: {p.LastLogin}");
            }
            await firebase.Child("quiz_bai2_recentVipPlayers").PutAsync(recentVip);
        }

    }
}