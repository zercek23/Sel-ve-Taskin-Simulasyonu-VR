using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject jungleTerrain;
    public GameObject mountains;
    public GameObject rainParticle;
    public GameObject altYapi;
    public GameObject cityTerrain;
    public GameObject water;
    public GameObject holeWater;
    public GameObject castle;
    public GameObject pipeWater;

    public float hiz = 2f;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        mountains.SetActive(true);
        rainParticle.SetActive(false);
        altYapi.SetActive(false);
        cityTerrain.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Time.time);
        if (50 < Time.time && Time.time < 55)
        {
            rainParticle.SetActive(true);
        }
        if (55 < Time.time && Time.time < 60)
        {
            StartCoroutine(FogIncrease());
        }
        if (60 < Time.time && Time.time < 65)
        {
            rainParticle.SetActive(false);
        }
        if (65 < Time.time && Time.time < 70)
        {
            StartCoroutine(FogDecrease());
        }
        if (70 < Time.time && Time.time < 76)
        {
            MoveJungleTerrain(-50.3f, 8.53f, 0, -1);
            if (70 < Time.time && Time.time < 76)
            {
                cityTerrain.SetActive(true);
                MoveCityTerrain(-49f, 2, 0, -1);
            }
        }
        if (Time.time == 76)
        {
            jungleTerrain.SetActive(false);
        }
        if (90 < Time.time && Time.time < 95)
        {
            rainParticle.SetActive(true);
        }
        if (95 < Time.time && Time.time < 98)
        {
            StartCoroutine(FogIncrease());
            MoveWater(31.41f, 4.8f, 13.82f, 1);
        }
        if (98 < Time.time && Time.time < 120)
        {
            rainParticle.SetActive(false);
        }
        if (120 < Time.time && Time.time < 123)
        {
            StartCoroutine(FogDecrease());
            MoveWater(31.41f, 2.65545f, 13.82127f, -1);
        }

        if (130 < Time.time && Time.time < 135)
        {
            castle.SetActive(true);
            rainParticle.SetActive(true);
        }
        if (135 < Time.time && Time.time < 138)
        {
            StartCoroutine(FogIncrease());
        }


        if (138 < Time.time && Time.time < 141)
        {            
            holeWater.SetActive(true);
            water.SetActive(false);
            MoveHoleWater(9.14f, -44.4f, 27.1f,1);
        }

        if (141 < Time.time && Time.time < 144)
        {
            rainParticle.SetActive(false);
        }
        if (144 < Time.time && Time.time < 147)
        {
            StartCoroutine(FogDecrease());
        }
        if (161 < Time.time && Time.time < 164)
        {
            MoveHoleWater(9.14f, -46.2f, 27.1f, -1);
        }

        if (164 < Time.time && Time.time < 168)
        {
            MoveCityTerrain(-49f, 30, 0, 1);
            altYapi.SetActive(true);
            MoveAltYapiTerrain(-51, 2.52f, -0.3f, 1);
        }
        if (168 < Time.time && Time.time < 171)
        {
            MoveCityTerrain(-49f, 2, 0, -1);
        }
        if (184 < Time.time && Time.time < 187)
        {
            rainParticle.SetActive(true);            
        }
        if (187 < Time.time && Time.time < 190)
        {
            StartCoroutine(FogIncrease());
            pipeWater.SetActive(true);
        }
        if (190 < Time.time && Time.time < 193)
        {
            rainParticle.SetActive(false);
        }
        if (193 < Time.time && Time.time < 196)
        {
            StartCoroutine(FogDecrease());
        }
    }


    public void MoveJungleTerrain(float x, float y, float z, float direction)
    {
        if (jungleTerrain.transform.position.y != 0)
        {
            jungleTerrain.transform.Translate(0, direction * hiz * Time.deltaTime, 0);
        }
    }

    public void MoveAltYapiTerrain(float x, float y, float z, float direction)
    {
        if (altYapi.transform.position.x < x)
        {
            altYapi.transform.Translate(direction * hiz * Time.deltaTime, 0, 0);
        }
        else
        {
            altYapi.transform.position = new Vector3(x, y, z);
        }
    }

    public void MoveCityTerrain(float x, float y, float z, float direction)
    {
        if (cityTerrain.transform.position.y > y && direction == -1)
        {
            cityTerrain.transform.Translate(0, direction * hiz * Time.deltaTime, 0);
        }
        else if (cityTerrain.transform.position.y < y && direction == 1)
        {
            cityTerrain.transform.Translate(0, direction * hiz * Time.deltaTime, 0);
        }
        else
        {
            cityTerrain.transform.position = new Vector3(x, y, z);
        }
    }
    public void MoveHoleWater(float x, float y, float z, float direction)
    {
        if (holeWater.transform.position.y > y && direction == -1)
        {
            holeWater.transform.Translate(0, direction * 1f * Time.deltaTime, 0);
        }
        else if (holeWater.transform.position.y < y && direction == 1)
        {
            holeWater.transform.Translate(0, direction * 1f * Time.deltaTime, 0);
        }
        else
        {
            holeWater.transform.position = new Vector3(x, y, z);
        }
    }
    public void MoveWater(float x, float y, float z, float direction)
    {
        if (water.transform.position.y > y && direction == -1)
        {
            water.transform.Translate(0, direction * 1f * Time.deltaTime, 0);
        }
        else if (water.transform.position.y < y && direction == 1)
        {
            water.transform.Translate(0, direction * 1f * Time.deltaTime, 0);
        }
        else
        {
            Debug.Log(z);
            water.transform.position = new Vector3(x + 18.2168f, y, z + 11.17873f);
        }
    }

    public IEnumerator FogIncrease()
    {
        for (; i < 1000; i++)
        {
            yield return new WaitForSeconds(0.1f);
            RenderSettings.fogDensity += 0.00001f;
        }
    }

    public IEnumerator FogDecrease()
    {
        for (; i > 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            RenderSettings.fogDensity -= 0.00001f;
        }
        RenderSettings.fogDensity = 0.0015f;
    }
}
