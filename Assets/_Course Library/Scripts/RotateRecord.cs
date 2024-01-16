using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecord : MonoBehaviour
{
    public GameObject currentRecord = null;
    public GameObject platter = null;
    public AudioSource speakerBox;
    public AudioClip song;
    public float recordSpinSpeed = 100f;
    public GameObject handle;
    public bool isOn = false;
    public bool isSongPlaying = false;

    // Update is called once per frame
    private void Update()
    {
        // Update the record player based on its current state
        if (isOn)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    // Turn on the record player
    public void TurnOn()
    {
        RotateHandle(145f, 100f);
        RotateRecordPlatter(recordSpinSpeed);

        // Play the song if not already playing
        if (!isSongPlaying)
        {
            PlaySong();
        }
    }

    // Turn off the record player
    public void TurnOff()
    {
        RotateHandle(90f, 100f);
        speakerBox.enabled = false;

        // Reset the record's rotation
        platter.transform.rotation = Quaternion.identity;

        isSongPlaying = false;  // Reset the state when turning off
    }

    // Toggle the record player on/off state
    public void ToggleOnOff()
    {
        isOn = !isOn;

        // If turning off, stop the song
        if (!isOn)
        {
            isSongPlaying = false;
        }
    }

    // Handle trigger when a record is placed
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Record"))
        {
            HandleRecordPlacement(other.gameObject);
        }
    }

    // Handle trigger when a record is removed
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Record"))
        {
            HandleRecordRemoval();
        }
    }

    // Rotate the handle to the target rotation
    private void RotateHandle(float targetRotation, float rotationSpeed)
    {
        handle.transform.rotation = Quaternion.RotateTowards(handle.transform.rotation, Quaternion.Euler(0, targetRotation, 0), rotationSpeed * Time.deltaTime);
    }

    // Rotate the record platter
    private void RotateRecordPlatter(float spinSpeed)
    {
        platter.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    // Play the song from the current record
    private void PlaySong()
    {
        speakerBox.clip = song;
        speakerBox.enabled = true;
        isSongPlaying = true;  // Update the state to indicate that the song is playing
    }

    // Handle logic when a record is placed
    private void HandleRecordPlacement(GameObject record)
    {
        currentRecord = record;

        AudioSource audioSource = currentRecord.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            song = audioSource.clip;
            // Optionally, play the song immediately if the player is on
            if (isOn)
            {
                TurnOn();
            }
        }
        else
        {
            // Handle the case where AudioSource component is not found.
        }
    }

    // Handle logic when a record is removed
    private void HandleRecordRemoval()
    {
        currentRecord = null;
        song = null;
        speakerBox.enabled = false;
        isSongPlaying = false;  // Reset the state when exiting trigger with record
    }
}
