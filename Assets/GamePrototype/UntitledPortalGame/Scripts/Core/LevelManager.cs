using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public List<Entity> entities;
    public void AddEntity(Entity entity)
    {
        if (entities == null)
            entities = new List<Entity>();
        entities.Add(entity);
    }
    private void Update()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isActivate)
            {
                entities[i].OnActivate();
            }
        }
    }
}