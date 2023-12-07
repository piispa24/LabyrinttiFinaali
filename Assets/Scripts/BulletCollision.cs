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
        if (collision.gameObject.tag == "enemy")  //hakee tˆrm‰yksen tagiin
        {
            collision.gameObject.SetActive(false);  //asettaa bulletin piiloonm
            gameObject.SetActive(false);  //asettaa vihollisen piiloon
            DestroyNoise(transform.position);  //‰‰ni tuhoamisesta
            AddKill();  //lis‰‰ pisteen
            UpdateKillsText(); //p‰ivitt‰‰ pisteen
        }

        if (collision.gameObject.tag == "wall")  //piilottaa bulletin kun osuu sein‰‰n
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
    
    //p‰ivitt‰‰ ja printtaa tappolaskurin
    public void UpdateKillsText()
    {
        if (allKills != null)
        {
            allKills.text = "Zombies: " + kill.ToString();
        }
    }

    public void ResetKills()
    {
        kill = 0;
        UpdateKillsText();
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
