using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public AudioClip destroySound;
    public static int kill; 
    public TMP_Text allKills;

    void Awake()
    {
        if (kill == 0)
        {
            // Nollaa ainoastaan jos killcount on 0
            kill = 0;
        }

        UpdateKillsText();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            DestroyNoise(transform.position);
            AddKill();
            UpdateKillsText();
        }

        if (collision.gameObject.tag == "wall")
        {
            gameObject.SetActive(false);
        }
    }
    //laskuri tapoille
    public void AddKill()
    {
        kill += 1;
        Debug.Log("Kill count: " + kill.ToString());
    }

    public void UpdateKillsText()
    {
        if (allKills != null)
        {
            allKills.text = "Zombie: " + kill.ToString();
        }
    }

    //Tuhoamis ‰‰ni
    private void DestroyNoise(Vector3 soundPosition)
    {
        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, soundPosition);
        }
    }
}
