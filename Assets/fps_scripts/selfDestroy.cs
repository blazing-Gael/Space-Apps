using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    [SerializeField]
    private float killTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, killTime);
    }

}
