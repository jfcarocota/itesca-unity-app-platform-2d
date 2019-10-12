using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField]
    MoveBoton left;
    [SerializeField]
    MoveBoton right;

    public MoveBoton Left { get => left; }
    public MoveBoton Right { get => right; }
}
