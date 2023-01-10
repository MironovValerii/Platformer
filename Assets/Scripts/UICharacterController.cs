using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterController : MonoBehaviour
{
    [SerializeField] private PressedButton left;
    [SerializeField] private PressedButton right;
    [SerializeField] private Button fire;
    [SerializeField] private Button jamp;

    public PressedButton Left
        { get { return left; } }
    public PressedButton Right
        { get { return right; } }
    public Button Fire
        { get { return fire; } }
    public Button Jamp
        { get { return jamp; } }

    void Start()
    {
        Pleer.Instance.InitUIController(this);
    }
}
