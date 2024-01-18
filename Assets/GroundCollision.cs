using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField] private AudioSource collisionAudio;

    private void Awake()
    {
        if (collisionAudio == null)
        {
            collisionAudio = GetComponent<AudioSource>();
        } else if (collisionAudio != null)
        {
            Debug.Log("CollisionAudio detected and added");
        } else
        {
            Debug.Log("Must add an audio source to detector object");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionAudio.Play();
    }
}
