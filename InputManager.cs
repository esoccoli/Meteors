using Devcade;
using Microsoft.Xna.Framework.Input;
using static Devcade.Input;

namespace Meteors;

/// <summary>
/// Checks for user input from both devcade controls and keyboard/mouse
/// </summary>
public static class InputManager
{
    private static KeyboardState kbState;
    private static KeyboardState prevKbState;

    static InputManager()
    {
        
    }
}