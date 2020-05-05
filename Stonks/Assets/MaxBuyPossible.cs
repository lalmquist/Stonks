using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxBuyPossible : MonoBehaviour
{
    float money_float;
    float stockPrice_float;
    int maxbuy_int;
    float maxbuy_float;

    [SerializeField] TextMeshProUGUI money;
    [SerializeField] TextMeshProUGUI stockPrice;
    [SerializeField] TextMeshProUGUI maxBuy_Possible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float.TryParse(money.text, out money_float);
        float.TryParse(stockPrice.text, out stockPrice_float);

        maxbuy_float = money_float / stockPrice_float;

        maxbuy_int = Mathf.FloorToInt(maxbuy_float);

        maxBuy_Possible.text = maxbuy_int.ToString();
    }
}
