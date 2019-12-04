using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSave : MonoBehaviour {
    public static MapSave Instance { get; private set; }
    public float x;
    public float y;
    public int EHund=0;
    public int ETen=0;
    public int EOne=0;
    public float cost=0;
    public float plus;
    private void Awake () { if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }
    void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (EOne>9) { EOne = 0;ETen += 1; }
        if (ETen>9) { ETen = 0;EHund += 1; }
        if (EOne<0) { ETen -= 1; EOne = 9; }
        if (ETen<0) { EHund -= 1; ETen = 9; }
        if (cost > 0)
        {
            EOne -= 1;
            cost -= 1;
        }
        if (plus > 0) { EOne += 1;plus -= 1; }
    }
}
