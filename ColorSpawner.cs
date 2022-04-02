using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Colors
{
    public string Name;
    public GameObject Prefab;
    [Range (0f,100f)] public float Chance = 100f;
    [HideInInspector] public double weight;
}

public class ColorSpawner : MonoBehaviour
{

    private double _accumulatedWeights;
    private System.Random _rand = new System.Random();
    [SerializeField] private Colors[] coloredCricle;
    [SerializeField] private int spawnCount;

    private void Start() 
    {
        EventManager.RandomColorSpawned += CalculateWeight;
        EventManager.RandomColorSpawned += SpawnRandomColor;
    }

    public void SelectRandomColor(Vector2 position){
        Colors randomColor = coloredCricle[GetRandomColorIndex()];
        Instantiate(randomColor.Prefab,position,Quaternion.identity,transform);
    }

      public void SpawnRandomColor (){
        for (int i = 0; i < spawnCount; i++)
        {
            SelectRandomColor(new Vector2 (Random.Range(-2.5f , 2.5f) ,Random.Range(-3.5f , 3.5f) ) );
        }
    }

    private int GetRandomColorIndex(){
        double r = _rand.NextDouble () * _accumulatedWeights;
        for (int i = 0; i < coloredCricle.Length; i++)
        {
            if(coloredCricle[i].weight >= r)
            return i ;
        }
        return 0 ;
    }

    private void CalculateWeight(){
        _accumulatedWeights = 0f;
        foreach (Colors color in coloredCricle){
            _accumulatedWeights += color.Chance;
            color.weight = _accumulatedWeights;
        }
    }

}
