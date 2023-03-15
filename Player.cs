using System;
using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Devcade.Input;

namespace Meteors;

/// <summary>
/// Manages the player controllable spaceship
/// </summary>
public class Player
{
    private Texture2D texture;
    private Vector2 position;
    private double angle;
    
    /// <summary>
    /// Provides the needed information to create a player
    /// </summary>
    /// <param name="texture">Texture file for the ship</param>
    /// <param name="position">Position vector of the player</param>
    public Player(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
        angle = Math.PI / 2;
    }
    
    /// <summary>
    /// Updates the player's position and rotation each frame based on keybord/devcade input
    /// Currently the ship moves at constant velocity, will implement acceleration later
    /// </summary>
    /// <param name="gameTime">Elapsed time in the game since the last frame</param>
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

        // Moves the ship forward if the W or S key is pressed or if the joystick is moved up
        if (Keyboard.GetState().IsKeyDown(Keys.W) ||
            Keyboard.GetState().IsKeyDown(Keys.S) ||
            GetButtonDown(1, ArcadeButtons.StickUp) ||
            GetButtonDown(2, ArcadeButtons.StickUp))
        {
            position.X += (float)Math.Sin(angle) * 2f;
            position.Y -= (float)Math.Cos(angle) * 2f;
            
        }
    }
    
    /// <summary>
    /// Draws the player ship at the proper position and rotation
    /// </summary>
    /// <param name="spriteBatch">Object that allows items to be drawn to the screen</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, null, Color.White, (float)angle, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
    }
    
    
}