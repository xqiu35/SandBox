using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loder : MonoBehaviour {

    public GameObject gameManager;          //GameManager prefab to instantiate.
    public GameObject soundManager;         //SoundManager prefab to instantiate.
    public GameObject eventManager;
    //public GameObject battleManager;


    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (MusicManager.instance == null)
        {
            Instantiate(soundManager);

        }

        if(EventManager.instance==null)
        {
            Instantiate(eventManager);
        }

        /*if(BattleManager.instance==null)
        {
            Instantiate(battleManager);
        }*/
    }
}
