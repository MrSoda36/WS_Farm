using UnityEngine;

public class SeedShop : MonoBehaviour
{
    [SerializeField]
    private Seed _seed;

    public int SeedPrice { get; private set; }

    public Seed BuySeed()
    {
        return _seed;
    }

    private void Awake()
    {
        SeedPrice = _seed.Cost;
    }
}
