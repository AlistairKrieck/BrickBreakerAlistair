using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BrickBreaker
{
    public class Level
    {
        List<Bricks> bricks;

        public Level()
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

                writer.WriteElementString("width", $"{Block.width}");

                writer.WriteElementString("height", $"{Block.height}");

                writer.WriteElementString("type", $"{b.BrickType}");


                // end the element 
                writer.WriteEndElement();
            }


            // end the root element 
            writer.WriteEndElement();


            //Write the XML to file and close the writer 
            writer.Close();
        }


        public List<Bricks> LoadLevel(string levelNum)
        {
            bricks.Clear();

            //Open the XML file and place it in writer 
            XmlReader reader = XmlReader.Create($"Resources/{levelNum}.xml");


            //Write the root element 
            reader.ReadStartElement("Level");

            string x, y, type;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    //create a block
                    Bricks b = new Bricks();

                    reader.ReadToFollowing("x");
                    x = reader.ReadString();

                    reader.ReadToFollowing("y");
                    y = reader.ReadString();

                    reader.ReadToFollowing("type");
                    type = reader.ReadString();

                    b.BrickType = Form1.ConvertStringToBlockType(type);

                    b.x = Convert.ToInt16(x);
                    b.y = Convert.ToInt16(y);

                    b.Rect = new Rectangle(b.x, b.y, Block.width, Block.height);

                    b.Image = GameScreen.brickImages[b.BrickType];

                    //add day to list of blocks
                    bricks.Add(b);
                }
            }

            //Write the XML to file and close the writer 
            reader.Close();

            return bricks;
        }
    }
}
