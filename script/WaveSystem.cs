using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves; //���� ���������� ��� ���̺� ����
    [SerializeField]
    private enemyspawner enemyspawner;
    private int currentWaveIndex = -1; //���� ���̺� �ε���
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
            currentWaveIndex++;//�ε��� ������ -1�̱� ������ ���̺� �ε��� ������ ���� ��
            enemyspawner.StartWave(waves[currentWaveIndex]);
            //���� ���̺� ���� ����
            stage += 1;
            start = false;
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float spawnTime; //���� ���̺� �� ���� �ֱ�
    public int maxEnemyCount; //���� ���̺� �� ���� ����
    public GameObject[] enemyPrefabs; //���� ���̺� �� ���� ����
}
