using League.Models;

namespace League.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(LeagueContext context, bool readFromFile)
        {
            // Look for any students.
            if (context.Teams.Any())
            {
                
                Console.WriteLine("DB has been seeded");
                return;   // DB has been seeded
            }

            if (readFromFile)
            {
                await ReadTeamLinesAsync( context, "Teams.csv");
                return;
            }


            var players = new Player[]
            {
                new Player{FirstName="Alžběta",LastName="Chlumová",TeamID=1},
                new Player{FirstName="Lucie",LastName="Mičínová",TeamID=1},
                new Player{FirstName="Martina",LastName="Pitáková",TeamID=1},
                new Player{FirstName="Hana",LastName="Ptáčníková",TeamID=1},
                new Player{FirstName="Tereza",LastName="Schwarzová",TeamID=1},
                new Player{FirstName="Lucie",LastName="Šimková",TeamID=1},
                new Player{FirstName="Tereza",LastName="Tichá",TeamID=1},
                new Player{FirstName="Hana",LastName="Ducháčková",TeamID=2},
                new Player{FirstName="Kateřina",LastName="Šedá",TeamID=3},
                new Player{FirstName="Petra",LastName="Cabejšková",TeamID=4}
            };

            context.Players.AddRange(players);
            context.SaveChanges();

            

            
            var teams = new Team[]
            {
                new Team{Name="Sport Centrum Srbská"},
		        new Team{Name="Proklarě Dobrý Kuřata"},
		        new Team{Name="Dynamo Brno"},
                new Team{Name="Kobry Brno"},
                new Team{Name="Arsenal"},
                new Team{Name="Nemakej"}
                
            };

            context.Teams.AddRange(teams);
            context.SaveChanges();


            var stats = new Statistic[]
            {
                new Statistic {TeamID = 1},
                new Statistic {TeamID = 2},
                new Statistic {TeamID = 3},
                new Statistic {TeamID = 4},
                new Statistic {TeamID = 5},
                new Statistic {TeamID = 6}
            };
            context.Statistics.AddRange(stats);
            context.SaveChanges();

            var matches = new Match[]
            {
                new Match{Date=DateTime.Parse("01/04/2022 12:10:00"),HomeTeamID=1, HostTeamID=2, Round = 1},
                new Match{Date=DateTime.Parse("2022-05-02"),HomeTeamID=1, HostTeamID=3, Round = 2},
                new Match{Date=DateTime.Parse("08/18/2018 07:22:16"),HomeTeamID=2, HostTeamID=3, Round = 1},
                new Match{Date=DateTime.Parse("09/18/2019 07:22:16"),HomeTeamID=4, HostTeamID=3, Round = 1},
                new Match{Date=DateTime.Parse("09/18/2019 07:22:16"),HomeTeamID=4, HostTeamID=5, Round = 3},
                new Match{Date=DateTime.Parse("01/04/2022 12:10:00"),HomeTeamID=1, HostTeamID=2, Round = 1},
                new Match{Date=DateTime.Parse("2022-07-02"),HomeTeamID=1, HostTeamID=3, Round = 2},
                new Match{Date=DateTime.Parse("08/19/2018 07:45:16"),HomeTeamID=2, HostTeamID=3, Round = 1},
                new Match{Date=DateTime.Parse("09/22/2019 09:22:16"),HomeTeamID=4, HostTeamID=3, Round = 1},
                new Match{Date=DateTime.Parse("09/24/2019 17:22:16"),HomeTeamID=4, HostTeamID=5, Round = 3}
                
            };
            

            context.Matches.AddRange(matches);
            context.SaveChanges();
            
        }

        static async Task ReadTeamLinesAsync(LeagueContext context, String filename)
        {
            String line;
            List<Team> teams = new List<Team>();
            var path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), filename);
            if(File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    while((line = (await reader.ReadLineAsync())) != null)
                    {
                        Console.WriteLine("Opened file.");
                        Console.WriteLine("First line contains: " + line);
                        teams.Add(new Team{Name=line});
                    }

                    
                }
            context.Teams.AddRange(teams);
            await context.SaveChangesAsync();

            List<Statistic> statistics = new List<Statistic>();
            foreach(var t in context.Teams)
            {
                statistics.Add(new Statistic {TeamID = t.ID});
            }
            context.Statistics.AddRange(statistics);
            await context.SaveChangesAsync();

            } else
            {
                Console.WriteLine($"File does not exist. {path}");
            }
            
        }


    }
}