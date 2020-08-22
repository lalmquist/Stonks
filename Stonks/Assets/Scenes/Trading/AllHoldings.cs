using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllHoldings : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI holding1;
    [SerializeField] TextMeshProUGUI holding2;
    [SerializeField] TextMeshProUGUI holding3;
    [SerializeField] TextMeshProUGUI holding4;

    float holding1_float;
    float holding2_float;
    float holding3_float;
    float holding4_float;

    float total_holdings;

    bool trybool;

    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        trybool = float.TryParse(holding1.text, out holding1_float);
        trybool = float.TryParse(holding2.text, out holding2_float);
        trybool = float.TryParse(holding3.text, out holding3_float);
        trybool = float.TryParse(holding4.text, out holding4_float);

        total_holdings = holding1_float + holding2_float + holding3_float + holding4_float;

        textMesh.text = total_holdings.ToString("n2");
    }
}
