using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Gears.Cloud
{
    internal static class ContentButler
    {
        internal static void setGame(Game theGame)
        {
            _game = theGame;
            _textures = new Dictionary<int, List<Texture2D>>();
            _sounds = new Dictionary<int, List<SoundEffect>>();
            _music = new Dictionary<int, List<Song>>();
            _fonts = new Dictionary<int, SpriteFont>();
            _init = true;
        }

        private static Dictionary<int, List<Texture2D>> _textures;
        private static Dictionary<int, List<SoundEffect>> _sounds;
        private static Dictionary<int, List<Song>> _music;
        private static Dictionary<int, SpriteFont> _fonts;
        private static bool _songStart = false;
        private static Game _game;
        private static bool _init = false;

        //for returning nulls
        private static Texture2D _texNull;
        private static SoundEffect _sfxNull;
        private static Song _musNull;
        private static SpriteFont _fontNull;

        internal static bool checkInit()
        {
            if (!_init)
                throw new System.ArgumentException("Content Manager was not initialized before being called!");

            return _init;
        }

        internal static void unload()
        {
            if (checkInit())
            {
                for (int i = 0; i < _textures.Keys.Count(); i++)
                {
                    _textures[i].Clear();
                }
                _textures.Clear();

                for (int i = 0; i < _sounds.Keys.Count(); i++)
                {
                    _sounds[i].Clear();
                }
                _sounds.Clear();

                for (int i = 0; i < _music.Keys.Count(); i++)
                {
                    _music[i].Clear();
                }
                _music.Clear();
            }
        }

        internal static void loadFont(string fontName)
        {
            if (checkInit())
            {
                SpriteFont temp = _game.Content.Load<SpriteFont>(fontName);

                if (!_fonts.Values.Contains(temp))
                {
                    _fonts.Add(_fonts.Count(), temp);
                }
            }
            else
                throw new System.Exception("Content Manager not initialized!");
        }

        internal static SpriteFont requestFont(int fontID)
        {
            if (checkInit())
                return _fonts[fontID];

            return _fontNull;
        }

        internal static void loadTexture(int unitID, string texDir)
        {
            if (checkInit())
            {
                Texture2D temp = _game.Content.Load<Texture2D>(texDir);

                if (!_textures.Keys.Contains(unitID))
                {
                    _textures.Add(unitID, new List<Texture2D>());
                }
                _textures[unitID].Add(temp);
            }
        }

        internal static void loadTexture(int unitID, int resourceID, string texDir)
        {
            if (checkInit())
            {
                if (!_textures.Keys.Contains(unitID) || _textures[unitID].Count() <= resourceID)
                {
                    throw new System.ArgumentException("Texture dictionary does not contain the specified ID!");
                }
                else
                {
                    Texture2D temp = _game.Content.Load<Texture2D>(texDir);
                    _textures[unitID][resourceID] = temp;
                }
            }
        }

        internal static void loadSfx(int unitID, string sfxDir)
        {
            if (checkInit())
            {
                SoundEffect temp = _game.Content.Load<SoundEffect>(sfxDir);

                if (!_sounds.Keys.Contains(unitID))
                {
                    _sounds.Add(unitID, new List<SoundEffect>());
                }
                _sounds[unitID].Add(temp);
            }
        }

        internal static void loadSfx(int unitID, int resourceID, string sfxDir)
        {
            if (checkInit())
            {
                if (!_sounds.Keys.Contains(unitID) || _sounds[unitID].Count() <= resourceID)
                {
                    throw new System.ArgumentException("Sound Effect dictionary does not contain the specified ID!");
                }
                else
                {
                    SoundEffect temp = _game.Content.Load<SoundEffect>(sfxDir);
                    _sounds[unitID][resourceID] = temp;
                }
            }
        }

        internal static void loadMusic(int unitID, string musDir)
        {
            if (checkInit())
            {
                Song temp = _game.Content.Load<Song>(musDir);

                if (!_music.Keys.Contains(unitID))
                {
                    _music.Add(unitID, new List<Song>());
                }
                _music[unitID].Add(temp);
            }
        }

        internal static void loadMusic(int unitID, int resourceID, string musDir)
        {
            if (checkInit())
            {
                if (!_music.Keys.Contains(unitID) || _sounds[unitID].Count() <= resourceID)
                {
                    throw new System.ArgumentException("Music dictionary does not contain the specified ID!");
                }
                else
                {
                    Song temp = _game.Content.Load<Song>(musDir);
                    _music[unitID][resourceID] = temp;
                }
            }
        }

        internal static Texture2D requestTexture(int unitID, int bankID)
        {
            if (checkInit())
                return _textures[unitID][bankID];

            return _texNull;
        }

        internal static SoundEffect requestSfx(int unitID, int bankID)
        {
            if (checkInit())
                return _sounds[unitID][bankID];

            return _sfxNull;
        }

        internal static Song requestMusic(int unitID, int bankID)
        {
            if (checkInit())
                return _music[unitID][bankID];

            return _musNull;
        }
        internal static Game GetGame()
        {
            return _game;
        }
    }
}
