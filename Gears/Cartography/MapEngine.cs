using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Gears.Cloud._Debug;

namespace Gears.Cartography
{
    //TODO: This needs to be refactored and parameterized.
    sealed class MapEngine
    {
        private Map map0; //for testing purposes

        private const string _KEY = @""; //some key

        public static string SAVE_LOCATION = @"save4.xml"; //assignment is for testing only!!! replace with constructor param or something like that
        //public static string SAVE_LOCATION = @"DEBUG_SPACE\save0.xml"; //assignment is for testing only!!! replace with constructor param or something like that
        public static string LOAD_LOCATION = @"load0.xml"; //assignment is for testing only!!! replace with constructor param or something like that
        public MapEngine()
        {

        }
        internal void DebugSerialize()
        {
            map0 = new Map();
            PopulateFields();
            SerializeToXML(map0);
        }
        internal void DebugDeserialize()
        {
            //NOT YET FULLY IMPLEMENTED
            map0 = new Map();
            //PopulateFields();
            DeserializeFromXML();
        }

        private void PopulateFields()
        {
            //debug values
            map0.VERSION = "0.0.2";

            map0.BGM_FILE_LOC = "BGM_FILE_LOC DIRECTORY test";
            map0.FADE_IN_FILE_LOC = "FADE_IN_FILE_LOC DIRECTORY test";
            map0.FADE_OUT_FILE_LOC = "FADE_OUT_FILE_LOC DIRECTORY test";
            map0.BG_IMAGE_FILE_LOC = "BG_IMAGE_FILE_LOC DIRECTORY test";

            map0.NUM_LAYERS = 5;
            map0.LAYER_WIDTH_TILES = 80;
            map0.LAYER_HEIGHT_TILES = 35;
            map0.TILE_DATA = "439f8h,f309f,43f3fj34f,-34f349";

        }
        
             
        
        public static void SerializeToXML(Map map)
        {
            using (TextWriter textWriter = new StreamWriter(SAVE_LOCATION))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Map));
                //TextWriter textWriter = new StreamWriter(@"C:\movie.xml"); //change save location
                serializer.Serialize(textWriter, map);
                textWriter.Close();
            }
        }
        public static Map DeserializeFromXML()
        {
            //throw new NotImplementedException(); // . . .
            //STILL BROKEN GOTTA FIX IT!

            using (TextReader textReader = new StreamReader(LOAD_LOCATION))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Map));
                //TextReader textReader = new StreamReader(@"C:\movie.xml"); //change load location
                Map map;
                try
                {
                    map = (Map)deserializer.Deserialize(textReader);
                    
                    Debug.Out("@MAP/VERSION=" + map.VERSION);
                    Debug.Out("@MAP/BGMFILE=" + map.BGM_FILE_LOC);
                    Debug.Out("@MAP/FADEINFILE=" + map.FADE_IN_FILE_LOC);
                    Debug.Out("@MAP/FADEOUTFILE=" + map.FADE_OUT_FILE_LOC);
                    Debug.Out("@MAP/BGIFILE=" + map.BG_IMAGE_FILE_LOC);
                    Debug.Out("@MAP/LAYERS=" + map.NUM_LAYERS);
                    Debug.Out("@MAP/LAYERWIDTH=" + map.LAYER_WIDTH_TILES);
                    Debug.Out("@MAP/LAYERHEIGHT=" + map.LAYER_HEIGHT_TILES);
                    Debug.Out("@MAP/DATA=" + map.TILE_DATA);
                    return map;
                }
                catch (InvalidOperationException ioe)
                {
                    Debug.Out("##MapEngine.DeserializeFromXML(): An error has occurred. The XML file read from " + LOAD_LOCATION + " is of an incompatible format.");
                    Debug.Out(ioe.Message);
                }

                
                textReader.Close();
                return null;
            }

        }
    }
    public class Map
    {
        //ASSIGNMENTS ARE FOR TESTING PURPOSES ONLY!!!

        [XmlAttribute("vers")]
        public string VERSION {get; set;}

        [XmlElement("bgmfile")]
        public string BGM_FILE_LOC {get; set;}
        [XmlElement("fadeinfile")]
        public string FADE_IN_FILE_LOC {get; set;}
        [XmlElement("fadeoutfile")]
        public string FADE_OUT_FILE_LOC {get; set;}
        [XmlElement("bgifile")]
        public string BG_IMAGE_FILE_LOC {get; set;}

        [XmlElement("layers")]
        public byte NUM_LAYERS {get; set;}
        [XmlElement("layerwidth")]
        public int LAYER_WIDTH_TILES {get; set;}
        [XmlElement("layerheight")]
        public int LAYER_HEIGHT_TILES {get; set;}

        [XmlElement("data")]
        public string TILE_DATA {get; set;}


    }
    class MapLoader : Map
    {
        //strings instead of values. throw exception if not cool
    }

    public class InvalidMapFileFormatException : System.IO.FileLoadException
    {
        public InvalidMapFileFormatException() { }
        public InvalidMapFileFormatException(string message) { }
        public InvalidMapFileFormatException(string message, System.Exception inner) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client.
        protected InvalidMapFileFormatException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
