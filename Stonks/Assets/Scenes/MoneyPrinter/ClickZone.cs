using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZone : MonoBehaviour
{
    bool inZone;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(Input.GetMouseButtonDown(0) & inZone == false)
        {
            Debug.Log("here");
            inZone = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inZone = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
