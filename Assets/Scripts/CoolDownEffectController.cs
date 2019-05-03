using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownEffectController : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite.sprite.name == "CoolDownEffect_4")
        {
            Destroy(gameObject);
        }
    }
}
