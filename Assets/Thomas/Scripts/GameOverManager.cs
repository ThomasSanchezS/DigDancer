using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Reset(){
        SceneManager.LoadScene("V2 Mauricio");
    }

    public void Exit(){
        SceneManager.LoadScene("Menu");
    }
}
