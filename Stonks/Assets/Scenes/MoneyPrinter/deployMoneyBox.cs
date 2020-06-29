using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployMoneyBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moneyBoxPrefab;
    public GameObject canvasParent;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(moneyBoxSpawn());
    }

    private void spawnBox()
    {
        GameObject a = Instantiate(moneyBoxPrefab) as GameObject;
        a.transform.parent = canvasParent.transform;
        a.transform.position = new Vector2(-145, 375);
    }

    IEnumerator moneyBoxSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnBox();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
