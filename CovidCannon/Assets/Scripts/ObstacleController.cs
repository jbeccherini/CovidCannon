using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Sprite[] obstacleSprites;

    public SpriteRenderer spriteRenderer;

    public enum Obstacle { manUnmasked, manMasked, woman, womanInfected, child, table, infectedTable};

    public Obstacle obstacle;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
      

    public void ChangeSprite(int index) 
    {
        spriteRenderer.sprite = obstacleSprites[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "MaskBomb")
        {
            if (this.obstacle == Obstacle.manUnmasked)
            {
                this.obstacle = Obstacle.manMasked;
                ChangeSprite((int)Obstacle.manMasked);
                GameManager.changeScore(1);
            }
        }
        else if (collision.collider.gameObject.tag == "DisinfectBomb")
        {
            if (this.obstacle == Obstacle.infectedTable)
            {
                this.obstacle = Obstacle.table;
                ChangeSprite((int)Obstacle.table);
                GameManager.changeScore(1);
            }
        }
    }



}
