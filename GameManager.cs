using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start() 
    {
        EventManager.Instance.SpawnRandomColor();
    }
    private void Update() 
    {
        if(Input.GetMouseButton(0))
        {
            EventManager.Instance.ClickColor();
        }

        else if(Input.GetMouseButtonUp(0))
        {
            EventManager.Instance.PopColor();
        }
    }

}
