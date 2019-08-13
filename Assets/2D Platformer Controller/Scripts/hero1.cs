// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Hero1 : MonoBehaviour
// {

//     [SerializeField]
//     private SpriteRenderer _sprite;
//      private Rigidbody2D _rigid;
//      [SerializeField]
//      private float _jumpForce = 5.0f;
//      [SerializeField]
//      private bool _grounded = false;
//     [SerializeField]

//      private LayerMask _groundLayer;
//      private bool resetJumpNeeded;
//      [SerializeField]
//      private float speed = 0.3f;

//     // Start is called before the first frame update
//     void Start()
//     {
//      _rigid = GetComponent<Rigidbody2D>();
//      _sprite = GetComponentInChildren<SpriteRenderer>();
        
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         Movement();
        
//     }

//     void Movement(){
//     float horizontalInput = UnityEngine.Input.GetAxisRaw("Horizontal");
//     if(horizontalInput == 0 || horizontalInput == 1){
//         _sprite.flipX = false;
//     }else {
//         _sprite.flipX = true;
//     }
//     Debug.Log(_sprite);
//     Debug.Log(horizontalInput);
//     _rigid.velocity = new Vector2(horizontalInput * speed, _rigid.velocity.y);
//     if(UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded() == true){
            
//             _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
//             _grounded = false;
//             resetJumpNeeded = true;
//             StartCoroutine(ResetJumpNeededRoutine());
//         }       
//     }

//     bool isGrounded() {
//         RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, _groundLayer.value);

//         Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

//         if(hitInfo.collider != null){
//             Debug.Log("You hit " + hitInfo.collider.name);
//             _grounded = true;

//             if(resetJumpNeeded == false)
//                 return true;
//         }
//         return false;
//         ;
//     }

//     IEnumerator ResetJumpNeededRoutine(){
//         yield return new WaitForSeconds(.1f);
//         resetJumpNeeded = false;
//     }

// }


