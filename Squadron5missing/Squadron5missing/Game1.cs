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

namespace Squadron5missing
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BackScroll b;
        
        DateTime clock;
        SpriteFont testFont;
        SpriteFont fontSmall;
        Event e;
        Mechanic mechanic;
        EngineEvent engineEvent;

        Resources resource;

        //Put all foreground objects here
        ForegroundObject chair;
        ForegroundObject elevator;

        Random rand;
        //List<string> alertList = new List<string>();
        List<Event> alertListv2 = new List<Event>();
        List<Button> buttonList;

        Texture2D ProblemMenuBackground;
        Texture2D background;
        Texture2D menu;

        //Not in use remove when there is time
        Texture2D repairKnapp;
        Texture2D matKnapp;
        Texture2D sjukv�rdsKnapp;
        Rectangle repairKnappRectangle;
        Rectangle matKnappRectangle;
        Rectangle sjukv�rdsKnappRectangle;
        
        //in use
        Texture2D yesButton;
        Texture2D noButton;
        

        ErrorMessage p;
        int gameSpeed = 1;
        int temp;
        int maxEvents;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            clock = new DateTime();

            b = new BackScroll(Content.Load<Texture2D>("space02"), Content.Load<Texture2D>("space03"), .08f);
            background = Content.Load<Texture2D>("background01");
            menu = Content.Load<Texture2D>("menu_layout");

            chair = new ForegroundObject(Content.Load<Texture2D>("chair02"), new Vector2(762, 430), 150, 150, 2, 2, 400);
            elevator = new ForegroundObject(Content.Load<Texture2D>("elevator_002"), new Vector2(352, 234), 500, 500, 13, 4, 100);

            this.IsMouseVisible = true;
            
            base.Initialize();

            resource = new Resources(200, 300, 100, 3000);

            buttonList = new List<Button>();
            /*
            buttonList.Add(new Button(Content.Load<Texture2D>("button"), new Vector2(520, 575), Color.White, ButtonName.Eat));
            buttonList.Add(new Button(Content.Load<Texture2D>("button"), new Vector2(850, 575), Color.White, ButtonName.Resolve));
            buttonList.Add(new Button(Content.Load<Texture2D>("button"), new Vector2(520, 750), Color.White, ButtonName.Talk));
            buttonList.Add(new Button(Content.Load<Texture2D>("button"), new Vector2(850, 750), Color.White, ButtonName.Tweak));*/

            //Setting graphics settings
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            rand = new Random();
            //Initializing characters
            mechanic = new Mechanic(Content.Load<Texture2D>("Kitty Breath Blink"), new Vector2(1000, 450), RoomE.Bridge, resource, "Morgan the Mechanic", 174, 300, 9, 5, new Button(Content.Load<Texture2D>("button"), new Vector2(520, 575), Color.White, ButtonName.Eat),
                new Button(Content.Load<Texture2D>("button"), new Vector2(850, 575), Color.White, ButtonName.Resolve), new Button(Content.Load<Texture2D>("button"), new Vector2(520, 750), Color.White, ButtonName.Heal), new Button(Content.Load<Texture2D>("button")
                    , new Vector2(850, 750), Color.White, ButtonName.Upgrade), Content.Load<Texture2D>("Kitty Walk Left"), Content.Load<Texture2D>("Kitty Walk Right"), 5, 5, 5, 5, 5, "Olaf");

            p = new ErrorMessage(mechanic);

            //Initializing events
            engineEvent = new EngineEvent(200, "Engine broke down", clock, "The engines Fluxual Accelerate Perperator has been damaged and needs repair");

            //Initializing variables

            maxEvents = 5;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads all colors
            testFont = Content.Load<SpriteFont>("TestFont");
            fontSmall = Content.Load<SpriteFont>("CsFontSmall");
            matKnapp = Content.Load<Texture2D>("Mat knapp");
            sjukv�rdsKnapp = Content.Load<Texture2D>("Sjukv�rds knapp");
            repairKnapp = Content.Load<Texture2D>("Repair_knapp");
            ProblemMenuBackground = Content.Load<Texture2D>("ProblemMenu");
            yesButton = Content.Load<Texture2D>("YesButton");
            noButton = Content.Load<Texture2D>("NoButton");

            //loads rectangles
            repairKnappRectangle = new Rectangle(125, 3, 111, 83);
            sjukv�rdsKnappRectangle = new Rectangle(125, 103, 111, 83);
            matKnappRectangle = new Rectangle(125, 203, 111, 83);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
                this.Exit();

            //Updates diffrent game objects and adds the seconds to the clock
            mechanic.Update(gameTime);
            b.Scroll(GraphicsDevice);

            chair.Update(gameTime);
            elevator.Update(gameTime);
            
            clock = clock.AddMilliseconds(16.6666666666667 * gameSpeed);
            
            p.SchedueldAlertMessage(clock, yesButton, new Vector2(75, 75), noButton);
            p.Update(spriteBatch, testFont, new Vector2(75, 75), yesButton, noButton, new Vector2());

            //Update function for both the yes and the no buttons
            foreach (YesButton yes in ListOfYNButtons.ButtonList)
            {
                yes.Update(gameTime);
            }
            foreach (NoButton no in ListOfYNButtons.ButtonList2)
            {
                no.Update(gameTime);
            }
            foreach (Button but in buttonList)
            {
                but.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            b.Draw(spriteBatch);
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            chair.Draw(spriteBatch);

            elevator.Draw(spriteBatch);


            for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
            {
                ListOfEvents.StatListEvents[i].Update();
                ListOfEvents.StatListEvents[i].CurrentTime = clock;
            }

            resource.PrintInfo(testFont, spriteBatch);

            //engineEvent.DrawText(spriteBatch, testFont, new Vector2(100, 700));
            mechanic.Draw(spriteBatch);
            spriteBatch.DrawString(testFont, clock.ToLongTimeString(), new Vector2(3, 2), Color.White);
            
            p.Draw(spriteBatch,testFont,ProblemMenuBackground,new Vector2(332,5),fontSmall, clock);
            
            foreach (Button but in buttonList)
            {
                but.Draw(spriteBatch);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.H))//replace Key with File capinet button instead or some other more imersive game mechanic
            {
                for (int i = 0; i < ListOfEvents.StatListEvents.Count; i++)
                {
                    spriteBatch.DrawString(testFont, ListOfEvents.StatListEvents[i].EventName, new Vector2(1200, 20 * i), Color.White);
                    spriteBatch.DrawString(testFont, ListOfEvents.StatListEvents[i].ETC.ToLongTimeString(), new Vector2(1062, 20 * i), Color.White);
                }
            }

            foreach (YesButton yes in ListOfYNButtons.ButtonList)
            {
                yes.Draw(spriteBatch);
            }
            foreach (NoButton no in ListOfYNButtons.ButtonList2)
            {
                no.Draw(spriteBatch);
            }
            spriteBatch.Draw(menu, new Vector2(-2, 538), Color.White);
            mechanic.DrawText(spriteBatch, testFont);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
