using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Transform currentTile;
    [SerializeField]
    private int spawnTileCountAtStart = 100;

    private void Awake()
    {
        for (int i = 0; i < spawnTileCountAtStart; ++i)
        {
            CreateTile();
        }
    }

    private void CreateTile()
    {
        GameObject clone = Instantiate(tilePrefab);
        clone.transform.SetParent(transform);

        SpawnTile(clone.transform);
    }

    private void SpawnTile(Transform tile)
    {
        tile.gameObject.SetActive(true);

        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = currentTile.position + addPosition;

        //마지막에 설정한 타일을 커런트 타일로 다시 바꿔주
        currentTile = tile;
    }
}
