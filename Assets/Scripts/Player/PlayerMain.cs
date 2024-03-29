using UnityEngine;

/// <summary>
/// Main class for the player.
/// It store references to the player's components.
/// </summary>
public class PlayerMain : MonoBehaviour
{
    [field:SerializeField]
    public PlayerMovement PlayerMovement { get; private set; }

    [field:SerializeField]
    public PlayerMoney PlayerMoney { get; private set; }

    [field: SerializeField]
    public PlayerSeedActions PlayerSeedActions { get; private set; }

    [field: SerializeField]
    public PlayerPlantActions PlayerPlantActions { get; private set; }

    [field: SerializeField]
    public PlayerInteractions PlayerInteractions { get; private set; }
}
