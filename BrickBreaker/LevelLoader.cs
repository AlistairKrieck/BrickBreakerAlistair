using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BrickBreaker
{
    public class LevelLoader
    {
        List<Bricks> bricks;

        public LevelLoader()
        {
            bricks = new List<Bricks>();
        }

        public void SaveLevel(string levelNum, List<Bricks> _bricks)
        {
            //Open the XML file and place it in writer 
            XmlWriter writer = XmlWriter.Create($"Resources/{levelNum}.xml");

            //Write the root element 
            writer.WriteStartElement("Level");

            foreach (Bricks b in _bricks)
            {
                //Start an element 
                writer.WriteStartElement("Block");


                //Write sub-elements 
                writer.WriteElementString("x", $"{b.x}");

                writer.WriteElementString("y", $"{b.y}");

                writer.WriteElementString("type", $"{b.brickType}");


                // end the element 
                writer.WriteEndElement();
            }


            // end the root element 
            writer.WriteEndElement();


            //Write the XML to file and close the writer 
            writer.Close();
        }


        public List<Bricks> LoadLevel(int levelNum)
        {
            bricks.Clear();

            // Open the XML file and place it in reader 
            XmlReader reader = XmlReader.Create($"Resources/level{levelNum}.xml");

            // Read to the start element
            reader.ReadStartElement();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Get the x value for each brick and store it in an int
                    reader.ReadToFollowing("x");
                    int x = Convert.ToInt16(reader.ReadString());

                    // Get the y value for each brick and store it in an int
                    reader.ReadToFollowing("y");
                    int y = Convert.ToInt16(reader.ReadString());

                    // Get the block type and convert it to a BrickType
                    reader.ReadToFollowing("type");
                    string brickType = reader.ReadString();

                    //Create new brick object with read data
                    Bricks b = new Bricks(x, y, brickType, GameScreen.brickImages[brickType]);

                    switch (brickType)
                    {
                        case "skeleton":
                            b = new Skeleton(x, y);
                            break;

                        case "zombie":
                            b = new Zombie(x, y);
                            break;
                    }

                    b.rect = new Rectangle(x, y, Bricks.width, Bricks.height);

                    // Add new brick to list of blocks
                    bricks.Add(b);
                }
            }

            // Write the XML to file and close the writer 
            reader.Close();

            return bricks;
        }
    }
}
