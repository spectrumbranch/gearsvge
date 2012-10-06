using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Gears.Cloud._Debug;
using Gears.Cloud.Events;
using Gears.Cloud.Input;

namespace Gears.Cloud
{
    public static class Master
    {
        private static Color clearColor = new Color(105, 105, 105, 255);
        //private static Color nullColor = new Color(148, 0, 211, 255); // DarkViolet
        //0,0,255,255 Blue

        private static Stack<GameState> stack = new Stack<GameState>();
        private static LinkedList<GameState> list = new LinkedList<GameState>();


        private static InputManager inputManager = new InputManager();



        public static InputManager GetInputManager()
        {
            return inputManager;
        }



        //?
        public static void Initialize()
        {
            
        }


        //temp top to list 
        public static void Push(GameState gameState)
        {
            stack.Push(gameState);
        }
        public static GameState Peek()
        {
            return stack.Peek();
        }
        public static GameState Pop()
        {
            return stack.Pop();
        }
        /// <summary>
        /// Master Draw call.
        /// This should be the first and only interface from the main game
        ///     "Draw" loop for this instance of the VGE.
        /// </summary>
        /// <param name="spriteBatch">The global-parameter sprite batch.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            //no matter what, if draw is called, we are drawing the top stack item.
            stack.Peek().Draw(spriteBatch);

            //it's an overlay. we are able to draw more than one layer if there's anything below
            if (stack.Peek().IsOverlay)
            {
                if (list.Count != 0)
                {
                    //**Note that this code does not take into account culling.
                    list.First().Draw(spriteBatch);
                }
            }
            else //it's not an overlay. 
                 //since we are already drawing the top stack item, we dont need to do anything else.
            { }  //this is just here in case it is useful in the future.
        }
        /// <summary>
        /// Master Update call. 
        /// This should be the first and only interface from the main game 
        ///     "Update" loop for this instance of the VGE.
        /// </summary>
        /// <param name="gameTime">The time snapshot.</param>
        public static void Update(GameTime gameTime)
        {
            //global events
            CGlobalEvents.GFrameTrigger.Update();

            //Input
            //new
            GetInputManager().Update(gameTime);
            //old
            //DefaultInput_old.Update(gameTime);


            //only updating the top item, whether it is an overlay or just a regular state
            //there are no known cases where two items need to be updated at the same time
            stack.Peek().Update(gameTime);

            //NOTE: Only do this for the frame event!!!
            CGlobalEvents.GFrameTrigger.getEvent(0).triggered = false;
            
        }
        private static void PopToList()
        {
            if (stack.Count != 0)
            {
                Debug.Out("Master::StoreTop(): Stack is not empty. Popping stack to list.");
                list.AddFirst(stack.Pop());
            }
            else
            {
                Debug.Out("Master::StoreTop(): ERROR Stack is empty. Cannot pop stack.");
            }

        }
        private static void PushReturnToStack()
        {
            if (list.Count != 0)
            {
                Debug.Out("Master::ReturnToStack(): List is not empty. Pushing first item of list to stack.");
                stack.Push(list.First());
                list.RemoveFirst();
            }
            else
            {
                Debug.Out("Master::ReturnToStack(): ERROR List is empty. Unable to push any object to stack.");
            }
        }
        private static void CleanList()
        {
            list.Clear();
        }
        public static int GetListLength()
        {
            return list.Count;
        }
        public static int GetStackLength()
        {
            return stack.Count;
        }
        public static Color GetClearColor()
        {
            return clearColor;
        }
    }
}
