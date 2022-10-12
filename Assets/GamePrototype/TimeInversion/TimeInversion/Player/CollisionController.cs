using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D boxCollider2D;
    public LayerMask groundlayer;
    public bool onGround;

    [Header("Gizmos")]
    public Vector2 boxSize;
    public Vector2 bottomOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapBox((Vector2)this.transform.position + bottomOffset, boxSize, 0, groundlayer);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)this.transform.position + bottomOffset, boxSize);
    }
}
