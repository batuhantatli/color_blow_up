using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    private float nextFire;
    [SerializeField] private float _fireRate;

    private void OnEnable() {
        EventManager.OnPressedColor += CastRay;
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin , ray.direction, Mathf.Infinity);
        if(hit == false)
        {
            return;
        }
        else if(hit.transform.gameObject.CompareTag("color"))
        {
            if(hit.transform.gameObject.GetComponent<ClickableColor>() == null)
            {
                hit.transform.gameObject.AddComponent<ClickableColor>();
            }
            

                ColorSizeChanger(hit.transform.gameObject);
            hit.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        
    }
    private void ColorSizeChanger(GameObject color)
    {
        if(Time.time >nextFire){
            nextFire = Time.time + _fireRate;
            color.transform.localScale = new Vector2 (color.transform.localScale.x+_fireRate,color.transform.localScale.y + _fireRate);
        }
    }
    private void OnDisable() {
        EventManager.OnPressedColor -= CastRay;
    }
}
