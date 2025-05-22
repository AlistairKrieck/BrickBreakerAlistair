using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BrickBreaker
{
    public class PlayerData
    {
        string username, password;
        int score { get; set; }

        public PlayerData(string _username, string _password, int _score)
        {
            username = _username;
            password = _password;
            score = _score;
        }

        public PlayerData(string _username, string _password)
        {
            username = _username;
            password = _password;
        }

        public void SavePlayerData()
        {
            XDocument doc = XDocument.Load("Resources/playerData.xml");
            XElement players = doc.Element("Players");

            players.Add(new XElement("Player",
                new XElement("Username", $"{username}"),
                new XElement("Password", $"{password}"),
                new XElement("Score", $"{score}")));

            doc.Save($"Resources/playerData.xml");
        }

        public static List<PlayerData> LoadPlayerData()
        {
            List<PlayerData> players = new List<PlayerData>();

            XmlReader reader = XmlReader.Create("Resources/playerData.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    reader.ReadToFollowing("Username");
                    string un = reader.ReadString();

                    reader.ReadToFollowing("Password");
                    string pw = reader.ReadString();

                    reader.ReadToFollowing("Score");
                    int sc = Convert.ToInt16(reader.ReadString());

                    players.Add(new PlayerData(un, pw, sc));
                }
            }

            reader.Close();

            return players;
        }

        public void UpdatePlayerScore()
        {
            XDocument doc = XDocument.Load($"Resources/playerData.xml");
            XElement currentPlayer = doc.Element("Players").Elements("Player")
                                .Where(player => player.Attribute("username").Value == username)
                                .FirstOrDefault();

            currentPlayer.Attribute("score").SetValue($"score");
        }
    }
}
