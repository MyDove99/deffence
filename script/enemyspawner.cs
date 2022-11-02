using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
   // [SerializeField]
    //private GameObject enemyprefab; //�� ������
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    //[SerializeField]
    //private float spawnTime; //�� ���� �ֱ�
    [SerializeField]
    private Transform[] waypoints; //���� ���������� �̵� ���
    private List<enemy> enemylist;// ���� �ʿ� �����ϴ� ��� ���� ����
    private Wave currentWave; //���� ���̺� ����
    private int currentEnemyCount; //���� ���̺꿡 �����ִ� �� ����(���̺� ���۽� max�� ����, �� ����� -1)

    public List<enemy> enemyList => enemylist;
    //���� ������ ������ enemyspawner���� �ϱ� ������ set�� �ʿ� ����.

    public int CurrentEnemyCount => currentEnemyCount;
    public int MaxEnemyCount => currentWave.maxEnemyCount;
    public int spawnEnemyCount = 0; //���� ���̺꿡�� ������ �� ����
    public int aliveEnemy = 0;

    private void Awake()
    {
        enemylist = new List<enemy>();
        //�� ����Ʈ �޸� �Ҵ�
        //StartCoroutine("SpawnEnemy");
        //�� ���� �Լ� ȣ��
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave; //�Ű������� �޾ƿ� ���̺� ���� ����
        spawnEnemyCount = 0;
        StartCoroutine("SpawnEnemy"); //���� ���̺� ����
        //currentEnemyCount = currentWave.maxEnemyCount;
    }

    private IEnumerator SpawnEnemy()
    {
        while (spawnEnemyCount < currentWave.maxEnemyCount)
        {
            //GameObject clone = Instantiate(enemyprefab); //��������Ʈ ����
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            //���̺꿡 �����ϴ� ���� ������ ���� ������ �� ������ ���� �����ϵ��� �����ϰ�, �� ������Ʈ ����
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            enemy enemy = clone.GetComponent<enemy>(); // ��� ������ ���� enemy ������Ʈ

            enemy.Setup(this,waypoints); //waypoint ������ �Ű������� setup ȣ��
            enemylist.Add(enemy); //����Ʈ�� ��� ������ �� ���� ����

            SpawnEnemyHPSlider(clone); //�� ü���� ��Ÿ���� slider UI ���� �� ����

            spawnEnemyCount++; //���� ���̺꿡�� ������ ���� ���� +1
            aliveEnemy++;

            yield return new WaitForSeconds(currentWave.spawnTime); 
            //�� ���̺긶�� spawntime�� �ٸ� �� �ֱ� ������ ���� ���̺�(currentWave)�� spawntime ���
            //spawntime �ð����� ���
        }
    }

    public void DestroyEnemy(enemy enemy)
    {
        currentEnemyCount--;
        aliveEnemy--;
        enemylist.Remove(enemy); //����Ʈ���� ����ϴ� �� ���� ����
        Destroy(enemy.gameObject); // �� ������Ʈ ����
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        //�� ü���� ��Ÿ���� slider ui ����
        sliderClone.transform.SetParent(canvasTransform);
        //slider ui ������Ʈ�� parent(canvas)�� �ڽ����� ����
        //ui�� canvas�� �ڽ��̾�� ����
        sliderClone.transform.localScale = Vector3.one;
        //���� �������� �ٲ� ũ�⸦ �ٽ� 1,1,1�� ����
        sliderClone.GetComponent<SilderPositionAutoSetter>().Setup(enemy.transform);
        //slider ui�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<enemyhpviewer>().Setup(enemy.GetComponent<enemyhp01>());
        //slider ui�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
