using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace BrickBreaker
{
    internal class LevelLoader
    {
        int level;
        int layersCount;
        int layerPosition;
        int layerMaterial;
        int currentLayer;
        public Color color;

        public LevelLoader(int _level, int _layersCount, string _color) 
        {
            level = _level;
            layersCount = _layersCount;
            color = color;
            currentLayer = 1;
            int x = 10;

            GameScreen.blocks.Clear();

            XmlReader reader = XmlReader.Create("Resources/1.xml");

            //while (reader.Read())
            //{
            //   if (reader.NodeType == XmlNodeType.Text)
            //    {
            //        string name = reader.ReadString();
            //        for (int i = 10; i < 12; i++)
            //        {
                        
            //        }
                    
            //    }
            //}

            reader.Close();
        }
    }
}
