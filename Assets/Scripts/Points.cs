using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if (gameObject.scene.name == "EndScene")
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        // Call the function to update points
        ColliderCheck colliderCheck = FindObjectOfType<ColliderCheck>();
        //if (colliderCheck != null)
        //{
            colliderCheck.UpdatePointsText();
        //}

        // Make this GameObject persist between scenes
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
