using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;
    private int _money;

    public event Action<int> OnMoneyChanged;
}
