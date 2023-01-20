using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    public delegate void Combat();
    public static event Combat EnterCombat;
    

    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
