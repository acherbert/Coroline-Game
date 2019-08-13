using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroline : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigid;
    [SerializeField]
    // private float _jumpForce = 5.0f;
    // [SerializeField]
    private bool _grounded = false;
    [SerializeField]

    public float speed;
    public float jumpforce;

    bool isJumping;
    Rigidbody2D rb;

    //use this for initialization
    void start () {
        rb = GetComponent<Rigidbody2D> ();
     }

     void FixedUpdate() {
         float move = Input.GetAxis ("horizontal"); 
         rb.velocity = new Vector2 (speed * move, rb.velocity.y);

         Jump ();
     }

     void Jump(){
         if (Input.GetKeyDown (KeyCode.Space) && !isJumping) {
             isJumping= true;

             rb.AddForce(new Vector2 (rb.velocity.x, jumpforce));
         }
     }

     void OnCollisionEnter2D(Collision2D other){
         if(other.gameObject.CompareTag("Ground")){
             isJumping = false;

             rb.velocity = Vector2.zero;
         }
     }

    private LayerMask _groundLayer;
    private bool resetJumpNeeded;
    [SerializeField]
    // private float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    
    void Movement()
    {
        float horizontalInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0 || horizontalInput > 1)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
        Debug.Log(_sprite);
        Debug.Log(horizontalInput);

        _grounded = false;
        isGrounded();

        _rigid.velocity = new Vector2(horizontalInput * speed, _rigid.velocity.y);
        Debug.Log("horizontalInput");
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {

            // _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }
    }
    bool isGrounded() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, _groundLayer.value);
            Debug.Log(hitInfo.collider);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if(hitInfo.collider != null){
            Debug.Log("You hit " + hitInfo.collider.name);
            _grounded = true;

            if(resetJumpNeeded == false)
                return true;
        }
        return false;
           
    }
    IEnumerator ResetJumpNeededRoutine(){
        yield return new WaitForSeconds(.1f);
        resetJumpNeeded = false;
    }


}

