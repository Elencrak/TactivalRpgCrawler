using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityController {

    public List<Tile> possibleTiles;
    private List<Tile> tiles;
	// Use this for initialization
	void Start () {	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Play()
    {
        base.Play();
        
        possibleTiles.Add(GameManager.Instance.map[(int)position.x+1, (int)position.y].GetComponent<Tile>());
        possibleTiles.Add(GameManager.Instance.map[(int)position.x-1, (int)position.y].GetComponent<Tile>());
        possibleTiles.Add(GameManager.Instance.map[(int)position.x, (int)position.y+1].GetComponent<Tile>());
        possibleTiles.Add(GameManager.Instance.map[(int)position.x, (int)position.y-1].GetComponent<Tile>());


        //possibleTiles.Where<Tile>((x) => {
        //    if (x.entity.GetType() == typeof(PlayerController))
        //    {
        //        return x;
        //    }
        //    return null;
        //});
        EntityController playerFind = null;
        foreach(Tile p in possibleTiles)
        {
            if (p.entity.GetType() == typeof(PlayerController))
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

            transform.position = new Vector3(tiles[index].position2D.x, 0, tiles[index].position2D.y);       
        }
    }
}
