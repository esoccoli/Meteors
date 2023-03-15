using System;
using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Devcade.Input;

namespace Meteors;

public class Player
{
    private Texture2D texture;
    private Vector2 position;
    private double angle;
    
    public Player(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
        angle = Math.PI / 2;
    }

    public void Update(GameTime gameTime)
    {
        // Rotates the ship counterclockwise if the A button is pressed or if the joystick is moved left
        if (Keyboard.GetState().IsKeyDown(Keys.A) ||
            GetButtonDown(1, ArcadeButtons.StickLeft) ||
            GetButtonDown(2, ArcadeButtons.StickLeft))
        {
            angle -= 0.05;
        }

        // Rotates the ship clockwise if the D button is pressed or if the joystick is moved right
        if (Keyboard.GetState().IsKeyDown(Keys.D) ||
            GetButtonDown(1, ArcadeButtons.StickRight)
            || GetButtonDown(2, ArcadeButtons.StickRight))
        {
            angle += 0.05;
        }

        // Moves the ship forward if the W button is pressed or if the joystick is moved up
        if (Keyboard.GetState().IsKeyDown(Keys.W) ||
            GetButtonDown(1, ArcadeButtons.StickUp) ||
            GetButtonDown(2, ArcadeButtons.StickUp))
        {
            position.X += (float)Math.Sin(angle) * 2f;
            position.Y -= (float)Math.Cos(angle) * 2f;
            
        }
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, null, Color.White, (float)angle, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
    }
    
    
}