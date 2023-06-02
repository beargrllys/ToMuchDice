using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public readonly int init_HP = 100;
    public int now_HP;

    // Start is called before the first frame update
    void Start()
    {
        now_HP = init_HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
