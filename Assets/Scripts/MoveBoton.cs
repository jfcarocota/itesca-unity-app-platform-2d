using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBoton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Direction{left, right};
    [SerializeField]
    Direction direction;

    float inputX = 0f;

    public float InputX {get => inputX;}

    public void OnPointerDown(PointerEventData eventData)
    {
        switch(direction)
        {
            case Direction.right:
                inputX = 1;
            break;
            case Direction.left:
                inputX = -1;
            break;
        }
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        inputX = 0;
    }
}
