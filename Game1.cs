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

    private Player player;
    private Texture2D asteroid;
    private Texture2D ship;

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
        asteroid = Content.Load<Texture2D>("Asteroid");
        ship = Content.Load<Texture2D>("Ship");

        player = new Player(ship, playerPosition);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
