using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Reset(){
        
    }

    public void Exit(){
        SceneManager.LoadScene("Menu");
    }
}
