using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GearsDebug
{
    enum cameraState
    {
        USERCONTROLLED = 0,
        LOCKED,
        FOLLOWINGPATH,
        FOLLOWINGUNIT,
        AUTONOMOUS
    }
    class CCamera
    {
        private static CCamera instance;
        private CCamera() 
        {
            _transformation = new float[3][];
            for (int i = 0; i < 3; i++)
            {
                _transformation[i] = new float[3];

                _transformation[i][0] = 0;
                _transformation[i][1] = 0;
                _transformation[i][2] = 0;
            }
            _state = cameraState.LOCKED;
        }

        public static CCamera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CCamera();
                }
                return instance;
            }
        }

        private float[][] _transformation;
        private Vector2 _boundaryX;
        private Vector2 _boundaryY;
        private Vector2 _boundaryZ;
        private List<CCameraPath> _cameraPath;
        private CCameraPath _currentPath;
        private Unit _following;
        private cameraState _state;
        private bool _pathJump = false;

        public void update()
        {
            //getting to it..
            switch (_state)
            {
                case cameraState.FOLLOWINGPATH:
                    break;

                case cameraState.FOLLOWINGUNIT:
                    if (_following != null)
                    {

                    }
                    else
                        _state = cameraState.LOCKED;

                    break;

                case cameraState.LOCKED:
                    break;

                case cameraState.USERCONTROLLED:
                    break;

                default:
                    break;
            }
        }

        public void lockCam(Vector3 position)
        {
            _transformation[0][0] = position.X;
            _transformation[0][1] = position.Y;
            _transformation[0][2] = position.Z;
            _state = cameraState.LOCKED;
        }

        public void followPath(CCameraPath path, bool jump)
        {
            _currentPath = path;
            _pathJump = jump;
            _state = cameraState.FOLLOWINGPATH;
        }

        public void setFollowingUnit(Unit follow)
        {
            _following = follow;
            _state = cameraState.FOLLOWINGUNIT;
        }

        public void quickTranform(float[][] transformation)
        {
            _transformation = transformation;
        }

        public void quickTransform(Vector3 translation, Vector3 rotation, Vector3 scale)
        {
            _transformation[0][0] = translation.X;
            _transformation[0][1] = translation.Y;
            _transformation[0][2] = translation.Z;

            _transformation[1][0] = rotation.X;
            _transformation[1][1] = rotation.Y;
            _transformation[1][2] = rotation.Z;

            _transformation[2][0] = scale.X;
            _transformation[2][1] = scale.Y;
            _transformation[2][2] = scale.Z;
        }

        public cameraState state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = state;
            }
        }
    }
}
