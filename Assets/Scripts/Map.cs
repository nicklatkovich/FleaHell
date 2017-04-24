using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject WallPrefab;
    public uint Width, Height;

    void Start( ) {
        int[ ][ ] grid = new int[Width][ ];
        for (uint i = 0; i < Width; i++) {
            grid[i] = new int[Height];
            for (uint j = 0; j < Height; j++) {
                grid[i][j] = Random.value < 0.1f ? 1 : 0;
            }
        }

        for (uint i = 0; i < Width; i++) {
            uint j = Height - 1;
            grid[i][j] = grid[i][0] = 1;
        }
        for (uint j = 0; j < Height; j++) {
            uint i = Width - 1;
            grid[i][j] = grid[0][j] = 1;
        }

        for (uint i = 0; i < Width; i++) {
            for (uint j = 0; j < Height; j++) {
                if (grid[i][j] == 1) {
                    Instantiate(WallPrefab, new Vector3(i, 0.5f, j), Quaternion.identity);
                }
            }
        }
    }

    void Update( ) {

    }
}
