using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gamemanager : MonoBehaviour
{

    private static Gamemanager instance;

    [SerializeField] private EnemyManager enemies_controller;
    [SerializeField] private GameObject play_button;
    [SerializeField] private GameObject winningText, losingText;
    [SerializeField] private int[] enemyCountsPerLevel;
    [SerializeField] private AudioSource gameOverAudio;
    private List<GameObject> hearts;
    [SerializeField] private GameObject heartPrefab;
    private int lives = 3;
    private int numOfEnemies;
    private int level = 0;
    private int numOfLevels = 1;
    

    public static Gamemanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Gamemanager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("Gamemanager");
                    instance = go.AddComponent<Gamemanager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        hearts = new List<GameObject>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensures that the GameManager persists across scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void clicked_play()
    {
        //reset enemies titles and life
        numOfEnemies = enemyCountsPerLevel[level];
        play_button.SetActive(false);
        winningText.SetActive(false);
        losingText.SetActive(false);

        enemies_controller.SpawnEnemiesForLevel(numOfEnemies);
        refillHearts();
    }

    public void destroyEnemy()
    {
        numOfEnemies--;
        if (numOfEnemies == 0)
        {
            level++;
            if (level >= numOfLevels)
            {
                winGame();
            }
            else
            {
                play_button.SetActive(true);
            }



        }
    }

    private void winGame()
    {
        gameOverAudio.Play();
        level = 0;
        winningText.SetActive(true);
        play_button.SetActive(true);
        refillHearts();
    }

    private void refillHearts()
    {
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }

        for (int i = 0; i < 3; i++)
        {
            Vector3 position = new Vector3(9+i, 5.8f, 0);

            hearts.Add(Instantiate(heartPrefab,position,Quaternion.identity));
            
        }

        lives = 3;
    }

    public void loseLife()
    {
        lives--;

        // Check if there's a heart to destroy
        if (lives >= 0 && lives < hearts.Count)
        {
            Destroy(hearts[lives]);
            hearts.RemoveAt(lives); // Remove the destroyed heart from the list
        }

        if (lives == 0)
        {
            loseGame();
        }

    }

    private void loseGame()
    {
        enemies_controller.DestroyAllEnemies();
        play_button.SetActive(true);
        losingText.SetActive(true);
        gameOverAudio.Play();

    }
}
   
