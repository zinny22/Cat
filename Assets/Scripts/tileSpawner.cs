using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;      //맵에 배치되는 타일 프리	
    [SerializeField]
    private Transform currentTile;      //현재 타일 (새로운 타일 생성시 위치 설정에 사)
    [SerializeField]
    private int spawnTileCountAtStart = 200;       //게임 시작시 생성되는 타일의 수 

    private void Awake()
    {
        for (int i = 0; i < spawnTileCountAtStart; ++i)     //createTile반복하기 200까지
        {
            CreateTile();
        }
    }

    private void CreateTile()
    {
        GameObject clone = Instantiate(tilePrefab);     //clone은 게임을 실행하는 도중에 게임오브젝트(tilePrefab)를 생성(Instantiate)
        clone.transform.SetParent(transform);

        SpawnTile(clone.transform);
    }

    private void SpawnTile(Transform tile)
    {
        tile.gameObject.SetActive(true);

        int index = Random.Range(0, 2); //0~1사이의 값을 렌덤하게 index에 넣어준다 
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;     //index가 0이면 오른쪽으로 아니면 앞으로 위치하게 한다
        tile.position = currentTile.position + addPosition;         // 현재 타일 위치에 더한 위치값을 더한 값

        currentTile = tile;     //마지막에 생성된 타일은 다시 현재의 타일이 된다
    }
}
