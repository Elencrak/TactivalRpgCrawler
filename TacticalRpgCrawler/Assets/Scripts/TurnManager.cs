using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.Networking;

public class TurnManager : MonoBehaviour
{

    public static TurnManager instance = null;
    public static TurnManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        instance = this;
    }
    
    public bool gameFinished = false;

    public List<EnemyController> entities;
    
    int nbColorAffected = 0;
    
    void Start()
    {
        entities = new List<EnemyController>();

        EnemyController[] entitabs = FindObjectsOfType<EnemyController>();

        int id = 0;

        foreach (EnemyController eC in entitabs)
        {
            eC.id = id;
            entities.Add(eC);
            id++;
        }
    }
    
    public void Add(EnemyController eC)
    {
        eC.id = entities.Count;
        entities.Add(eC);
    }

    public void Remove(EnemyController eC)
    {
        entities.Remove(eC);
    }
    
    public void EndPlayerTurn()
    {
        foreach(EntityController entity in entities)
        {
            entity.Play();
        }
    }
}