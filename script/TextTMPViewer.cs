using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerGold;
    [SerializeField]
    private TextMeshProUGUI textWave;
    [SerializeField]
    private TextMeshProUGUI textEnemyCount;
    [SerializeField]
    private gold playerGold;
    [SerializeField]
    private WaveSystem waveSystem;
    [SerializeField]
    private enemyspawner enemyspawner;
    // Update is called once per frame
    private void Update()
    {
        textPlayerGold.text = playerGold.Currentgold.ToString();
        textWave.text = "Round "+waveSystem.CurrentWave + " / " + waveSystem.MaxWave;
        textEnemyCount.text = enemyspawner.aliveEnemy + " / 60";
    }
}
