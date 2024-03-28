﻿using UnityEngine;

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
                        _playerMoney.SpendMoney(seedShop.SeedPrice);
                    }
                    else
                    {
                        // Not enough space for seed
                    }
                }
                else
                {
                    // Not enough money for seed
                }
            }
            else if (_gameObject.TryGetComponent(out Plant plant))
            {
                _playerPlantActions.CollectPlant(plant.gameObject);
            }
            else if (_gameObject.TryGetComponent(out PlantSeller plantSeller))
            {
                int plantValue = plantSeller.SellPlant(_playerPlantActions.RemovePlant());
                if (plantValue != -1)
                {
                    _playerMoney.GainMoney(plantValue);
                }
                else
                {
                    // No plant to sell
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameObject = collision.gameObject;
    }
}
