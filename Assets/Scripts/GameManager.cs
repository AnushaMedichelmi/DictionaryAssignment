using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private int maxNumLives = 3;
    private int lives;
    private int score;
    private Camera mainCamera;
    public float cameraHalfWidth;
    public float cameraHalfHeight;
    public GameObject temp;
    public float spawnRadius;
    Vector3 result;
    public GameObject[] enemyPrefabs;

    #endregion

    #region SINGLETON

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    instance = container.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    #region MONOBEHAVIOUR METHODS
    void Start()
    {
        mainCamera = Camera.main;
        lives = maxNumLives;
        StartCoroutine(SpawnAsteroids());
    }
    #endregion

    #region PUBLIC METHODS
    // Lose a life.
    public void LoseLife()
    {
        lives--;

        if (lives == 0)
            Restart();
    }

    // Gain points.
    public void GainPoints(int points)
    {
        score += points;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    // Spawn asteroids every few seconds.
    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(2f, 8f));
            SpawnAsteroid();
        }
    }

    // Spawn an asteroid off the screen.
    private void SpawnAsteroid()
    {
        GameObject prefab = PoolManager.Instance.Spawn("Lurker");
       /* for (int i = 0; i < 10; i++)
        {
            print("Transform.position = " + transform.position);
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;
            print("Random point = " + randomPoint);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                result = hit.position;
                prefab.transform.position = result;
                //print("Result=" +result);
                // temp = Instantiate(enemyPrefabs[0], result, Quaternion.identity);
                //temp.SetActive(false);
                //enemies.Add(temp);
            }

            else
            {
                i--;
            }*/
        }


        // Update is called once per frame
        void Update()
        {

        }
    }

