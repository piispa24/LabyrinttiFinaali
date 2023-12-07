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
        Points();
    }

    public void Points()
    {
        
            // hakee pisteet s‰keist‰ ja tapoista
            int totalPoints = ColliderCheck.points + BulletCollision.kill;

            // N‰ytt‰‰ pisteet lopussa
            SacksText.text = "Sacks: " + ColliderCheck.points.ToString();
            ZombieText.text = "Zombie: " + BulletCollision.kill.ToString(); 
            totalPointsText.text = "Total: " + totalPoints.ToString();
     }
       
 }







