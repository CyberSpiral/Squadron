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
    class RadarEvent : Event
    {
        public RadarEvent(double timespan, string eventName, DateTime currentTime, string startText, Mechanic chara)
            : base(timespan, eventName, currentTime, startText, chara)
        {
            
        }


        public override void Draw(SpriteBatch spriteB, SpriteFont Font)
        {
            base.Draw(spriteB, Font);
        }

        public override void Update()
        {
            base.Update();
        }

        public void MoveTooPosition()
        {
            
        }
    }
}
