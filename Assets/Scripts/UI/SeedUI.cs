using UnityEngine;

public class SeedUI : MonoBehaviour
{
    [SerializeField]
    private PlayerSeedActions _player;
    private TMPro.TextMeshProUGUI _seedText;

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
