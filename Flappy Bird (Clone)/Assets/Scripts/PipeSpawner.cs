using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float pipeSpawnTime = 1.5f;
    [SerializeField] private GameObject pipesPrefab;
    [SerializeField] private float height = 0.5f;

    public PlayerMovement player;

    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while(!player.isDead)
        {
            Instantiate(pipesPrefab, new Vector3(2.5f, Random.Range(-height, height), 0), Quaternion.identity);

            yield return new WaitForSeconds(pipeSpawnTime);
        }
    }
}
