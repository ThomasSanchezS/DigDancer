using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int level;

    private static LevelManager instance;

    private BlocksSpawner  bS= new BlocksSpawner();

    public static LevelManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        bS= GetComponent<BlocksSpawner>();
        level= 0;
    }

}
