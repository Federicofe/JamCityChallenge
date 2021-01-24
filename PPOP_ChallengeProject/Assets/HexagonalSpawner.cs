using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalSpawner : MonoBehaviour
{
    [Header("Spawner Parameters")]
    public int Rows;
    public int Columns;

    [SerializeField]
    private Vector3 InitialPos;
    [SerializeField]
    private Vector3 RightIndex; //va a determinar el desplazamiento hacia la derecha
    [SerializeField]
    private Vector3 NewRowIndex; //va a determinar el desplazamiento hacia arriba
    [SerializeField]
    private Vector3 NewParallelRowIndex; //va a determinar el desplazamiento hacia arriba

    [SerializeField]
    private GameObject HexagonalPrefab;

    [SerializeField]
    private List<Material> materials;

    [Header("Game Elements")]
    [SerializeField]
    private List<HeagonalInGame> heagonals = new List<HeagonalInGame>();

    

    void Start()
    {
        //CUANDO COMIENZA EL JUEGO SE CREAN LOS HEXAGONOS Y SE LES ASIGNA UN SCRIPTABLE OBJECT

        Vector3 pos = new Vector3(InitialPos.x, 0, InitialPos.z);
        Vector3 posInicialFila = new Vector3(InitialPos.x, 0, InitialPos.z);
        int rowIndex = 0;
        for (int r = 1; r <= Rows/2; r++)
        {
            posInicialFila = pos;
            // FILA 1
            for (int c = 0; c < Columns; c++)
            {
                pos = new Vector3(pos.x + RightIndex.x, 0, pos.z + RightIndex.z);
                SpawnHexa(pos,rowIndex,c);
            }

            pos = new Vector3(posInicialFila.x + NewRowIndex.x, 0, posInicialFila.z + NewRowIndex.z);
            rowIndex++;

            // FILA 2
            for (int c = 0; c < Columns; c++)
            {
                pos = new Vector3(pos.x + RightIndex.x , 0, pos.z + RightIndex.z);
                SpawnHexa(pos,rowIndex,c);
            }

            rowIndex++;
            posInicialFila = new Vector3(posInicialFila.x + NewParallelRowIndex.x, 0, posInicialFila.z + NewParallelRowIndex.z);
            pos = posInicialFila;
        }


    }

    private void SpawnHexa(Vector3 pos,int rowIndex,int columnIndex)
    {
        GameObject newHexa = Instantiate(HexagonalPrefab);
        newHexa.transform.position = pos;
        heagonals.Add(new HeagonalInGame(rowIndex, columnIndex, newHexa));
        newHexa.transform.parent = transform;

        //ASIGNAMOS UN MATERIAL ALEATORIO
        ChangeMaterial(newHexa);
    }

    private void ChangeMaterial(GameObject newHexa)
    {
        MeshRenderer renderer = newHexa.GetComponent<MeshRenderer>();
        int materialPos = Random.Range(0, 4);
        renderer.material = materials[materialPos];
    }
}
