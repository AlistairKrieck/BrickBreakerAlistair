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

        public PlayerData(string _username, string _password)
        {
            username = _username;
            password = _password;

            CreateEmptyFile();
        }


        // Blank constructor to temporarily hold empty player objects
        public PlayerData() { }


        // Save this player object to an XML file
        public void SavePlayerData()
        {
            // Load existing playerData XML file
            XDocument doc = XDocument.Load("Resources/playerData.xml");

            // Select the start element
            XElement players = doc.Element("Players");

            // Add a new subelement and its attributes
            players.Add(new XElement("Player",
                new XElement("Username", $"{username}"),
                new XElement("Password", $"{password}"),
                new XElement("Score", $"{score}")));

            // Save the updated file
            doc.Save($"Resources/playerData.xml");
        }


        // Update score of this player object
        public void UpdatePlayerScore()
        {
            // Open the playerData XML
            XDocument doc = XDocument.Load($"Resources/playerData.xml");

            // Find the player that is currently signed in
            XElement currentPlayer = doc.Element("Players").Elements("Player")
                                .Where(player => player.Attribute("username").Value == username)
                                .FirstOrDefault();

            // Update the score saved in the file
            currentPlayer.Attribute("score").SetValue($"{score}");

            // Save the updated file
            doc.Save($"Resources/playerData.xml");
        }

        #region Public static methods
        // Returns a list of all player objects stored in the playerData XML
        public static List<PlayerData> LoadPlayerData()
        {
            // Create a list of player objects
            List<PlayerData> players = new List<PlayerData>();

            // Create a new reader object
            XmlReader reader = XmlReader.Create("Resources/playerData.xml");

            // Read from each player in the file
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Store subelements into new objects of their respective types
                    reader.ReadToFollowing("Username");
                    string un = reader.ReadString();

                    reader.ReadToFollowing("Password");
                    string pw = reader.ReadString();

                    reader.ReadToFollowing("Score");
                    int sc = Convert.ToInt16(reader.ReadString());

                    // Add read player to the list of players
                    players.Add(new PlayerData(un, pw));
                }
            }

            // Close the reader object
            reader.Close();

            // Return the list of all players in the file
            return players;
        }


        // Creates a new empty playerData XML file if none exist
        public static void CreateEmptyFile()
        {
            if (!File.Exists("Resources/playerData.xml"))
            {
                // Open the XML file and place it in writer 
                XmlWriter writer = XmlWriter.Create($"Resources/playerData.xml");

                // Write the root element 
                writer.WriteStartElement("Players");


                // End the root element 
                writer.WriteEndElement();


                // Write the XML to file and close the writer 
                writer.Close();
            }
        }

        #endregion
    }
}
