using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class D_PlayerAbstract : MonoBehaviour
{
    protected abstract void Move();
    public abstract void TakeDamage(float dmg);

    protected bool CheckGround(LayerMask GroundLayer)
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 1.0f, GroundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
