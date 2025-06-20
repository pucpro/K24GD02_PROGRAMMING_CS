using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace lab7bai1
{
    internal class Program
    {
        private static string firebaseUrl = "https://semi-final-labs-default-rtdb.firebaseio.com/";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("firesharp installed successfully");
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("serviceAccountkey.json")
            });

            Console.WriteLine("Firebase initialized successfully."); 
            await GenerateTestPlayer();
            await DeletePlayer();
            await LoadLeaderboard();       
            await UpdatePlayers();     
        }
        public static async Task GenerateTestPlayer()
        {
            var firebase = new FirebaseClient(firebaseUrl);
            var random = new Random();

            string[] tenNguoiChoi = {
                "NguyenVanAn", "TranThiBich", "LeMinhTuan", "PhamNgocLan", "DangHuuKhanh",
                "HoangThanhHuy", "VoThiMy", "DoManhCuong", "NguyenBaoTrang", "TrinhTuanKiet"
            };

            foreach (var name in tenNguoiChoi)
            {
                int gold = random.Next(1000, 10000);
                int score = random.Next(100, 500);
                string playerId = random.Next(1000, 9999).ToString();

                await firebase.Child("Players").Child(name).PutAsync(new
                {
                    name = name,
                    playerid = random.Next(1000, 9999).ToString(), 
                    gold = gold,
                    score = score

                });
                Console.WriteLine($"Đã tạo người chơi: {name}");
            }

            Console.WriteLine("\n Tạo danh sách người chơi hoàn tất.");
        }
        public static async Task DeletePlayer()
        {
            var firebase = new FirebaseClient(firebaseUrl);
            await firebase.Child("NguyenVanAn").DeleteAsync();
            Console.WriteLine("da xoa nguoi choi!");
        }

        public static async Task LoadLeaderboard()
        {
            var firebase = new FirebaseClient(firebaseUrl);
            var players = await firebase.Child("Players").OnceAsync<dynamic>();

            var playerList = players.Select(p => new
            {
                Name = p.Key,
                playerId = p.Object.playerid,
                Gold = (int)p.Object.gold,
                score = (int)p.Object.score,

            }).ToList();

            Console.WriteLine("\n TopGold:");
            foreach (var player in playerList.OrderByDescending(p => p.Gold).Take(5))
            {
                Console.WriteLine($"- {player.Name}: gold {player.Gold} ");
            }

            Console.WriteLine("\n TopScore:");
            foreach (var player in playerList.OrderByDescending(p => p.score).Take(5))
            {
                Console.WriteLine($"- {player.Name}: score {player.score}");
            }
        }

        public static async Task UpdatePlayers()
        {
            var firebase = new FirebaseClient(firebaseUrl);
            var players = await firebase.Child("Players").OnceAsync<dynamic>();

            foreach (var player in players.Take(3))
            {
                string name = player.Key;
                string playerId = player.Object.playerid;
                int gold = (int)player.Object.gold;
                int score = (int)player.Object.score;
                
                score += 1000; 

                await firebase.Child("Players").Child(name).PatchAsync(new
                {
                    name = name,
                    playerID = player.Object.playerid,
                    gold = gold,
                    score = score,
                });
                Console.WriteLine($"Đã cập nhật: {name} (score mới = {score})");
            }

            Console.WriteLine("\n Cập nhật score hoàn tất cho  người chơi.");
        }
    }
}