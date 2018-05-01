﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FirstGame.View
{
	public class ParallaxingBackground
	{
		private Texture2D texture;
		private Vector2[] positions;
		private int speed;

		public ParallaxingBackground()
		{
		}

		public void Initialize(ContentManager content, String texturePath, int screenWidth, int speed)
		{
			texture = content.Load<Texture2D>(texturePath);
			this.speed = speed;
			positions = new Vector2[screenWidth / texture.Width + 1];

			for (int i = 0; i < positions.Length; i++)
			{
				// We need the tiles to be side by side to create a tiling effect
				positions[i] = new Vector2(i * texture.Width, 0);
 			}
		}

		public void Update()
		{
			// Update the positions of the background
			for (int i = 0; i < positions.Length; i++)
			{
				// Update the position of the screen by adding the speed
				positions[i].X += speed;
				// If the speed has the background moving to the left
				if (speed <= 0)
				{
					// Check the texture is out of view then put that texture at the end of the screen
					if (positions[i].X <= -texture.Width)
					{
						positions[i].X = texture.Width * (positions.Length - 1);
					}
				}

				// If the speed has the background moving to the right
				else
				{
					// Check if the texture is out of view then position it to the start of the screen
					if (positions[i].X >= texture.Width * (positions.Length - 1))
					{
						positions[i].X = -texture.Width;
					}
				}
		 	}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < positions.Length; i++)
			{
				spriteBatch.Draw(texture, positions[i], Color.White);
		 	}
		}
	}
}
