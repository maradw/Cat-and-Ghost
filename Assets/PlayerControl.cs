using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private Rigidbody2D myRBD;
    private float _vertical;
    [SerializeField] private float velocityModifier = 5f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void OnMovement(InputAction.CallbackContext move)
    {

        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;
    }
    void Update()
    {

    }
    public void FixedUpdate()
    {
        myRBD.velocity = new Vector2(_horizontal * velocityModifier, _vertical * velocityModifier);
    }
}
