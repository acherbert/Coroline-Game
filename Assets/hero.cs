using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5 / 0f;
    [SerializeField]
    private bool _grounded = false;

    //start is called before the first frame update

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
        float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);

        if (hitInfo.collider != null)
        {
            Debug.Log("You hit" + hitInfo.collider.name);
            _grounded = true;
        }
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);

    }
}
