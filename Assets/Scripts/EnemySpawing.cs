using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawing : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int number;
    public float spawnRadius;
    public bool spawnOnStart = true;
    Vector3 result;
   public List<GameObject> enemies=new List<GameObject>();
    public GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnOnStart)
        {
            CreateAllEnemies();
            
        }

    }
    private void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].gameObject.activeInHierarchy)
            {
                Debug.Log("Enemy");
                enemies[i].gameObject.SetActive(true);
            }
        }
    }
    private void CreateAllEnemies()
    {
        for (int i = 0; i < number; i++)
        {
            print("Transform.position = " + transform.position);
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;
            print("Random point = " + randomPoint);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                result = hit.position;

                //print("Result=" +result);
            // temp =   Instantiate(enemyPrefabs[0], result, Quaternion.identity);
               // temp.SetActive(false);
               // enemies.Add(temp);
                
            }
            else
                i--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawnOnStart && other.gameObject.tag == "Player")
        {
            CreateAllEnemies();
        }
    }

   

  
}