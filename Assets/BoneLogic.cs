using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLogic : MonoBehaviour
{public Material material;
	
    // Start is called before the first frame update
    void Start()
    {GetComponent<MeshRenderer>().material = material;
        
    }

    void Update()
    {
	
    }
}
