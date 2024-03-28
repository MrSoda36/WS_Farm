using UnityEngine;

/// <summary>
/// Class handling the seed UI in the game.
/// </summary>
public class SeedUI : MonoBehaviour
{
    [SerializeField]
    private PlayerSeedActions _player;
    private TMPro.TextMeshProUGUI _seedText;

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
        _player.OnSeedChanged += UpdateSeedText;
        _seedText = GetComponent<TMPro.TextMeshProUGUI>();
        UpdateSeedText(0);
    }
}
