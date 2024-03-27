using UnityEngine;

public class SeedShop : MonoBehaviour
{
    [SerializeField]
    private GameObject _seedObject;

    public int SeedPrice { get; private set; }

    public GameObject BuySeed()
    {
        return _seedObject;
    }

    private void Awake()
    {
        SeedPrice = _seedObject.GetComponent<Seed>().Cost;
    }
}
