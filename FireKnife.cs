using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKnife : MonoBehaviour
{


    private Rigidbody2D rigid2D;
    private SpriteRenderer spriteRender;

    private float force = 0.1f;
    private Vector3 tempPosition;
    private BoxCollider2D bCollider2D;
   
    public bool isFlying = false;
    private PhysicsMaterial2D phyMaterial;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        bCollider2D = GetComponent<BoxCollider2D>();
        spriteRender.sortingLayerName = "kniftLayer";
        spriteRender.sortingOrder = 2;


        phyMaterial = bCollider2D.sharedMaterial;
        bCollider2D.sharedMaterial = null;

        tempPosition = new Vector3(0, 1.0f, 0);
    }
    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


    }

    //发射
    public void Fire()
    {
        rigid2D.AddForce(transform.up * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //SetFlying(false);

        gameObject.layer = collision.gameObject.layer;
        //rigid2D.mass = 10;
        if (collision.gameObject.tag.Equals("KnifeTag"))
        {

            GameOver();
            return;
        }
        if (collision.gameObject.tag.Equals("ScoreItemTag"))
        {
            Debug.Log(collision.gameObject.tag);
            //AddScore();

        }
        if (collision.gameObject.tag.Equals("DiskTag"))
        {

            //设置刀子的位置
            transform.SetParent(collision.gameObject.transform);

            //tempPosition = collision.gameObject.transform.position;
            //float angle = Quaternion.Angle(new Quaternion(), collision.gameObject.transform.rotation);
            //tempPosition.y -= Mathf.Cos(angle / 180 * Mathf.PI);
            //tempPosition.x += Mathf.Sin(angle/180 * Mathf.PI);

            //tempPosition.y = -1.28f;

            //transform.SetPositionAndRotation(tempPosition,collision.gameObject.transform.rotation);
            transform.position = tempPosition;
            rigid2D.AddForce(transform.up * 0);

            //bCollider2D.size.y = 0.2;
            ;
            //设置刀子的碰撞去大小
            //Vector2 tempVec2 = bCollider2D.size;
            //tempVec2 = bCollider2D.size;
            //tempVec2.y = 0.3f;
            //bCollider2D.size = tempVec2;

            //tempVec2 = bCollider2D.offset;
            //tempVec2.y = -1.1f;
            //bCollider2D.offset = tempVec2;
            rigid2D.bodyType = RigidbodyType2D.Kinematic;

            //Debug.Log("设置刀子的位置  " + collision.gameObject.tag);

            bCollider2D.sharedMaterial = phyMaterial;

        }
    }

    void GameOver()
    {
        rigid2D.constraints = RigidbodyConstraints2D.None;
        Debug.Log("Game Over");

    }

    public void init()
    {
        bCollider2D.sharedMaterial = null;
    }

   
}