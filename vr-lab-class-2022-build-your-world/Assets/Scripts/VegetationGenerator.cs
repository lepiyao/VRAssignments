using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationGenerator : MonoBehaviour
{
    [SerializeField]
    public struct Vegetation
    {
        public GameObject Prefab;
        public int numObjects;
    }

    [SerializeField]
    public List<GameObject> vegetationPrefabs = new List<GameObject>();

    private List<GameObject> instances = new List<GameObject>();

    public List<Collider> restrictedBounds = new List<Collider>();

    public int numObjects = 30;

    public Vector3 vegetationBoundsMin = new Vector3(-30, 0, -30);

    public Vector3 vegetationBoundsMax = new Vector3(30, 0, 30);

    public bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateVegetation();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Exercise 1.2 -> 3.) 
        // check & handle "reset" to regenerate vegetation instances
        if (reset == true) {
            ClearVegetation();
            GenerateVegetation();
            reset = false;
        }
    }

    void ClearVegetation()
    {
        // TODO: part of Exercise 1.2 -> 3.)  
        for (int i=0; i < instances.Count; i++) {
            Destroy(instances[i]);
        }
        instances.Clear();
    }

    void GenerateVegetation()
    {
        // TODO: Exercise 1.2 -> 1.)
        // Instantiate & transform random "vegetationPrefab"

        // your code here
        for (int i=0; i < numObjects;i++) {
            // Set the Transformation using Vector3
            Vector3 rangeMinMax = new Vector3(Random.Range(vegetationBoundsMin.x, vegetationBoundsMax.x),
            Random.Range(vegetationBoundsMin.y, vegetationBoundsMax.y),
            Random.Range(vegetationBoundsMin.z, vegetationBoundsMax.z));
            
            //Choose random prefabs using the number of item list in the vegetationPrefabs
            int item = Random.Range(0, vegetationPrefabs.Count);
            
            //Create the gameObj and set the parent to the transform and add to the instances game object list
            GameObject gObj = Instantiate(vegetationPrefabs[item], rangeMinMax, Quaternion.Euler(0, Random.Range(0, 30), 0));
            gObj.transform.SetParent(transform);
            instances.Add(gObj);

        }
        
        // Collisions need to be resolved at a later time,
        // because Unity physics loop (Unity-internal evaluation of collisions)
        // runs separate from Update() loop
        StartCoroutine(ResolveCollisions());
    }

    IEnumerator ResolveCollisions()
    {
        yield return new WaitForSeconds(2);
        bool resolveAgain = false;

        // TODO: Exercise 1.2 -> 2.)
        // check & handle bounds intersection of each instance with "restrictedBounds"
        // your code here

        Collider col1, col2;
        Vector3 rangeMinMax = new Vector3(Random.Range(vegetationBoundsMin.x, vegetationBoundsMax.x),
            Random.Range(vegetationBoundsMin.y, vegetationBoundsMax.y),
            Random.Range(vegetationBoundsMin.z, vegetationBoundsMax.z));

        for (int i = 0; i < instances.Count; i++)
        {
            col2 = instances[i].GetComponent<Collider>();

            for (int j = 0; j < restrictedBounds.Count; j++)
            {
                col1 = restrictedBounds[j].GetComponent<Collider>();
                if (col1.bounds.Intersects(col2.bounds))
                {
                    //Debug.Log("Bounds intersecting");
                    instances[i].transform.Translate(rangeMinMax);
                }
            }

        }

            // resolve again (delayed), after new random transform applied to colliding instances
            if (resolveAgain)
            StartCoroutine(ResolveCollisions());
    }

    bool IsInRestrictedBounds(Collider co)
    {
        // TODO: part of Exercise 1.2-> 2.)
        return true;
    }
}
