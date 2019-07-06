using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletShot : MonoBehaviour
{
    Vector3 fwd;
    public float bullet_speed = 0.01f;
    public float lifeTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        DestroySelf(lifeTime);
        Vector2 bulletPos = transform.position;
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        fwd = mousPos- bulletPos;
        fwd = fwd.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(fwd * bullet_speed);
    }
    void DestroySelf(float time)
    {
        Destroy(this.gameObject, time);
    }
}
