// contains all data related to the app

// Hold the application’s core data and state, such as player health or gun ammo.
// Serialize, deserialize, and/or convert between types.
// Load/save data (locally or on the web).
// Notify Controllers of the progress of operations.
// Store the Game State for the Game’s Finite State Machine.
// Never access Views.

public class PECModel : PECElement
{
    // Gives access to the application and all instances.
    protected void Awake()
    {
        base.Awake();
        app = FindObjectOfType<PECApplication>();
    }
}
