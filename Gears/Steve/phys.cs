using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GearsDebug
{
    class phys
    {

        readonly Vector2 grav = new Vector2(0, -9.81f); //assuming we're using Earth's gravity

        //newton's second law
        public Vector2 calcAccel(float mass, Vector2 force)
        {
            return new Vector2(force.X / mass, force.Y / mass);
        }

        public Vector2 calcForce(float mass, Vector2 accel)
        {
            return new Vector2(mass * accel.X, mass * accel.Y);
        }

        //various mechanics
        

        //ohm's law for the electrical knife
        public float calcVoltage(float current, float resistance)
        {
            return (current * resistance);
        }

        public float calcCurrent(float voltage, float resistance)
        {
            return (voltage / resistance);
        }

        public float calcResistance(float voltage, float current)
        {
            return (voltage / current);
        }

        //other electrical things which we may need
        public float calcPower(float voltage, float resistance)
        {
            return ((voltage * voltage) / resistance);
        }
    }
}
