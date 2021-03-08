using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerHuntManager : MonoBehaviour
{
    private VRObjectinteract[] huntItems;
    private int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mgr = GameObject.FindGameObjectWithTag("HuntMgr");
        huntItems = mgr.GetComponentsInChildren<VRObjectinteract>();
        itemCount = huntItems.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
