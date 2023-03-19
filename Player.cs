using System;
using System.Collections.Generic;
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
    public List<Laser> LaserList;
    public double Angle { get; set; }
    
    /// <summary>
    /// Provides the needed information to create a player
    /// </summary>
    /// <param name="texture">Texture file for the ship</param>
    /// <param name="pos">Position vector of the player</param>
    public Player(Texture2D texture, Vector2 pos)
    {
        this.texture = texture;
        position = pos;
        Angle = 0;

        LaserList = new List<Laser>();
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
            Angle -= 0.05;
        }

        // Rotates the ship clockwise if the D button is pressed or if the joystick is moved right
        if (Keyboard.GetState().IsKeyDown(Keys.D) ||
            GetButtonDown(1, ArcadeButtons.StickRight)
            || GetButtonDown(2, ArcadeButtons.StickRight))
        {
            Angle += 0.05;
        }

        // Moves the ship forward if the W key is pressed or if the joystick is moved up
        if (Keyboard.GetState().IsKeyDown(Keys.W) ||
            GetButtonDown(1, ArcadeButtons.StickUp) ||
            GetButtonDown(2, ArcadeButtons.StickUp))
        {
            position.X += (float)Math.Sin(Angle) * 2;
            position.Y -= (float)Math.Cos(Angle) * 2;
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.Space) ||
            GetButtonDown(1, ArcadeButtons.A1) ||
            GetButtonDown(2, ArcadeButtons.A1))
        {
            LaserList.Add(new Laser(texture, position, Angle));
        }
    }
    
    /// <summary>
    /// Draws the player ship at the proper position and rotation
    /// </summary>
    /// <param name="spriteBatch">Object that allows items to be drawn to the screen</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            texture, 
            position, 
            null, 
            Color.White, 
            (float)Angle, 
            new Vector2(texture.Bounds.Center.X, texture.Bounds.Center.Y),
            1f,
            SpriteEffects.None, 
            0f);
    }
}