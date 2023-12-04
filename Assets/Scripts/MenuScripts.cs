using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : BulletCollision
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtnClicked()
    {
        SceneManager.LoadScene("SampleScene");
        ResetKills();
    }

    public void InfoBtnClicked()
    {
        SceneManager.LoadScene("InfoScene");
    }

    public void MenuBtnClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
