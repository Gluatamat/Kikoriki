using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_basic : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        var v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 0.1f;
        transform.Translate(v.x, v.y, 0.0f);
        
    }
}
