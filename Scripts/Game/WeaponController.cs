using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    SpriteRenderer _spriteRenderer;
    bool right = true;

    [SerializeField] float reload;
    Timer reloadTimer;

    Quaternion rotation;

    void Start()
    {
        reloadTimer = gameObject.AddComponent<Timer>();
        reloadTimer.Duration = reload; 
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        UpdateDirection();
        UpdateAngle(angle);
        if (Input.GetAxisRaw("Shoot") == 1 && (reloadTimer.Finished || !reloadTimer.Started))
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z), rotation);
            reloadTimer.Run();
            AudioManager.Play(AudioClipName.Shoot, AudioTypes.SoundEffect);
        }
    }

    void UpdateAngle(float angle)
    {
        if (angle < 90 && angle > -90 && right || angle > 90 && angle < 180 && !right || angle < -90 && angle > -180 && !right)
        {
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
    }
    void UpdateDirection()
    {
        float xMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        if (xMousePos > transform.position.x + 1)
        {
            if (!right)
            {
                _spriteRenderer.flipY = false;
                right = true;
                transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            }
        }
        else if (right && xMousePos < transform.position.x - 1)
        {
            _spriteRenderer.flipY = true;
            right = false;
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        }
    }
}
