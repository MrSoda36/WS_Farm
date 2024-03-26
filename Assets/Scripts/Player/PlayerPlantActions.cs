using System;
using UnityEngine;

public class PlayerPlantActions : MonoBehaviour
{
    private PlayerMain _playerMain;

    public event Action<Plant> OnPlantChanged;
}
