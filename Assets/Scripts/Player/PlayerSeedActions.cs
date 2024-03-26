using System;
using UnityEngine;

public class PlayerSeedActions : MonoBehaviour
{
    private PlayerMain _playerMain;

    public event Action<Seed> OnSeedChanged;
}
