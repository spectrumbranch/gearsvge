using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using Gears.Cloud.Utility;
using Gears.Cartography;

namespace GearsDebug
{
    /// <summary>
    /// A class to test the generic Gears.Cloud.Utility.XMLEngine class.
    /// </summary>
    public class XMLEngineExample : MenuUserControl
    {
        public XMLEngineExample() : base("XMLEngineTest") { }
        public override void ThrowPushEvent()
        {
            //Test the class with an already known type -- string
            XMLEngine<string>.SaveToFile("testXMLEngineExample.xml", "example string data");
            //load it and output to log to test that too.
            Gears.Cloud._Debug.Debug.Out(XMLEngine<string>.LoadFromFile("testXMLEngineExample.xml"));

            //Test a custom-made type -- our example Map!
            Map map = new Map();
            PopulateExampleMap(ref map);
            XMLEngine<Map>.SaveToFile("testXMLEngineMapExample.xml", map);
        }

        private static void PopulateExampleMap(ref Gears.Cartography.Map map)
        {
            map.VERSION = "0.1.5";

            map.BGM_FILE_LOC = "BGM_FILE_LOC DIRECTORY test";
            map.FADE_IN_FILE_LOC = "FADE_IN_FILE_LOC DIRECTORY test";
            map.FADE_OUT_FILE_LOC = "FADE_OUT_FILE_LOC DIRECTORY test";
            map.BG_IMAGE_FILE_LOC = "BG_IMAGE_FILE_LOC DIRECTORY test";

            map.NUM_LAYERS = 5;
            map.LAYER_WIDTH_TILES = 80;
            map.LAYER_HEIGHT_TILES = 35;
            map.TILE_DATA = "453tgfd,346tw,4e5trfr5,34tegdr,45tr";
        }
    }
}
