using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylkoDoAktywacji : MonoBehaviour
{

    public GameObject to;
    // Start is called before the first frame update
    void Awake()
    {
        to.SetActive(true);
    }

}
