using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindGameObject : MonoBehaviour
{
    public GameObject referenceObject;

    public Slider sliderComponent;

    public float rotation;

    public void Start()
    {
        if (referenceObject == null)
        {
            referenceObject = GameObject.FindGameObjectWithTag("Shape");
        } else 
        {
            Debug.Log("Reference to GameObject found");
        }
    }
    public void Update()
    {
        if (referenceObject == null)
        {
                     
            referenceObject = GameObject.FindGameObjectWithTag("Shape");

        } else
        {
            rotation = sliderComponent.value;
            RotateGameObject(rotation);
        }

        

    }

    public void RotateGameObject(float rotation)
    {

            referenceObject.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
    }
}
