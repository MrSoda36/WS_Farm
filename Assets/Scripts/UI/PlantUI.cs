using UnityEngine;

/// <summary>
/// Class handling the plant UI in the game.
/// </summary>
public class PlantUI : MonoBehaviour
{
    [SerializeField]
    private PlayerPlantActions _player;
    private TMPro.TextMeshProUGUI _plantText;

    /// <summary>
    /// Update the plant inventory text.
    /// </summary>
    /// <param name="plants">The new amount of Player's plants.</param>
    public void UpdatePlantText(int plants)
    {
        _plantText.text = "Plants: " + plants + " / 4";
    }

    private void Start()
    {
        _player.OnPlantChanged += UpdatePlantText;
        _plantText = GetComponent<TMPro.TextMeshProUGUI>();
        UpdatePlantText(0);
    }
}
