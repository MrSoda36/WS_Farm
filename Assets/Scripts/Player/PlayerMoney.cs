using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

    public event Action<int> OnMoneyChanged;

    [field: SerializeField]
    public int Money { get; private set; }

    public void GainMoney(int amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);
    }

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
