using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> poolObjects;
    public GameObject objectToPool;
    public int amounttoPool;

   private void Awake()
   {
       sharedInstance = this;
   }
    //Start is called before the first frame update
    void Start()
    {
        poolObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < amounttoPool; i++)
        {
            temp = Instantiate(objectToPool);
            temp.SetActive(false);

            //it works out better is pooled objects don't start with gravity
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            if(rb != null)
                rb.useGravity = false;

            poolObjects.Add(temp);
        }

    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amounttoPool; i++)
        {
            if(!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
