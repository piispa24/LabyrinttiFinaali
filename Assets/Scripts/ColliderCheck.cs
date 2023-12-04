using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public AudioClip collectibleSound;  // Audio kun ker‰t‰‰n sakki
    public static int points;
    public TMP_Text allpoints;
    // Start is called before the first frame update

    void Awake()
    {
        points = 0;
        UpdatePointsText();
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            other.gameObject.SetActive(false);
            CollectibleSoundPick(transform.position);
            AddPoint();
            UpdatePointsText();
        }
        
    }

    private void CollectibleSoundPick(Vector3 soundPosition)
    {
        //‰‰ni kun on ker‰tty s‰kki
        if (collectibleSound != null)
        {
            AudioSource.PlayClipAtPoint(collectibleSound, soundPosition);
        }
    }

    //S‰kkilaskuri
    public void AddPoint()
    {
        points += 1;
    }

    public void UpdatePointsText()
    {
        if (allpoints != null)
        {
            allpoints.text = "Sack: " + points.ToString();
        }
    }


}
