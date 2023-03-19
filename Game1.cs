using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Devcade.Input;

namespace Meteors;

public class Game1 : Game
{
    public static Game1 game;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Player Player;
    public Laser laser;
    
    private Texture2D asteroidTexture;
    private Texture2D shipTexture;
    private Texture2D laserTexture;
    
    private Vector2 playerPosition;
    private Vector2 asteroidPosition;


    /// <summary>
    /// Returns a rectangle representing the bounds of the game window
    /// </summary>
    public static Rectangle WindowBounds => game.GraphicsDevice.Viewport.Bounds;
    
    public Game1()
    {
        game = this;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        _graphics.PreferredBackBufferWidth = 420;
        _graphics.PreferredBackBufferHeight = 980;
        _graphics.ApplyChanges();
        
        playerPosition = new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2,
            GraphicsDevice.Viewport.Bounds.Height - 200);
        
        asteroidPosition = new Vector2(200, 300);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        asteroidTexture = Content.Load<Texture2D>("Asteroid");
        shipTexture = Content.Load<Texture2D>("Ship");
        laserTexture = Content.Load<Texture2D>("laser");

        Player = new Player(shipTexture, playerPosition);
        laser = new Laser(laserTexture, playerPosition, 0);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        Player.Update(gameTime);
        for (int i = 0; i < Player.LaserList.Count; i++)
        {
            Player.LaserList[i].Update(gameTime);
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        
        _spriteBatch.Begin();
        Player.Draw(_spriteBatch);
        for (int i = 0; i < Player.LaserList.Count; i++)
        {
            Player.LaserList[i].Draw(_spriteBatch);
        }
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
