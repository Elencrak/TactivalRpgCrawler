using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[,] map;
    public Transform parent;
    public EntityController player;

    public GameObject wall;
    public GameObject floor;
    public GameObject AI;
    public GameObject playerPrefab;
    public int nbIA;

    public int width;
    public int height;

    private int indexIA;

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {  
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            Bite();
        }
        else
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Bite () {
        map = new GameObject[width, height];

		for (int i = 0; i < width; i ++ )
        {
            for(int j = 0; j < height; j++)
            {
                GameObject temp;       
                if(i == 0 && j  == 0)
                {
                    temp = Instantiate(floor, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    temp.transform.parent = parent;
                    temp.GetComponent<Tile>().position2D = new Vector2(i, j);
                    temp.GetComponent<Tile>().blocked = false;

                    GameObject playerprf = Instantiate(playerPrefab, new Vector3(i, 1, j), Quaternion.identity) as GameObject;
                    player = playerprf.GetComponent<PlayerController>();
                }
                else
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        temp = Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                        temp.transform.parent = parent;
                        temp.GetComponent<Tile>().position2D = new Vector2(i, j);
                        temp.GetComponent<Tile>().blocked = true;
                    }
                    else
                    {
                        temp = Instantiate(floor, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                        temp.transform.parent = parent;
                        temp.GetComponent<Tile>().position2D = new Vector2(i, j);
                        temp.GetComponent<Tile>().blocked = false;

                        int AIorNot = Random.Range(0,2);
                        int popOrNotPop = Random.Range(0, 4);
                        if (popOrNotPop == 1)
                        {
                            if(nbIA > indexIA)
                            {   
                                GameObject tempAI;
                                tempAI = Instantiate(AI, new Vector3(i, 0.5f, j), Quaternion.identity) as GameObject;
                                indexIA++;
                                tempAI.GetComponent<EnemyController>().position = new Vector2(i, j);
                            }
                        }
                    }
                }

                map[i, j] = temp;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
