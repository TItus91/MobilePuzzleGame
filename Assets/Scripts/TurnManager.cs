using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public static int arraySize = 3;
    int[,] array = new int[arraySize, arraySize];
    // Start is called before the first frame update
    void Start()
    {
        PopulateBoard();
      
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
		{
            CreateRayCast();
		}
        
    }

    void PopulateBoard()
	{
        int nr = 1;
        for (int i=0;i<5;i++)
		{
            for (int j=0;j<5;j++)
			{
                GameObject tmpGO = Instantiate(Resources.Load("Cube", typeof(GameObject))) as GameObject;
                tmpGO.transform.position = new Vector3(i * 1.5f-3f, j * 1.5f-3f, 0f);
                tmpGO.name = nr.ToString();
                nr++;
            }
		}
	}

    void CreateRayCast()
	{
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 25))
		{
            MakeMove(int.Parse(hit.collider.name));
		}
	}

    void MakeMove(int name)
	{
        Turn(name);
        Turn(name - 5);
        Turn(name + 5);
        if (name % 5 != 0) Turn(name + 1);
        if (name % 5 != 1) Turn(name - 1);

    }

    void Turn(int name)
	{
        if (name >= 1 && name <= 25)
        {
            GameObject cube = GameObject.Find(name.ToString()).gameObject;
            cube.GetComponent<LightSwitch>().switchLight();
        }
        else return;
    }
}
