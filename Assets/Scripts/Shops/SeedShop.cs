using UnityEngine;

/// <summary>
/// Class representing the shop where the player buys seeds.
/// </summary>
public class SeedShop : MonoBehaviour
{
    [SerializeField]
    private GameObject _seedObject;

    /// <summary>
    /// Gets the price of the seed.
    /// </summary>
    public int SeedPrice { get; private set; }

    /// <summary>
    /// Buy a seed.
    /// </summary>
    /// <returns>The GameObject of the seed.</returns>
    public GameObject BuySeed()
    {
        return _seedObject;
    }

    private void Awake()
    {
        SeedPrice = _seedObject.GetComponent<Seed>().Cost;
    }
}
