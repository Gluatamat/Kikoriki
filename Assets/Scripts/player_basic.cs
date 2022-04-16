using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_basic : NetworkBehaviour
{

    private NetworkVariable<Color> color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ServerRpc]
    private void RandomizeColorServerRpc()
    {
        color.Value = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        var mat = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
        mat.SetColor("_Color", color.Value);
        if (!IsOwner) return;
        var v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 0.1f;
        transform.Translate(v.x, v.y, 0.0f);
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            RandomizeColorServerRpc();
        }
    }
}
