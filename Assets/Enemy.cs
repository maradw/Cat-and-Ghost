using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _comRigidbody2D;
   
    public float speedMovement;
    [SerializeField] private GameObject _Killa;
    [SerializeField] private GameManager GameManager;
    private void Awake()
    {
        // _comRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*if (followKilla )
        {
           // MoveAwayFromCharacter();
        }*/

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MoveAwayFromCharacter();
           // gameManagerForMerek.CurrentScore(15);
           // Destroy(this.gameObject);
           
        }
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameManagerForMerek.CurrentScore(15);
           
        }
    }*/
   /* private void OnTriggerEnter2D(Collider2D collision)
    {


        }
    }*/
    void MoveAwayFromCharacter()
    {

        Vector2 directionAwayFromKilla = (transform.position - _Killa.transform.position).normalized;
        // Mueve al enemigo en la dirección opuesta
        transform.position += (Vector3)directionAwayFromKilla * speedMovement * Time.deltaTime;
    }
    void FollowCharacter()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, _Killa.transform.position, speedMovement * Time.deltaTime);
    }
    public void SetGameManager(GameManager newGameManager)
    {
        GameManager = newGameManager;
    }
    public void SetKilla(GameObject killaskz)
    {
        //_Killa = killaskz;
    }
}
