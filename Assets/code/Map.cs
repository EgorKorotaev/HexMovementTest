using System;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Map(ref GameObject[,] grid, int shiftR, int shiftQ)
    {
        this.grid = grid;
        this.shiftR = shiftR;
        this.shiftQ = shiftQ;
    }
    
    public GameObject[,] grid;
    private int shiftR;
    private int shiftQ;
    
}

