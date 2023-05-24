using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BlocksSpawner : MonoBehaviour
{
    [SerializeField]
    private List<BlocksPool> ABlocks = new List<BlocksPool>();
    [SerializeField]
    private List<BlocksPool> SBlocks = new List<BlocksPool>();
    [SerializeField]
    private List<BlocksPool> DBlocks = new List<BlocksPool>();

    void Start()
    {
        Spawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawn();
        }
    }

    //Spawn the groups of platforms
    private void Spawn()
    {
        int groupType = Random.Range(1, 4);

        //TEST
        Debug.Log("Random number " + groupType);

        switch (groupType)
        {
            case 1:
                GameObject GroupOfPlatforms1 = ABlocks[Random.Range(0, ABlocks.Count)].GetPooledObject();
                if (GroupOfPlatforms1 != null)
                {
                    GroupOfPlatforms1.transform.position = transform.position;
                    GroupOfPlatforms1.SetActive(true);
                }
                break;

            case 2:
                GameObject GroupOfPlatforms2 = SBlocks[Random.Range(0, SBlocks.Count)].GetPooledObject();
                if (GroupOfPlatforms2 != null)
                {
                    GroupOfPlatforms2.transform.position = transform.position;
                    GroupOfPlatforms2.SetActive(true);
                }
                break;

            case 3:
                GameObject GroupOfPlatforms3 = SBlocks[Random.Range(0, SBlocks.Count)].GetPooledObject();
                if (GroupOfPlatforms3 != null)
                {
                    GroupOfPlatforms3.transform.position = transform.position;
                    GroupOfPlatforms3.SetActive(true);
                }
                break;

            default:
                break;
        }

        Move();

    }

    //to move after spawn
    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 20);
    }
}
