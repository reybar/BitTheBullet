﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public int maxHealth = 20;
    [SyncVar]
    public int currHealth = 20;

    PlayerNet player;




    private void Awake() {
        player = GetComponent<PlayerNet>();
    }

    [ServerCallback]
    private void OnEnable() {
        currHealth = maxHealth;
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame

    void Update() {

        if(!isLocalPlayer) {
            return;
        }
        CmdDie();


    }

    [Command]
    void CmdDie() {
        if(currHealth <= 0) {
            RpcDie();

        }
    }

    [ClientRpc]
    void RpcDie() {
        GetComponent<WeaponSync>().slot1 = 0;
        GetComponent<WeaponSync>().slot2 = 0;
        player.Die();

    }


}
