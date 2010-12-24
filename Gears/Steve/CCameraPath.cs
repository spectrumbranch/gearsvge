using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GearsDebug
{
    class CCameraPath
    {
        public CCameraPath()
        {
            path = new List<Vector3>();
            currentPoint = new Vector3();
        }
        private List<Vector3> path;
        public void addPoint(Vector3 point)
        {
            path.Add(point);
            if (_hasValues == false)
            {
                currentPoint = path[0];
                _hasValues = true;
            }
        }

        public void removePoint(Vector3 point)
        {
            if (point == currentPoint)
            {
                currentPoint.X = 0;
                currentPoint.Y = 0;
                currentPoint.Z = 0;
            }

            this.path.Remove(point);
            if (path.Count() == 0)
                _hasValues = false;
            
        }

        public Vector3 goToNext()
        {
            int index = path.IndexOf(currentPoint) + 1;
            currentPoint = path[index];
            return currentPoint;
        }

        public Vector3 goToPrevious()
        {
            int index = path.IndexOf(currentPoint) - 1;
            currentPoint = path[index];
            return currentPoint;
        }

        public Vector3 currentPoint;
        private bool _hasValues = false;
        
    }
}
