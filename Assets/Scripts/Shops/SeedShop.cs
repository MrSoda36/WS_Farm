using UnityEngine;

/// <summary>
/// Class representing the shop where the player buys seeds.
/// </summary>
public class SeedShop : MonoBehaviour
{
    /// <summary>
    /// Gets the GameObject of the seed.
    /// </summary>
    [field: SerializeField]
    public GameObject SeedObject { get; private set; }

    /// <summary>
    /// Gets the price of the seed.
    /// </summary>
    public int SeedPrice { get; private set; }

    private void Awake()
    {
        SeedPrice = SeedObject.GetComponent<Seed>().Cost;
    }
}
