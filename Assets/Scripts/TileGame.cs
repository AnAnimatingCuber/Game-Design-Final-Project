using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TileGame : MonoBehaviour 
{

[SerializeField] private Transform gameTransform;
[SerializeField] private Transform piecePrefab;
[SerializeField] private List<Transform> pieces;

private int emptyLocation;
public int size;
private bool shuffling = false;
public GameObject winScreen;

private void CreateGamePieces(float gapThickness)
{
    float width = 1 / (float)size;
    for (int row = 0; row<size; row++){
        for (int col = 0; col<size; col++){
            Transform piece = Instantiate(piecePrefab, gameTransform);
            pieces.Add(piece);

            piece.localPosition = new Vector3(-1 +(2 * width * col)+ width, 1 -(2 * width * row)-width, 0);
            piece.localScale = ((2*width)-gapThickness) * Vector3.one;
            piece.name = $"{(row*size) + col}";

            if ((row == size -1) && (col == size-1)){
                emptyLocation = (size * size)-1;
                piece.gameObject.SetActive(false);
            }
            else{
                float gap = gapThickness / 2;
                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(( width * col) + gap, 1 - ((width * (row+1)) - gap));
                uv[1] = new Vector2(( width * (col+1)) - gap, 1 - ((width * (row+1)) - gap));
                uv[2] = new Vector2(( width * col) + gap, 1 - ((width*row) + gap));
                uv[3] = new Vector2(( width * (col+1)) - gap, 1 - ((width*row) + gap));
                mesh.uv = uv;
            }
        }
    }
}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!shuffling && CheckCompletion()){
            shuffling = true;
            StartCoroutine(Wait(0.05f));
        }
        if (Input.GetMouseButtonDown(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit){
                for (int i = 0; i < pieces.Count; i ++){
                    if(pieces[i] == hit.collider.gameObject.transform){
                        if (CanSwap(i, -size, size)){break; }
                        if (CanSwap(i, +size, size)){break; }
                        if (CanSwap(i, -1, 0 )){break; }
                        if (CanSwap(i, +1, size-1)){break; }
                    }
                }
            }
        }
        
    }

    private bool CanSwap(int i, int offset, int ColCheck){
        if(((i % size)!= ColCheck) && ((i + offset) == emptyLocation)){
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);
            emptyLocation = i;
            return true;
        }
        return false;
    }

private IEnumerator Wait(float duration){
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
}

private bool CheckCompletion(){
    for (int i = 0; i < pieces.Count; i++){
        if (pieces[i].name != $"{i}"){
            return false;
        }
    }
        return true;
    }


private void Shuffle(){
    int Count = 0;
    int last = 0;
    while(Count < (size*size*size)){
        int rnd = Random.Range(0,size*size);
        if (rnd == last) {continue; }
    last = emptyLocation;
        if (CanSwap(rnd, -size, size)){
            Count++;
        }
        else if (CanSwap(rnd, +size, size)){
            Count++;
        }
        else if (CanSwap(rnd, -1, 0)){
            Count++;
        }
        else if (CanSwap(rnd, +1, -1)){
            Count++;
        }

    
}
}
}

