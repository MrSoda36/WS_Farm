using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;
    [SerializeField]
    private PlayerMoney _playerMoney;
    [SerializeField]
    private PlayerSeedActions _playerSeedActions;
    [SerializeField]
    private PlayerPlantActions _playerPlantActions;

    private GameObject _gameObject;

    public void OnInteract()
    {
        if (_gameObject != null)
        {
            if (_gameObject.TryGetComponent(out Field field))
            {
                Debug.Log("Interacting with a field : " + _gameObject);
                _playerSeedActions.PlantSeed(field);
            }
            else if (_gameObject.TryGetComponent(out SeedShop seedShop))
            {
                Debug.Log("Interacting with Seed Shop : " + _gameObject);
                if (_playerMoney.Money >= seedShop.SeedPrice)
                {
                    Seed seed = seedShop.BuySeed();
                    bool actionSuccess = _playerSeedActions.AddSeed(seed);
                    if (actionSuccess)
                    {
                        _playerMoney.SpendMoney(seedShop.SeedPrice);
                    }
                    else
                    {
                        Debug.Log("Not enough space to carry seed.");
                    }
                }
                else
                {
                    Debug.Log("Not enough money to buy seed.");
                }
            }
        }
    }

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMoney = GetComponent<PlayerMoney>();
        _playerSeedActions = GetComponent<PlayerSeedActions>();
        _playerPlantActions = GetComponent<PlayerPlantActions>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameObject = collision.gameObject;
    }
}
