using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FirstGame.Model;
using FirstGame.View;

namespace FirstGame.Controller
{
	public class SpaceGame : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		private Player player;
		private KeyboardState currentKeyboardState;
		private KeyboardState previousKeyboardState;
		private GamePadState currentGamePadState;
		private GamePadState previousGamePadState;
		private float playerMoveSpeed;
		private Texture2D mainBackground;
		private ParallaxingBackground bgLayer1;
		private ParallaxingBackground bgLayer2;

		public SpaceGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			player = new Player();
			bgLayer1 = new ParallaxingBackground();
			bgLayer2 = new ParallaxingBackground();
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: use this.Content to load your game content here 

			// Load the parallaxing background
			bgLayer1.Initialize(Content, "Texture/bgLayer1", GraphicsDevice.Viewport.Width, -1);
			bgLayer2.Initialize(Content, "Texture/bgLayer2", GraphicsDevice.Viewport.Width, -2);

			mainBackground = Content.Load<Texture2D>("Texture/mainbackground");

			// Load the player resources
			Animation playerAnimation = new Animation();
			Texture2D playerTexture = Content.Load<Texture2D>("Animation/shipAnimation");
			playerAnimation.Initialize(playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 1f, true);

			Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
			player.Initialize(playerAnimation, playerPosition);

			playerMoveSpeed = 8.0f;
		}

		protected override void Update(GameTime gameTime)
		{
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif

			// TODO: Add your update logic here

			previousGamePadState = currentGamePadState;
			previousKeyboardState = currentKeyboardState;

			currentKeyboardState = Keyboard.GetState();
			currentGamePadState = GamePad.GetState(PlayerIndex.One);

			UpdatePlayer(gameTime);
			base.Update(gameTime);

			// Update the parallaxing background
			bgLayer1.Update();
			bgLayer2.Update();
		}

		private void UpdatePlayer(GameTime gameTime)
		{
			player.Update(gameTime);

			// Get Thumbstick Controls
   	 		player.Position.X += currentGamePadState.ThumbSticks.Left.X* playerMoveSpeed;
			player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y* playerMoveSpeed;

    		// Use the Keyboard / Dpad
    		if (currentKeyboardState.IsKeyDown(Keys.Left) || currentGamePadState.DPad.Left == ButtonState.Pressed)
    		{
      		  	player.Position.X -= playerMoveSpeed;
   			}
    		if (currentKeyboardState.IsKeyDown(Keys.Right) || currentGamePadState.DPad.Right == ButtonState.Pressed)
    		{
        		player.Position.X += playerMoveSpeed;
    		}
    		if (currentKeyboardState.IsKeyDown(Keys.Up) || currentGamePadState.DPad.Up == ButtonState.Pressed)
    		{
    			player.Position.Y -= playerMoveSpeed;
    		}
    		if (currentKeyboardState.IsKeyDown(Keys.Down) || currentGamePadState.DPad.Down == ButtonState.Pressed)
    		{		
        		player.Position.Y += playerMoveSpeed;
    		}

    		// Make sure that the player does not go out of bounds
    		player.Position.X = MathHelper.Clamp(player.Position.X, 0,GraphicsDevice.Viewport.Width - player.Width);
    		player.Position.Y = MathHelper.Clamp(player.Position.Y, 0,GraphicsDevice.Viewport.Height - player.Height);
		}

		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			//TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(mainBackground, Vector2.Zero, Color.White);
			bgLayer1.Draw(spriteBatch);
			bgLayer2.Draw(spriteBatch);
			player.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
