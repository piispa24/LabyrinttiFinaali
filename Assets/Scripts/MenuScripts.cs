using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
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
