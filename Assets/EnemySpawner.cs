
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigid;    
    Transform target;
    private GameObject enemy;
    private GameObject player;
    private float range;
    [SerializeField]
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player"));
        _rigid = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindWithTag("Enemy");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            new Vector2(player.transform.position.x, 0), 
            speed*Time.deltaTime);
        // _rigid.velocity = new Vector2(1, _rigid.velocity.y);
        // range = Vector2.Distance(enemy.transform.position, player.transform.position);
        // if(range <= 15f)
        // {
        //     transform.Translate(Vector2.MoveTowards(enemy.transform.position, player.transform.position, range) * speed * Time.deltaTime);
        // }
    }
}