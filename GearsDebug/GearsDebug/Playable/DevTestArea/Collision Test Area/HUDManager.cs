using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Cloud;
using Gears.Cloud.Utility.Drawing;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class HUDManager : IManager
    {
        // Line w/o primitive adapted from http://www.xnawiki.com/index.php/Drawing_2D_lines_without_using_primitives
        private List<LineSegment> lines = new List<LineSegment>();
        private DrawingHelper drawingHelper;
        private bool drawLines = true;
        private Texture2D blank = null;

        private int gridBoxesHorizontal = 10;
        private int gridBoxesVertical = 10;

        public HUDManager() { InitializeLocal(); }

        private void InitializeLocal()
        {
            blank = new Texture2D(Master.GetGame().GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });

            drawingHelper = new DrawingHelper();

            this.ClearLines();
            this.CreateGrid();
        }

        public void Activate()
        {

        }

        private void CreateGrid()
        {
            int screenWidth = ViewportHandler.GetWidth();
            int screenHeight = ViewportHandler.GetHeight();
            
            int boxWidth = screenWidth / gridBoxesHorizontal;
            int boxHeight = screenHeight / gridBoxesVertical;

            for (int x = 0; x <= screenWidth; x += boxWidth)
            {
                lines.Add(drawingHelper.CreateLine(1, Color.White, new Vector2(x, 0), new Vector2(x, screenHeight)));
            }
            for (int y = 0; y <= screenHeight; y += boxHeight)
            {
                lines.Add(drawingHelper.CreateLine(1, Color.White, new Vector2(0, y), new Vector2(screenWidth, y)));
            }
        }

        private void DrawLines(SpriteBatch spriteBatch)
        {
            foreach (LineSegment line in this.lines)
            {
                drawingHelper.DefaultDrawLine(ref spriteBatch, line, ref blank);
            }
        }
        
        private void ClearLines()
        {
            lines.Clear();
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (drawLines)
            {
                this.DrawLines(spriteBatch);
            }
        }
    }
}
