using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Cloud;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class HUDManager : IManager
    {
        // Line w/o primitive adapted from http://www.xnawiki.com/index.php/Drawing_2D_lines_without_using_primitives
        private List<LineSegment> lines = new List<LineSegment>();
        private bool drawLines = true;
        private Texture2D blank = null;

        public HUDManager() { InitializeLocal(); }

        private void InitializeLocal()
        {
            blank = new Texture2D(Master.GetGame().GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });

            this.AddLine(1, Color.White, new Vector2(100, 100), new Vector2(300, 300));
            this.AddLine(1, Color.White, new Vector2(200, 200), new Vector2(500, 200));
        }

        public void Activate()
        {
            
        }

        private void DrawLine(SpriteBatch spriteBatch, float width, Color color, Vector2 point1, Vector2 point2)
        {
            //float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            //float length = Vector2.Distance(point1, point2);
            //spriteBatch.Draw(blank, point1, null, color, angle, Vector2.Zero, new Vector2(length, width), SpriteEffects.None, 0);
        }
        private void DrawLines(SpriteBatch spriteBatch)
        {
            foreach (LineSegment line in this.lines)
            {
                spriteBatch.Draw(blank, line.GetOrigin(), null, line.GetColor(), line.GetAngle(), Vector2.Zero, line.GetScale(), SpriteEffects.None, 0);
            }
        }
        private void AddLine(float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            LineSegment line = new LineSegment();
            line.SetAngle(angle);
            line.SetColor(color);
            line.SetOrigin(point1);
            line.SetScale(new Vector2(length, width));

            lines.Add(line);
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

    struct LineSegment
    {
        private float angle;// = 0.0f;
        private Vector2 origin;// = new Vector2();
        private Color color;// = new Color();
        private Vector2 scale;// = new Vector2();

        public float GetAngle()
        {
            return this.angle;
        }
        public void SetAngle(float angle)
        {
            this.angle = angle;
        }
        public Vector2 GetOrigin()
        {
            return this.origin;
        }
        public void SetOrigin(Vector2 origin)
        {
            this.origin = origin;
        }
        public Color GetColor()
        {
            return this.color;
        }
        public void SetColor(Color color)
        {
            this.color = color;
        }
        public Vector2 GetScale()
        {
            return this.scale;
        }
        public void SetScale(Vector2 scale)
        {
            this.scale = scale;
        }
    }
}
