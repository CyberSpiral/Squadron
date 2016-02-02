﻿using System;
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

namespace Squadron5missing
{
    
    class EngineEvent : Event
    {
        //constructor(s)
        public EngineEvent(double timespan, string eventName, DateTime currentTime, string startText)
            : base(timespan, eventName, currentTime, startText)
        {
            
        }
        //methods
        public override void DrawText(SpriteBatch spriteBatch, SpriteFont sFont, Vector2 position)
        {
            base.DrawText(spriteBatch, sFont, position);
        }

        public override void Draw(SpriteBatch spriteB, SpriteFont Font)
        {
            base.Draw(spriteB, Font);
        }

        public override void Update()
        {
            base.Update();
        }

        public void MoveTooRoom()
        {
            //for-loops too move to the elevators X and Y cordiantes
            //then move too the correct room
        }
    }
}
