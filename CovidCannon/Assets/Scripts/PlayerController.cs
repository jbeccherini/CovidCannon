using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameOver) 
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(inputX, inputY, 0) * speed * Time.deltaTime;

            transform.Translate(movement);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");

        if (collision.collider.gameObject.tag == "BombPile") 
        {
            if (collision.collider.gameObject.name == "MaskBombPile") 
            {
                GameManager.changeNumBombs(0, 3);
            }
            else if (collision.collider.gameObject.name == "DisinfectBombPile")
            {
                GameManager.changeNumBombs(1, 3);
            }

            Debug.Log("Picked Up Bomb Pile");

            Destroy(collision.collider.gameObject);
        }
        
        
    }
}
