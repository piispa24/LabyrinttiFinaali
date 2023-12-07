using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieCollision : MonoBehaviour
{
    private bool hasLoadedEndScene = false; //tarkistaa onko scene ladattu

    public AudioClip endSound;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasLoadedEndScene && collision.gameObject.tag == "EndGame") //tarkistaa onko scene ladattu ja tagiin torm‰tty
        {
            EndNoise(transform.position); //‰‰nite
            hasLoadedEndScene = true; // Asettaa latauksen todeksi
            SceneManager.LoadScene("EndScene"); // Lataa scene
        }
    }

    private void EndNoise(Vector3 soundPosition) //‰‰nite kun peli loppuu
    {
        if (endSound != null)
        {
            AudioSource.PlayClipAtPoint(endSound, soundPosition);
        }
    }
}
