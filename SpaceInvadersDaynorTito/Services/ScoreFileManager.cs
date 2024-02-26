using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SpaceInvadersDaynorTito.Model;
using Windows.Storage;

namespace SpaceInvadersDaynorTito.Services
{
    public class ScoreFileManager
    {
        private string filePath;
        private string fileName = "scoresfile.txt";

        public ScoreFileManager()
        {
            this.filePath = "scoresfile.txt";
            CreateFileIfNotExists();
        }

        private void CreateFileIfNotExists()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public List<Score> LoadScores()
        {
            List<Score> scores = new List<Score>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int points))
                        {
                            scores.Add(new Score(parts[0], points));
                        }
                    }
                }
            }

            return scores;
        }

        public void AddScore(string playerName, int points)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{playerName},{points}");
            }
        }
    }
}
