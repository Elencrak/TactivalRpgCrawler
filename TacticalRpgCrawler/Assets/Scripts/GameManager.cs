using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[,] map;
    public Transform parent;

    public GameObject wall;
    public GameObject floor;
    public GameObject AI;

    public int width;
    public int height;

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
        }
        else
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
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
                        if(AIorNot == 1)
                        {
                            GameObject tempAI;
                            tempAI = Instantiate(AI, new Vector3(i, 0.5f, j), Quaternion.identity) as GameObject;
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
