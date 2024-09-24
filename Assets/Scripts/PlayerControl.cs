using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerControl : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private Rigidbody2D myRBD;
    private float _vertical;
    [SerializeField] private float velocityModifier = 5f;

    private GameObject _ghostPrefab;
    public static event Action<int> OnCollisionGhost;
    
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
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Ghost")
        {
            OnCollisionGhost?.Invoke(5);
        }
    }
    
    void SetGhost()
    {
        _ghostPrefab.GetComponent<Enemy>().SetCat(this.gameObject);
    }

    public void FixedUpdate()
    {
        myRBD.velocity = new Vector2(_horizontal * velocityModifier, _vertical * velocityModifier);
    }
}
