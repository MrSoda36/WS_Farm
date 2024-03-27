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
                Debug.Log("[FIELD] Try planting a seed");
                _playerSeedActions.PlantSeed(field);
            }
            else if (_gameObject.TryGetComponent(out SeedShop seedShop))
            {
                if (_playerMoney.Money >= seedShop.SeedPrice)
                {
                    GameObject seedObject = seedShop.BuySeed();
                    bool actionSuccess = _playerSeedActions.AddSeed(seedObject);
                    if (actionSuccess)
                    {
                        Debug.Log("Seed bought for " + seedShop.SeedPrice);
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
            else if (_gameObject.TryGetComponent(out Plant plant))
            {
                Debug.Log("[PLANT] Try collecting plant");
                _playerPlantActions.CollectPlant(plant.gameObject);
            }
            else if (_gameObject.TryGetComponent(out PlantSeller plantSeller))
            {
                int plantValue = plantSeller.SellPlant(_playerPlantActions.RemovePlant());
                if (plantValue != -1)
                {
                    Debug.Log("Plant sold for " + plantValue);
                    _playerMoney.GainMoney(plantValue);
                }
                else
                {
                    Debug.Log("No plant to sell.");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameObject = collision.gameObject;
    }
}
