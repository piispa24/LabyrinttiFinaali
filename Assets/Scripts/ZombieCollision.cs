using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieCollision : MonoBehaviour
{
    //public GameObject loppuPaneeli;
    //public GameObject pistePaneeli;

    public AudioClip endSound;  // Audio kun zombi osuu
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EndGame") // If bullet collision target tag is "enemy", destroy the gameObject and the enemy
        {
            EndNoise(transform.position);
            SceneManager.LoadScene("EndScene");
            EndNoise(transform.position);
            //GameEnd();

        }
    }

    private void EndNoise(Vector3 soundPosition)
    {
        //‰‰ni kun zombi osuu
        if (endSound != null)
        {
            AudioSource.PlayClipAtPoint(endSound, soundPosition);
        }
    }

    //public void GameEnd()
    //{
    //    loppuPaneeli.GetComponent<Animator>().Play("EndAnimo");
    //    loppuPaneeli.SetActive(true);
    //    //pistePaneeli.GetComponent<Animator>().Play("PointAnim");
    //    //pistePaneeli.SetActive(true);
    //}
}
