using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
   // [SerializeField]
    //private GameObject enemyprefab; //적 프리팹
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    //[SerializeField]
    //private float spawnTime; //적 생성 주기
    [SerializeField]
    private Transform[] waypoints; //현재 스테이지의 이동 경로
    private List<enemy> enemylist;// 현재 맵에 존재하는 모든 적의 정보
    private Wave currentWave; //현재 웨이브 정보
    private int currentEnemyCount; //현재 웨이브에 남아있는 적 숫자(웨이브 시작시 max로 설정, 적 사망시 -1)

    public List<enemy> enemyList => enemylist;
    //적의 생성과 삭제는 enemyspawner에서 하기 때문에 set은 필요 없다.

    public int CurrentEnemyCount => currentEnemyCount;
    public int MaxEnemyCount => currentWave.maxEnemyCount;
    public int spawnEnemyCount = 0; //현재 웨이브에서 생성한 적 숫자
    public int aliveEnemy = 0;

    private void Awake()
    {
        enemylist = new List<enemy>();
        //적 리스트 메모리 할당
        //StartCoroutine("SpawnEnemy");
        //적 생성 함수 호출
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave; //매개변수로 받아온 웨이브 정보 저장
        spawnEnemyCount = 0;
        StartCoroutine("SpawnEnemy"); //현재 웨이브 시작
        //currentEnemyCount = currentWave.maxEnemyCount;
    }

    private IEnumerator SpawnEnemy()
    {
        while (spawnEnemyCount < currentWave.maxEnemyCount)
        {
            //GameObject clone = Instantiate(enemyprefab); //적오브젝트 생성
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            //웨이브에 등장하는 적의 종류가 여러 종류일 때 임의의 적이 등장하도록 설정하고, 적 오브젝트 생성
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            enemy enemy = clone.GetComponent<enemy>(); // 방금 생성된 적의 enemy 컴포넌트

            enemy.Setup(this,waypoints); //waypoint 정보를 매개변수로 setup 호출
            enemylist.Add(enemy); //리스트에 방금 생성된 적 정보 저장

            SpawnEnemyHPSlider(clone); //적 체력을 나타내는 slider UI 생성 및 설정

            spawnEnemyCount++; //현재 웨이브에서 생성한 적의 숫자 +1
            aliveEnemy++;

            yield return new WaitForSeconds(currentWave.spawnTime); 
            //각 웨이브마다 spawntime이 다를 수 있기 때문에 현재 웨이브(currentWave)의 spawntime 사용
            //spawntime 시간동안 대기
        }
    }

    public void DestroyEnemy(enemy enemy)
    {
        currentEnemyCount--;
        aliveEnemy--;
        enemylist.Remove(enemy); //리스트에서 사망하는 적 정보 삭제
        Destroy(enemy.gameObject); // 적 오브젝트 삭제
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        //적 체력을 나타내는 slider ui 생성
        sliderClone.transform.SetParent(canvasTransform);
        //slider ui 오브젝트를 parent(canvas)의 자식으로 설정
        //ui는 canvas의 자식이어야 보임
        sliderClone.transform.localScale = Vector3.one;
        //계층 설정으로 바뀐 크기를 다시 1,1,1로 설정
        sliderClone.GetComponent<SilderPositionAutoSetter>().Setup(enemy.transform);
        //slider ui가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<enemyhpviewer>().Setup(enemy.GetComponent<enemyhp01>());
        //slider ui에 자신의 체력 정보를 표시하도록 설정
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
