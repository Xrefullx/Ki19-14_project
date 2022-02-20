using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{ 
    [SerializeField]
    private List<GameScript> gameScripts;
    [SerializeField]
    private bool isStartTest; // запускаем метод Use у всех объектов в списке gameScripts
    
    private void Start()
    { 
        GameScript[] finedScripts = FindObjectsOfType(typeof(GameScript)) as GameScript[];
        gameScripts = finedScripts.ToList();
        if(isStartTest)
            UseAllObject();
    }

    private void UseAllObject()
    {
        foreach (var item in gameScripts)
        {
            item.Use();
        }
    }
}

