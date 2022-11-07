using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject SpawnPoint;

    public LayerMask layer;

    public Vector3 start;
    public Vector3 end;

    LineRenderer lineRenderer;
    public float maxDistance = 100;

    PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    [SerializeField]
    private Texture[] textures;

    private int animationStep;

    [SerializeField]
    private float fps = 30f;
    private float fpsCounter;

    void Update()
    {
        start = SpawnPoint.transform.position;

        PerformRayCast();
        SetlinePositions();

        Debug.DrawLine(start, end, Color.red, 0.5f);

        fpsCounter += Time.deltaTime;
        if(fpsCounter >= 1f / fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }
            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

            fpsCounter = 0f;
        }

        
    }

    void SetlinePositions()
    {
        start.z = -1;
        end.z = -1;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }


    void PerformRayCast()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(start, transform.up, maxDistance, layer);

        if (raycastHit.collider != null)
        {
            end = raycastHit.point;

            GameObject hitobject = raycastHit.collider.gameObject;

            if (hitobject.CompareTag("Player"))
            {
                if(playerHealth == null)
                {
                    playerHealth = hitobject.GetComponent<PlayerHealthManager>();
                }

                playerHealth.LoseHealth(1);
            }
        }
        else
        {
            end = start + transform.up * maxDistance;
        }
    }
}
