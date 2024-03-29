using UnityEngine;

/// <summary>
/// Main class for the player.
/// It handles the player interactions with the game objects.
/// It store references to the player's components.
/// </summary>
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

    private GameObject _interactedObject;

    /// <summary>
    /// Handle the player interaction with the game object.
    /// </summary>
    public void OnInteract()
    {
        if (_interactedObject != null)
        {
            if (_interactedObject.TryGetComponent(out Field field))
            {
                _playerSeedActions.PlantSeed(field);
            }
            else if (_interactedObject.TryGetComponent(out Plant plant))
            {
                _playerPlantActions.CollectPlant(plant.gameObject);
            }
            else if (_interactedObject.TryGetComponent(out SeedShop seedShop))
            {
                if (_playerMoney.Money >= seedShop.SeedPrice)
                {
                    GameObject seedObject = seedShop.BuySeed();
                    bool actionSuccess = _playerSeedActions.AddSeed(seedObject);
                    if (actionSuccess)
                    {
                        _playerMoney.SpendMoney(seedShop.SeedPrice);
                    }
                }
            }
            else if (_interactedObject.TryGetComponent(out PlantSeller plantSeller))
            {
                int plantValue = plantSeller.SellPlant(_playerPlantActions.RemovePlant());
                if (plantValue != -1)
                {
                    _playerMoney.GainMoney(plantValue);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _interactedObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactedObject = null;
    }
}
