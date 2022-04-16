using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI.Prototyping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_fingers : NetworkBehaviour
{

    private NetworkVariable<float> anim;

    [SerializeField]
    public Animator a;

    private float tar_anim = 0.0f;

    public void Awake()
    {
        //a = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    [ServerRpc]
    private void RandomizeColorServerRpc(float v)
    {
        anim.Value = v;
    }

    // Update is called once per frame
    void Update()
    {
        //if (a != null) a.SetFloat("anim", anim.Value);
        tar_anim += (anim.Value - tar_anim) * 0.01f;
        a.SetLayerWeight(0, 1.0f - tar_anim);
        a.SetLayerWeight(1, tar_anim);
        if (!IsOwner) return;
        var v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 0.1f;
        transform.Translate(v.x, v.y, 0.0f);

        float j = Input.GetKey(KeyCode.J) ? 1.0f : 0.0f;
        if (j != anim.Value)
        {
            RandomizeColorServerRpc(j);
        }
    }
}