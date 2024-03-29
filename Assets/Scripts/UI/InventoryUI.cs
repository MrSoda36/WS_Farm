using UnityEngine;

/// <summary>
/// Controls the UI linked to the Player's seed and plant inventory.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _player;
    [SerializeField]
    private TMPro.TextMeshProUGUI _plantText;
    [SerializeField]
    private TMPro.TextMeshProUGUI _seedText;

    /// <summary>
    /// Update the plant inventory text.
    /// </summary>
    /// <param name="plants">The new amount of Player's plants.</param>
    public void UpdatePlantText(int plants)
    {
        _plantText.text = "Plants: " + plants + " / 4";
    }

    /// <summary>
    /// Update the seed inventory text.
    /// </summary>
    /// <param name="seeds">The new amount of Player's seeds.</param>
    public void UpdateSeedText(int seeds)
    {
        _seedText.text = "Seeds: " + seeds + " / 4";
    }

    private void Start()
    {
        _player.PlayerPlantActions.OnPlantChanged += UpdatePlantText;
        UpdatePlantText(0);
        _player.PlayerSeedActions.OnSeedChanged += UpdateSeedText;
        UpdateSeedText(0);
    }
}
