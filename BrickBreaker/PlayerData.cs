using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BrickBreaker
{
    public class PlayerData
    {
        public string username, password;
        public int score { get; set; }

        // Create new string to hold path for the playerData Xml file
        string pdXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/playerData.xml");

        public PlayerData(string _username, string _password)
        {
            username = _username;
            password = _password;
        }


        // Blank constructor to temporarily hold empty player objects
        public PlayerData() { }


        // Save this player object to an XML file
        public void SavePlayerData()
        {
            // Load existing playerData XML file
            XDocument doc = XDocument.Load(pdXml);

            // Select the start element
            XElement players = doc.Element("Players");

            // Add a new subelement and its attributes
            players.Add(new XElement("Player",
                new XElement("Username", $"{username}"),
                new XElement("Password", $"{password}"),
                new XElement("Score", $"{score}")));

            // Save the updated file
            doc.Save(pdXml);
        }


        // Update score of this player object
        // Updated on win or level cleared
        public void UpdatePlayerScore()
        {
            // Open the playerData XML
            XDocument doc = XDocument.Load(pdXml);

            // Find the player that is currently signed in
            XElement currentPlayer = doc.Element("Players").Elements("Player")
                                .Where(player => player.Element("Username").Value == username)
                                .FirstOrDefault();

            // Update the score saved in the file
            currentPlayer.Element("Score").SetValue($"{score}");

            // Save the updated file
            doc.Save(pdXml);
        }

        // Returns a list of all player objects stored in the playerData XML
        public List<PlayerData> LoadAllPlayerData()
        {
            // Create a list of player objects
            List<PlayerData> players = new List<PlayerData>();

            // Create a new reader object
            XmlReader reader = XmlReader.Create(pdXml);


            // Read to the start element
            //reader.ReadStartElement();

            // Read from each player in the file
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Create a new player object to store the read information
                    PlayerData player = new PlayerData();

                    // Store subelements into new objects of their respective types
                    reader.ReadToFollowing("Username");
                    player.username = reader.ReadString();

                    reader.ReadToFollowing("Password");
                    player.password = reader.ReadString();

                    reader.ReadToFollowing("Score");
                    player.score = Convert.ToInt16(reader.ReadString());

                    // Add read player to the list of players
                    players.Add(player);
                }
            }

            // Close the reader object
            reader.Close();

            // Return the list of all players in the file
            return players;
        }
    }
}
