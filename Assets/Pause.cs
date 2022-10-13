using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
        public void StartPause()
    {
   
        Time.timeScale = 0f;
    }
    public void StartResume()
    {
        Time.timeScale = 1f;
    }
    
}
