﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Squadron5missing
{
    class Event
    {
        //properties
        public DateTime ETC { get; set; }
        protected double Timespan { get; set; }
        public DateTime CurrentTime { get; set; }
        protected string EventName { get; set; }

        //booleans
        public bool eventFinished = false;

        //constructor(s)
        public Event(double timespan, string eventName, DateTime currentTime)
        {
            this.Timespan = timespan;
            this.EventName = eventName;
            this.CurrentTime = currentTime;
            this.ETC = CurrentTime.AddSeconds(timespan);
        }
        //gif, hur säger man det?
        //method(s)
        public virtual void Update()
        {
            
            if (ETC.CompareTo(CurrentTime) == -1)
            {
                eventFinished = true;
            }
        }
    }
}
