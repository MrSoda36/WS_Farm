using System;
using UnityEngine;

/// <summary>
/// Class handling the player's money in the game.
/// </summary>
public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

    /// <summary>
    /// Event when the player's money changes.
    /// </summary>
    public event Action<int> OnMoneyChanged;

    /// <summary>
    /// Gets the player's money.
    /// </summary>
    [field: SerializeField]
    public int Money { get; private set; }

    /// <summary>
    /// Gain money.
    /// </summary>
    /// <param name="amount">The amount gain.</param>
    public void GainMoney(int amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);
    }

    /// <summary>
    /// Spend money.
    /// </summary>
    /// <param name="amount">The amount spend.</param>
    public void SpendMoney(int amount)
    {
        Money -= amount;
        OnMoneyChanged?.Invoke(Money);
    }

    private void Awake()
    {
        Money = 20;
    }
}
