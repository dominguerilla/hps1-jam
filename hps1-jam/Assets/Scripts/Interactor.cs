using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles interacting with whateever's under the mouse cursor.
/// </summary>
public class Interactor : MonoBehaviour
{
    public float maxInteractionDistance = 2f;
    public float maxDropDistance = 2f;

    [SerializeField] Arm[] arms;
    Vector3[] originalArmPositions;
    Camera cam;
    InventoryComponent inventory;

    private void Awake()
    {
        inventory = GetComponent<InventoryComponent>();
        cam = Camera.main;
        originalArmPositions = new Vector3[arms.Length];
        for (int i = 0; i < arms.Length; i++)
        {
            originalArmPositions[i] = arms[i].transform.localPosition;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput();
    }

    void GetMouseInput()
    {
        Vector3 direction = cam.transform.forward;
        if (arms.Length <= 0) return;
        if (Input.GetMouseButtonDown(0))
        {
            arms[0].transform.position += direction;
            if (Input.GetKey(KeyCode.E))
            {
                arms[0].Drop();
            }
            else
            {
                bool gotItem = UseArm(arms[0]);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            arms[0].DropIfTemporary();
            arms[0].transform.localPosition = originalArmPositions[0];
        }

        if (Input.GetMouseButtonDown(1))
        {
            arms[1].transform.position += direction;
            if (Input.GetKey(KeyCode.E))
            {
                arms[1].Drop();
            }
            else
            {
                bool gotItem = UseArm(arms[1]);
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            arms[1].DropIfTemporary();
            arms[1].transform.localPosition = originalArmPositions[1];
        }
    }

    bool UseArm(Arm arm)
    {
        if (arm.IsHoldingItem())
        {
            arm.UseItem();
            return false;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
        {
            Transform objectHit = hit.transform;

            ItemComponent item = objectHit.GetComponent<ItemComponent>();
            if (item)
            {
                arm.Hold(item);
                return true;
            }
        }

        return false;
    }

    void Drop()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //TODO: Can only drop if mouse is on something
        //TODO: One can drop an item through a wall/object
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 position = (hit.point - transform.position).normalized;
            this.inventory.Drop(transform.position + position);
        }
    }
}
