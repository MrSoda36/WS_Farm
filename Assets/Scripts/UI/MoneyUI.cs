using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField]
    private PlayerMoney _player;
    private TMPro.TextMeshProUGUI _moneyText;

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
