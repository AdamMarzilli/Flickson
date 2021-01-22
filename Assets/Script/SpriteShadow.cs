using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShadow : MonoBehaviour
{

    public Vector2 offset = new Vector2(-3, 3);

    private SpriteRenderer sprRendCaster;
    private SpriteRenderer sprRndShadow;

    private Transform transCaster;
    private Transform transShadow;

    public Material shadowMaterial;
    public Color shadowColor;


    void Start()
    {
        transCaster = transform;
        transShadow = new GameObject().transform;
        transShadow.parent = transCaster;
        transShadow.gameObject.name = "shadow";
        transShadow.localRotation = Quaternion.identity;

        sprRendCaster = GetComponent<SpriteRenderer>();
        sprRndShadow = transShadow.gameObject.AddComponent<SpriteRenderer>();

        sprRndShadow.material = shadowMaterial;
        sprRndShadow.color = shadowColor;
        sprRndShadow.sortingLayerName = sprRendCaster.sortingLayerName;
        sprRndShadow.sortingOrder = sprRendCaster.sortingOrder - 1;


    }

    private void LateUpdate()
    {
        transShadow.position = new Vector2(transCaster.position.x + offset.x, transCaster.position.y + offset.y);

        sprRndShadow.sprite = sprRendCaster.sprite;
    }


}
