using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _comRigidbody2D;
    //public GameObject _cat;
    private float speedMovement = 4;
    private Vector2 direction;
    public float timeEstimated = 0.5f; 

    private float time = 0f;
    private void Awake()
    {
    }
   
    void Update()
    {
       
    }

    void ChangeDirection()
    {
        // Generar un ángulo aleatorio
        float angulo = Random.Range(0f, 360f);
        direction = new Vector3(Mathf.Cos(angulo), 0, Mathf.Sin(angulo)).normalized; // Calcular la nueva dirección
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject); 
           //transform.position = Vector2.MoveTowards(this.transform.position, collision.transform.position, speedMovement * Time.deltaTime);

        }
    }
    public void SetCat(GameObject cat2)
    {
        //cat2 = _cat;

       // cat2 = _cat;
    }
    void FollowCharacter()
    {
       
    }
    private void FixedUpdate()
    {
        // Mueve el enemigo
        transform.Translate(direction * speedMovement * Time.deltaTime);

        // Incrementar el tiempo desde el último cambio de dirección
        time += Time.deltaTime;

        // Cambiar dirección si ha pasado el tiempo establecido
        if (time >= timeEstimated)
        {
            ChangeDirection();
            time = 0f; // Reiniciar el temporizador
        }
    }
    public void SetKilla(GameObject killaskz)
    {
        //_Killa = killaskz;
    }
}
