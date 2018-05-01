using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FirstGame.View;

namespace FirstGame.Model
{
	public class Player
	{

		public Player()
		{
		}

		private Animation playerAnimation;
		public Animation PlayerAnimation
		{
			get { return playerAnimation; }
			set { playerAnimation = value; }
		}

		private Texture2D playerTexture;
		public Texture2D PlayerTexture
		{
			get { return playerTexture; }
			set { playerTexture = value; }
		}

		public Vector2 Position;

		private bool active;
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

        private int health;
		public int Health
		{
			get { return health; }
			set { health = value; }
		}

		public int Width
		{
			get { return playerAnimation.FrameWidth; }
		}

		public int Height
		{
			get { return playerAnimation.FrameHeight; }
		}

		public void Initialize(Animation animation, Vector2 position)
		{
			playerAnimation = animation;
			Position = position;
			Active = true;
			Health = 100;
		}

		public void Update(GameTime gameTime)
		{
			playerAnimation.Position = Position;
			playerAnimation.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			playerAnimation.Draw(spriteBatch);
		}
	}
}
