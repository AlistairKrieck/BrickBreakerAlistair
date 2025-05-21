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
        List<Block> blocks;

        public Level()
        {
            blocks = new List<Block>();
        }

        public void SaveLevel(string levelNum, List<Block> _blocks)
        {
            //Open the XML file and place it in writer 
            XmlWriter writer = XmlWriter.Create($"Resources/{levelNum}.xml");


            //Write the root element 
            writer.WriteStartElement("Level");


            foreach (Block b in _blocks)
            {
                //Start an element 
                writer.WriteStartElement("Block");


                //Write sub-elements 
                writer.WriteElementString("x", $"{b.x}");

                writer.WriteElementString("y", $"{b.y}");

                writer.WriteElementString("width", $"{Block.width}");

                writer.WriteElementString("height", $"{Block.height}");

                writer.WriteElementString("type", $"{b.blockType}");


                // end the element 
                writer.WriteEndElement();
            }


            // end the root element 
            writer.WriteEndElement();


            //Write the XML to file and close the writer 
            writer.Close();
        }


        public List<Block> LoadLevel(string levelNum)
        {
            blocks.Clear();

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
                    Block b = new Block();

                    reader.ReadToFollowing("x");
                    x = reader.ReadString();

                    reader.ReadToFollowing("y");
                    y = reader.ReadString();

                    reader.ReadToFollowing("type");
                    b.blockType = reader.ReadString();

                    b.x = Convert.ToInt16(x);
                    b.y = Convert.ToInt16(y);

                    b.Rect = new Rectangle(b.x, b.y, Block.width, Block.height);

                    //add day to list of blocks
                    blocks.Add(b);
                }
            }

            //Write the XML to file and close the writer 
            reader.Close();

            return blocks;
        }
    }
}
