using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    // Start is called before the first frame update
public Text MoneyBalance;

    // Update is called once per frame
    void Update()
    {
        MoneyBalance.text = PlayerStats.money.ToString()+" G";
    }
}
