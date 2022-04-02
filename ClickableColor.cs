using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableColor : MonoBehaviour
{
    [SerializeField] private List<GameObject> _poppableColor = new List<GameObject>();

    private void Start() 
    {
        EventManager.OnDropColor += PoppableColor;
    }

    private void PoppableColor(){
        Destroy(gameObject);
        for (int i = 0; i < _poppableColor.Count; i++)
        {
            Destroy(_poppableColor[i]);

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("color"))
        {
            _poppableColor.Add(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("color"))
        {
            if(_poppableColor.Contains(other.gameObject))
                return;
            _poppableColor.Add(other.gameObject);
        }
    }
    private void OnDestroy() {
        EventManager.OnDropColor -= PoppableColor;
    }
}
