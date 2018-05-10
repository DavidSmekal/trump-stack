using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheStack : MonoBehaviour
{

    public Material material2;
    public Material material4;
    public Material material6;
    public Material material8;
    public Material material10;
    public Material material12;
    public Material material14;
    public Material material16;
    public Material material18;
    public Material material20;
    public Material material22;
    public Material material24;
    public Material material26;
    public Material material28;
    public Material material30;
    public Material material32;
    public Material material34;
    public Material material36;
    public Material material38;
    public Material material40;

    private const float BOUNDS_SIZE = 1.5f;
    private const float ERROR_MARGIN = 0.04f;

    public List<GameObject> myList;

    private Vector3 stackBounds = new Vector3(BOUNDS_SIZE, BOUNDS_SIZE, BOUNDS_SIZE);
    private Vector3 lastTilePosition;

    public int stackIndex = 0;
    public int scoreCount = 1;
    private int combo = 0;
    
    public Text scoreBoardScoreText;
    public Text comboText;
    public Text gameOverScoreText;
    public Text highScoreText;

    private float tileTransition = 0.0f;
    private float tileSpeed = 2.5f;

    private bool gameOver = false;

    public GameObject cameraa;
    public GameObject gameOverCanvas;
    public GameObject userInterfaceCanvas;
    private GameObject topOfList;

    public Transform wallBottom;

    private void Start()
    {

        gameOverCanvas.SetActive(false);
        userInterfaceCanvas.SetActive(true);

        myList = new List<GameObject>();

        // saves the cubes that are already in the game scene
        for (int i = 0; i < transform.childCount; i++)
            myList.Add(transform.GetChild(i).gameObject);

    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (PlaceTile())
            {
                SpawnTile();

                cameraa.transform.position += Vector3.up;
                scoreCount++;
        
                //since scoreCount starts at 1, and is used for something else, I need to subtract 1.
                scoreBoardScoreText.text = (scoreCount - 1).ToString();

            }
            else
            {
                EndGame();
            }
        }
        MoveTile();

    }

    private void MoveTile()
    {

        if (gameOver)
        {
            return;
        }

        tileTransition += Time.deltaTime * tileSpeed;
        myList[stackIndex - 1].transform.localPosition = new Vector3(0, scoreCount, Mathf.Sin(tileTransition) * BOUNDS_SIZE);

    }
    private void SpawnTile()
    {

        lastTilePosition = myList[stackIndex - 1].transform.localPosition;

        stackIndex++;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.localScale = new Vector3(0.09971999F, 1, stackBounds.y);

        // Here I can change the texture of the cube.
        cube.transform.parent = GameObject.Find("The Stack").transform;

        if (stackBounds.y > 1.425)
            cube.GetComponent<Renderer>().material = material40;
        else if (stackBounds.y > 1.35)
            cube.GetComponent<Renderer>().material = material38;
        else if (stackBounds.y > 1.275)
            cube.GetComponent<Renderer>().material = material36;
        else if (stackBounds.y > 1.20)
            cube.GetComponent<Renderer>().material = material34;
        else if (stackBounds.y > 1.125)
            cube.GetComponent<Renderer>().material = material32;
        else if (stackBounds.y > 1.05)
            cube.GetComponent<Renderer>().material = material30;
        else if (stackBounds.y > 0.975)
            cube.GetComponent<Renderer>().material = material28;
        else if (stackBounds.y > 0.90)
            cube.GetComponent<Renderer>().material = material26;
        else if (stackBounds.y > 0.825)
            cube.GetComponent<Renderer>().material = material24;
        else if (stackBounds.y > 0.75)
            cube.GetComponent<Renderer>().material = material22;
        else if (stackBounds.y > 0.675)
            cube.GetComponent<Renderer>().material = material20;
        else if (stackBounds.y > 0.60)
            cube.GetComponent<Renderer>().material = material18;
        else if (stackBounds.y > 0.525)
            cube.GetComponent<Renderer>().material = material16;
        else if (stackBounds.y > 0.45)
            cube.GetComponent<Renderer>().material = material14;
        else if (stackBounds.y > 0.375)
            cube.GetComponent<Renderer>().material = material12;
        else if (stackBounds.y > 0.30)
            cube.GetComponent<Renderer>().material = material10;
        else if (stackBounds.y > 0.225)
            cube.GetComponent<Renderer>().material = material8;
        else if (stackBounds.y > 0.15)
            cube.GetComponent<Renderer>().material = material6;
        else if (stackBounds.y > 0.075)
            cube.GetComponent<Renderer>().material = material4;
        else
            cube.GetComponent<Renderer>().material = material2;   

        myList.Add(cube);

    }

    private bool PlaceTile()
    {

        Transform t = myList[stackIndex - 1].transform;
        float deltaZ = lastTilePosition.z - t.position.z;

        if (Mathf.Abs(deltaZ) > ERROR_MARGIN)
        {
            // cut the tile
            combo = 0;
            comboText.text = "Combo: " + combo.ToString();

            stackBounds.y -= Mathf.Abs(deltaZ);

            if (stackBounds.y <= 0)
            {
                return false;
            }

            float middle = lastTilePosition.z + t.localPosition.z / 2;

            if (stackBounds.y > 1.425)
                t.GetComponent<Renderer>().material = material40;
            else if (stackBounds.y > 1.35)
                t.GetComponent<Renderer>().material = material38;
            else if (stackBounds.y > 1.275)
                t.GetComponent<Renderer>().material = material36;
            else if (stackBounds.y > 1.20)
                t.GetComponent<Renderer>().material = material34;
            else if (stackBounds.y > 1.125)
                t.GetComponent<Renderer>().material = material32;
            else if (stackBounds.y > 1.05)
                t.GetComponent<Renderer>().material = material30;
            else if (stackBounds.y > 0.975)
                t.GetComponent<Renderer>().material = material28;
            else if (stackBounds.y > 0.90)
                t.GetComponent<Renderer>().material = material26;
            else if (stackBounds.y > 0.825)
                t.GetComponent<Renderer>().material = material24;
            else if (stackBounds.y > 0.75)
                t.GetComponent<Renderer>().material = material22;
            else if (stackBounds.y > 0.675)
                t.GetComponent<Renderer>().material = material20;
            else if (stackBounds.y > 0.60)
                t.GetComponent<Renderer>().material = material18;
            else if (stackBounds.y > 0.525)
                t.GetComponent<Renderer>().material = material16;
            else if (stackBounds.y > 0.45)
                t.GetComponent<Renderer>().material = material14;
            else if (stackBounds.y > 0.375)
                t.GetComponent<Renderer>().material = material12;
            else if (stackBounds.y > 0.30)
                t.GetComponent<Renderer>().material = material10;
            else if (stackBounds.y > 0.225)
                t.GetComponent<Renderer>().material = material8;
            else if (stackBounds.y > 0.15)
                t.GetComponent<Renderer>().material = material6;
            else if (stackBounds.y > 0.075)
                t.GetComponent<Renderer>().material = material4;
            else
                t.GetComponent<Renderer>().material = material2;

            t.localScale = new Vector3(0.09971999F, 1, stackBounds.y);
            /*
           CreateRubble(
               new Vector3(t.position.x, 
                t.position.y,
                (t.position.z > 0) ?
                t.position.z + (t.localScale.z / 2) :
                t.position.z - (t.localScale.z / 2)), 
               new Vector3(t.localScale.x, 1, Mathf.Abs(deltaZ)));
            */

            t.localPosition = new Vector3(lastTilePosition.x, scoreCount, middle - (lastTilePosition.z / 2));
        }
        else
        {
            combo++;
            comboText.text = "Combo: " + combo.ToString();

            t.localPosition = new Vector3(lastTilePosition.x, scoreCount, lastTilePosition.z);
        }
        return true;
    }

    private void EndGame()
    {

        userInterfaceCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);


        int highestScore = (PlayerPrefs.GetInt("High Score"));

        if (highestScore < (scoreCount - 1)){

            PlayerPrefs.SetInt("High Score", (scoreCount - 1));
            highScoreText.text = "High Score: " + (scoreCount - 1).ToString() + " feet.";
        }
        else
        {
            highScoreText.text = "High Score: " + highestScore.ToString() + " feet.";
        }

        
       
       

        if ((scoreCount - 1) == 1)
        {
            gameOverScoreText.text = "You built the wall " + (scoreCount - 1).ToString() + " foot high!";
        }
        else
        {
            gameOverScoreText.text = "You built the wall " + (scoreCount - 1).ToString() + " feet high!";
        }
        
        gameOver = true;
        myList[stackIndex - 1].AddComponent<Rigidbody>();

       
    }

    /*
    private void CreateRubble(Vector3 pos, Vector3 scale)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.AddComponent<Rigidbody>();
        Destroy(go);
    }
    */
}
