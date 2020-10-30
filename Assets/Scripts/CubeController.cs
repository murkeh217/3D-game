using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour
{
    public GameObject redcube;
    public GameObject bluecube;

    private GameObject spawnedRedCube;
    private GameObject spawnedBlueCube;

    public Text gameOverText;
    public Text objText;
    
    private int numActiveObj = 0;

    private List<GameObject> cubeList = new List<GameObject>();



    private void Update()
    {
        foreach (var cube in cubeList)
        {
            cube.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
            
        }

        objText.text = "Count: " + CountActive();

        if (numActiveObj == 0) {
            gameOverText.text = "You Win !";
            StartCoroutine(WaitForSceneLoad());
        }

    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);

    }
    private void SpawnCubes()
    {

        for (int i = 0; i < 10; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                Vector3 position = new Vector3(Random.Range(-15f, 15f), -0.5f, Random.Range(-15f, 15f));
                spawnedRedCube = Instantiate(redcube, position, Quaternion.identity);
                cubeList.Add(spawnedRedCube);
            }
            else
            {
                Vector3 position = new Vector3(Random.Range(-15f, 15f), -0.5f, Random.Range(-15f, 15f));
                spawnedBlueCube = Instantiate(bluecube, position, Quaternion.identity);
                cubeList.Add(spawnedBlueCube);
            }
        }

    }

    private void Awake()
    {
        SpawnCubes();

        //cubeList.Add(redcube);
        //cubeList.Add(bluecube);

    }


    private int CountActive()
    {
        numActiveObj = 0;
        for (int i = 0; i < cubeList.Count; i++)
        {
            if (cubeList[i].activeSelf == true)
            {
                numActiveObj++;
            }
        }
        return numActiveObj;
    }

}