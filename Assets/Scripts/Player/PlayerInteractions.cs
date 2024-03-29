using UnityEngine;

/// <summary>
/// Handle the player interactions with the game objects.
/// </summary>
public class PlayerInteractions : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

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
                _playerMain.PlayerSeedActions.PlantSeed(field);
            }
            else if (_interactedObject.TryGetComponent(out Plant plant))
            {
                _playerMain.PlayerPlantActions.CollectPlant(plant.gameObject);
            }
            else if (_interactedObject.TryGetComponent(out SeedShop seedShop))
            {
                if (_playerMain.PlayerMoney.Money >= seedShop.SeedPrice)
                {
                    GameObject seedObject = seedShop.SeedObject;
                    bool actionSuccess = _playerMain.PlayerSeedActions.AddSeed(seedObject);
                    if (actionSuccess)
                    {
                        _playerMain.PlayerMoney.SpendMoney(seedShop.SeedPrice);
                    }
                }
            }
            else if (_interactedObject.TryGetComponent(out PlantSeller plantSeller))
            {
                int plantValue = plantSeller.SellPlant(_playerMain.PlayerPlantActions.RemovePlant());
                if (plantValue != -1)
                {
                    _playerMain.PlayerMoney.GainMoney(plantValue);
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
