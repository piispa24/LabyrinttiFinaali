using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public TMP_Text SacksText;
    public TMP_Text ZombieText;
    public TMP_Text totalPointsText;

    void Start()
    {
        // Call the Points method when the scene starts
        Points();
    }

    public void Points()
    {
        
            // Access the points variable through an instance of ColliderCheck
            int totalPoints = ColliderCheck.points + BulletCollision.kill;

            // Display the points
            SacksText.text = "Sacks: " + ColliderCheck.points.ToString();
            ZombieText.text = "Zombie: " + BulletCollision.kill.ToString(); 
            totalPointsText.text = "Total: " + totalPoints.ToString();
     }
       
 }







