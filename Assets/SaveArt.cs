using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveArt : MonoBehaviour
{
    public GameObject objectToBeSaved;
    public GameObject savePosition;
    public float scaleValue = .25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveObject()
    {
        objectToBeSaved = GameObject.FindGameObjectWithTag("Shape");
        objectToBeSaved.transform.localScale = new Vector3(scaleValue ,scaleValue, scaleValue);
        objectToBeSaved.transform.position = savePosition.transform.position;
        objectToBeSaved.tag = "Art";
    }
}
 