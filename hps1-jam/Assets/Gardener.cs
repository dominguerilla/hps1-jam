using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Gardener : MonoBehaviour
{
    public float unitScale = 10f;
    public GameObject player;

    public Vector3 gardenDimensions;
    public Vector3 minFlowerSize;
    public Vector3 maxFlowerSize;
    public GameObject[] flowers;
    public int numberOfFlowers;

    [SerializeField]
    Transform groundBlock;

    GameObject[] currentFlowers;
    bool isGenerating = false;
    bool alreadyRegenerated = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGround();
        if(Application.isPlaying) RegenerateGarden();
        ClearRegeneratedFlag();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGround();
        CheckPlayer();
    }

    void CheckPlayer()
    {
        if (player.transform.position.y < -500)
        {
            RegenerateGarden();
        }

    }

    void UpdateGround() {
        if (groundBlock != null)
        {
            groundBlock.localScale = gardenDimensions;
        }
    }

    public void RegenerateGarden()
    {
        if (alreadyRegenerated || isGenerating) return;
        ClearGarden();
        StartCoroutine(GenerateGarden());
        alreadyRegenerated = true;
    }

    public void ClearRegeneratedFlag()
    {
        alreadyRegenerated = false;
    }

    IEnumerator GenerateGarden()
    {
        isGenerating = true;
        if (flowers.Length > 0)
        {
            currentFlowers = new GameObject[numberOfFlowers];
            for (int i = 0; i < currentFlowers.Length; i++)
            {
                GameObject flower = PlaceFlowerRandomly();
                currentFlowers[i] = flower;
                yield return null;
            }
        }

        isGenerating = false;
        yield return null;
    }

    GameObject PlaceFlowerRandomly()
    {
        int random = Random.Range(0, flowers.Length);
        GameObject flower = GameObject.Instantiate(flowers[random]);

        Vector3 randomScale = GetRandomVector3(minFlowerSize, maxFlowerSize);
        flower.transform.localScale = randomScale;

        Vector3 randomPosition = GetRandomVector3(Vector3.zero, new Vector3(gardenDimensions.x * unitScale, 0.5f, gardenDimensions.z * unitScale));
        flower.transform.position = randomPosition;

        return flower;
    }

    Vector3 GetRandomVector3(Vector3 minSize, Vector3 maxSize)
    {
        return new Vector3(
            Random.Range(minSize.x, maxSize.x),
            Random.Range(minSize.y, maxSize.y),
            Random.Range(minSize.z, maxSize.z)
            );
    }

    void ClearGarden()
    {
        if (currentFlowers == null) return;
        for (int i = 0; i < currentFlowers.Length; i++)
        {
            Destroy(currentFlowers[i]);
        }
    }
}
