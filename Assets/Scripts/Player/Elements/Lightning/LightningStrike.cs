using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public LayerMask layer;

    Vector3 start;
    Vector3 end;

    public float maxDistance = 100;
    float damage;

    public GameObject lightningStrikeAnimation;

    Color textColor;
    float textSize;

    //STRETCH 
    public bool mirrorZ = false;

    public Element lightningElement;



    private void Start()
    {
        damage = lightningElement.bulletDamage;

        textColor = lightningElement.color;
        textSize = lightningElement.weaknessHitTextSize;
    }
    void Update()
    {
        start = transform.position;
    }

    void SetlinePositions()
    {
        start.z = -1;
        end.z = -1;
    }

    void PerformRayCast() 
    {
        //gets the end point of the lightning strike
        //deals damage to any enemy it hits

        RaycastHit2D raycastHit = Physics2D.Raycast(start, transform.up, maxDistance, layer);

        if (raycastHit.collider != null) // has to hit a collider to stop
        {
            end = raycastHit.point;

            GameObject hitobject = raycastHit.collider.gameObject;

            if (hitobject.CompareTag("Enemy"))
            {
                //print("hit an enemy "+hitobject.name);

                HealthManager health;
                if (hitobject.TryGetComponent<HealthManager>(out health))
                {
                    if (health.LightningWeak) { health.WeaknessExploit(damage, end, textColor, textSize); }
                    else { health.TakeDamage(damage, end, textColor); }
                }

                AilmentManager ailment;
                if (hitobject.TryGetComponent<AilmentManager>(out ailment))
                {
                    ailment.ShockBuildup();
                }
            }

            if (hitobject.CompareTag("ElectricDestroyable") ||
                hitobject.CompareTag("Destroyable"))
            {
                HealthManager health;
                if (hitobject.TryGetComponent<HealthManager>(out health))
                {
                    health.TakeDamage(damage, end, textColor);
                }
            }
        }
        else // stop at a maximum set distance
        {
            end = start + transform.up * maxDistance;
        }
        Debug.DrawLine(start, end, Color.red, maxDistance);
    }

    public void SpawnLightningStrike() // call this from player attack to spawn lightning strike
    {
        PerformRayCast();
        GameObject lightning = Instantiate(lightningStrikeAnimation, start, transform.rotation);
        Stretch(lightning, start, end, mirrorZ);
    }
    public void Stretch(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        //find the center between start and end
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;

        //make sprite face the direction of start to end
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.right = direction;

        //invert z
        if (_mirrorZ) _sprite.transform.right *= -1f;

        //reset scale
        Vector3 scale = new Vector3(1, 1, 1);

        //set x scale to be the distance between the start and the end
        scale.x = Vector3.Distance(_initialPosition*0.2f, _finalPosition * 0.2f);

        //apply that scale
        _sprite.transform.localScale = scale;
    }
}
