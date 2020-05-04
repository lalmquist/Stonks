using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockPrice : MonoBehaviour
{

    float interval;
    float stock_price = 0;

    [SerializeField] float targetTime;
    [SerializeField] TextMeshProUGUI stockPrice;


    // Start is called before the first frame update
    void Start()
    {
        stockPrice.text = "145";
        interval = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (interval <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        float.TryParse(stockPrice.text, out stock_price);
        stock_price = stock_price + Random.Range(-10.0f, 10.0f);

        stockPrice.text = stock_price.ToString();

        interval = targetTime;

    }
}