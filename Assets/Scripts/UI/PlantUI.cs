using UnityEngine;

public class PlantUI : MonoBehaviour
{
    [SerializeField]
    private PlayerPlantActions _player;
    private TMPro.TextMeshProUGUI _plantText;

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
