using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingForce : MonoBehaviour
{
    #region Variables
    public List<GameObject> pullObjectsList;

    [Range (0.0f, 100.0f)]
    [SerializeField] private float pullForce;
    [SerializeField] private float rotationForce;
    [SerializeField] private float destroyDistance;
    #endregion

    void FixedUpdate()
    {
       Pull();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.TryGetComponent(out DestructibleObjects desObjScript))
        {
            if (desObjScript.isDestructible)
            {
                pullObjectsList.Add(obj);
            }

            Animator anim = obj.GetComponent<Animator>();
            anim.SetTrigger("Shatter");
        }
    }

    private void Pull()
    {
        if (pullObjectsList.Count > 0)
        {
            pullObjectsList.ForEach(delegate (GameObject obj)
            {
                obj.GetComponent<Rigidbody2D>().AddForce(-((new Vector2(obj.transform.position.x - transform.position.x, obj.transform.position.y - transform.position.y)).normalized) * pullForce);
                obj.GetComponent<Rigidbody2D>().AddTorque(rotationForce, ForceMode2D.Force);

                if ((obj.transform.position - transform.position).sqrMagnitude < destroyDistance * destroyDistance)
                {
                    int index = pullObjectsList.IndexOf(obj);
                    pullObjectsList.RemoveAt(index);
                    Animator anim = obj.GetComponent<Animator>();
                    anim.SetTrigger("Break");
                    Destroy(obj, 1);
                }
            });
        }
    }
}
