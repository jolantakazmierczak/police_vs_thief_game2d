using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLayerHandler : MonoBehaviour
{

    List<SpriteRenderer> defaultLayerSpriteRenderers = new List<SpriteRenderer>();

    List<Collider2D> overpassColliderList = new List<Collider2D>();


    Collider2D carCollider;
    bool isDrivingOnOverpass = false;



    void Awake()
    {
        foreach (SpriteRenderer spriteRenderer in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (spriteRenderer.sortingLayerName == "Background")
                defaultLayerSpriteRenderers.Add(spriteRenderer);
        }

        foreach (GameObject overpassColliderGameObject in GameObject.FindGameObjectsWithTag("OverpassCollider"))
        {
            overpassColliderList.Add(overpassColliderGameObject.GetComponent<Collider2D>());
        }

        carCollider = GetComponentInChildren<Collider2D>();
    }

    void Start()
    {
        UpdateSortingAndCollisionLayers();
    }

    void Update()
    {
        SetCollisionWithOverPass();
    }

    void UpdateSortingAndCollisionLayers()
    {
        if (isDrivingOnOverpass)
        {
            SetSortingLayer("RoadOverpass");
        }
        else
        {
            SetSortingLayer("Background");
        }
    }

    void SetCollisionWithOverPass()
    {
        foreach (Collider2D collider2D in overpassColliderList)
        {
            Physics2D.IgnoreCollision(carCollider, collider2D, !isDrivingOnOverpass);
        }
    }

    void SetSortingLayer(string layerName)
    {
        foreach (SpriteRenderer spriteRenderer in defaultLayerSpriteRenderers)
        {
            spriteRenderer.sortingLayerName = layerName;
        }
    }
    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.CompareTag("UnderpassTrigger"))
        {
            isDrivingOnOverpass = false;

            UpdateSortingAndCollisionLayers();
        }

        else if (collider2d.CompareTag("OverpassTrigger"))
        {
            isDrivingOnOverpass = true;
            UpdateSortingAndCollisionLayers();
        }
    }
}
