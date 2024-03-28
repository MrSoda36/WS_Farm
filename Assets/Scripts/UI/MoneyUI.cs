using UnityEngine;

/// <summary>
/// Class handling the money UI in the game.
/// </summary>
public class MoneyUI : MonoBehaviour
{
    [SerializeField]
    private PlayerMoney _player;
    private TMPro.TextMeshProUGUI _moneyText;

    /// <summary>
    /// Update the money text.
    /// </summary>
    /// <param name="money">The new amount of Player's money.</param>
    public void UpdateMoneyText(int money)
    {
       _moneyText.text = "Money: " + money;
    }

    private void Start()
    {
        _player.OnMoneyChanged += UpdateMoneyText;
        _moneyText = GetComponent<TMPro.TextMeshProUGUI>();
        UpdateMoneyText(_player.Money);
    }
}
