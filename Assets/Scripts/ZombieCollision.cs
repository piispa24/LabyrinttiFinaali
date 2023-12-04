using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieCollision : MonoBehaviour
{
    private bool hasLoadedEndScene = false; // Flag to track if the scene has been loaded

    public AudioClip endSound;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasLoadedEndScene && collision.gameObject.tag == "EndGame")
        {
            EndNoise(transform.position);

            // Set the flag to true to indicate that the scene has been loaded
            hasLoadedEndScene = true;

            // Load the EndScene only once
            SceneManager.LoadScene("EndScene");
        }
    }

    private void EndNoise(Vector3 soundPosition)
    {
        if (endSound != null)
        {
            AudioSource.PlayClipAtPoint(endSound, soundPosition);
        }
    }
}
