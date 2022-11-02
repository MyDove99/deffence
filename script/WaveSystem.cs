using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves; //현재 스테이지의 모든 웨이브 정도
    [SerializeField]
    private enemyspawner enemyspawner;
    private int currentWaveIndex = -1; //현재 웨이브 인덱스
    [SerializeField]
    private timer timer;

    public bool start = false;
    public int stage = 0;
    public int CurrentWave => currentWaveIndex + 1;
    public int MaxWave => waves.Length;

    void Update()
    {
        int time = (int)timer.time;
        if(time == 9)
        {
            start = true;
        }
        else if (time == 9+(30*stage) )
        {
            start = true;
        }
        else if (start == true)
        {
            currentWaveIndex++;//인덱스 시작이 -1이기 때문에 웨이브 인덱스 증가를 먼저 함
            enemyspawner.StartWave(waves[currentWaveIndex]);
            //현재 웨이브 정보 제공
            stage += 1;
            start = false;
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float spawnTime; //현재 웨이브 적 생성 주기
    public int maxEnemyCount; //현재 웨이브 적 등장 숫자
    public GameObject[] enemyPrefabs; //현재 웨이브 적 등장 종류
}
