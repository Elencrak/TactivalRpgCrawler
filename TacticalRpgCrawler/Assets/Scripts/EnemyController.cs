using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityController {

    public List<Tile> possibleTiles = new List<Tile>();
    private List<Tile> tiles = new List<Tile>();
	// Use this for initialization
	void Start () {
        possibleTiles = new List<Tile>();
        tiles = new List<Tile>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Play()
    {
        base.Play();
        
        possibleTiles.Add(GameManager.Instance.map[Mathf.Clamp((int)position.x + 1, 0, GameManager.Instance.width-1), (int)position.y].GetComponent<Tile>());
        possibleTiles.Add(GameManager.Instance.map[Mathf.Clamp((int)position.x-1,0, GameManager.Instance.width - 1), (int)position.y].GetComponent<Tile>());
        possibleTiles.Add(GameManager.Instance.map[(int)position.x, Mathf.Clamp((int)position.y + 1, 0, GameManager.Instance.height - 1)].GetComponent<Tile>());
        possibleTiles.Add(GameManager.Instance.map[(int)position.x, Mathf.Clamp((int)position.y - 1, 0, GameManager.Instance.height - 1)].GetComponent<Tile>());

        Debug.Log("I play " + id);

        EntityController playerFind = null;
        foreach(Tile p in possibleTiles)
        {
            if (p.entity != null && p.entity.GetType() == typeof(PlayerController))
                playerFind = p.entity;
        }
        if(playerFind)
        {
           //playerFind.
        }
        else
        {
            foreach (Tile t in possibleTiles)
            {
                if(!t.blocked)
                {
                    tiles.Add(t);
                }
            }

            int index = Random.Range(0, tiles.Count);

            if(tiles.Count >= 0)
            {
                transform.position = new Vector3(tiles[index].position2D.x, 0, tiles[index].position2D.y);
            } 
        }
    }
}
