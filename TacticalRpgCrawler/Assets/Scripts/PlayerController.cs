using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : EntityController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Move(new Vector2(1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(new Vector2(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Move(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(new Vector2(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Move(Vector2 movement)
    {
        position += movement;

        Play();
    }

    void Attack()
    {
        for(int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                //attack
            }
        }
    }

    public override void TakeDamage()
    {
        SceneManager.LoadScene(0);
    }

    public override void Play()
    {
        TurnManager.Instance.EndPlayerTurn();
    }
}
