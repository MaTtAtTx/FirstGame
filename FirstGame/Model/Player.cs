using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstGame.Model
{
	public class Player
	{
		public Player()
		{
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
			get { return PlayerTexture.Width; }
		}

		public int Height
		{
			get { return PlayerTexture.Height; }
		}

		public void Initialize(Texture2D texture, Vector2 position)
		{
			PlayerTexture = texture;
			Position = position;
			Active = true;
			Health = 100;
		}

		public void Update()
		{
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}
