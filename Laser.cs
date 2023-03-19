using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Devcade.Input;

namespace Meteors;

public class Laser
{
    private List<Laser> laserList;
    private Texture2D texture;
    private Vector2 position;
    private double angle;
    

    public Laser(Texture2D texture, Vector2 pos, double angle)
    {
        this.texture = texture;
        this.angle = angle;
        position = new Vector2((float)(pos.X + Math.Cos(angle)), (float)(pos.Y + Math.Sin(angle)));
        laserList = Game1.game.Player.LaserList;
    }
    
    public void Update(GameTime gameTime)
    {
        for (int i = 0; i < laserList.Count; i++)
        {
            laserList[i].position.X += (float)Math.Sin(angle) * 2;
            laserList[i].position.Y -= (float)Math.Cos(angle) * 2;
        }
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < laserList.Count; i++)
        {
            spriteBatch.Draw(texture, position, null, Color.White, (float)angle, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}