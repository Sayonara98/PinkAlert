using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pinkCirclePrf;
    [SerializeField] private Text levelText;
    [SerializeField] private Text timerToNextLevelText;

    [SerializeField] private float spawnCooldown = 1f;
    [SerializeField] private float nextWaveSpawnCooldown = 10f;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    //private List<GameObject> 

    private float currentCount = 0f;
    private int maxWave = 10;
    private int level = 1;
    private float countdown = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        currentCount = 0f;
        countdown = nextWaveSpawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCount >=  0f)
        {
            currentCount -= Time.deltaTime;
        }
        else
        {
            currentCount = spawnCooldown;
            Spawn();
        }

        if (countdown <= 0)
        {
            countdown = nextWaveSpawnCooldown;
            level++;
            spawnCooldown -= 0.025f * level;
            // minimum cooldown
            if (spawnCooldown <= 0.35f)
            {
                spawnCooldown = 0.35f;
            }
            if (level > 10)
            {
                FindObjectOfType<GameManager>().WinGame();
            }
        }

        if ( level <= 10)
        {
            levelText.text = "Level: " + level.ToString() + "/" + maxWave.ToString();
            timerToNextLevelText.text = "Next wave in: " + Mathf.RoundToInt(countdown).ToString();
            countdown -= Time.deltaTime;
        }
    }

    public void Spawn()
    {
        float randomPosX = Random.Range(minX, maxX);
        float randomPosY = Random.Range(minY, maxY);

        Vector3 randomPos = new Vector3(randomPosX, randomPosY);

        Instantiate(pinkCirclePrf, randomPos, Quaternion.identity);
    }
}
