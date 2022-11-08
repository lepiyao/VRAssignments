using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetationGenerator : MonoBehaviour
{
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
        if(reset)
        {
            reset = false;
            ClearVegetation();
            GenerateVegetation();
        }

    }

    void ClearVegetation()
    {
        foreach (var instance in instances)
            Destroy(instance);
        instances.Clear();
    }

    void GenerateVegetation()
    {
        while(instances.Count < numObjects)
        {
            var instance = Instantiate(vegetationPrefabs[Random.Range(0, vegetationPrefabs.Count)]);
            instance.transform.SetParent(gameObject.transform);
            ApplyRandomInstanceTransform(instance);
            instances.Add(instance);
        }
        StartCoroutine(ResolveCollisions());
    }

    IEnumerator ResolveCollisions()
    {
        yield return new WaitForSeconds(2);
        bool resolveAgain = false;
        foreach(var instance in instances)
        {
            if(IsInRestrictedBounds(instance.GetComponent<Collider>()))
            {
                ApplyRandomInstanceTransform(instance);
                resolveAgain = true;
            }
        }
        if (resolveAgain)
            StartCoroutine(ResolveCollisions());
    }

    bool IsInRestrictedBounds(Collider co)
    {
        if (co == null)
            return false;
        foreach(var c in restrictedBounds)
        {
            if (c.bounds.Intersects(co.bounds))
                return true;
        }
        return false;
    }

    void ApplyRandomInstanceTransform(GameObject instance)
    {
        instance.transform.position = CalculateRandomInstancePosition();
        instance.transform.rotation = CalculateRandomInstanceRotation();
    }

    Vector3 CalculateRandomInstancePosition()
    {
        return new Vector3(
            Random.Range(vegetationBoundsMin.x, vegetationBoundsMax.x),
            Random.Range(vegetationBoundsMin.y, vegetationBoundsMax.y),
            Random.Range(vegetationBoundsMin.z, vegetationBoundsMax.z)
        );
    }

    Quaternion CalculateRandomInstanceRotation()
    {
        return Quaternion.Euler(0, Random.Range(-90f, 90f), 0);
    }
}
