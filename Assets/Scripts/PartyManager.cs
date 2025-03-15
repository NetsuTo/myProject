using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private List<Characters> members = new List<Characters>();
    public List<Characters> Members { get { return members; } } 

    [SerializeField]
    private List<Characters> selectChars = new List<Characters>();
    public List<Characters> SelectChars { get { return selectChars; } }

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (Characters c in members) 
        {
            c.charInit(VFXManager.instance);
            c.MagicSkills.Add(new Magic(0, "Fire ball", 10f, 30, 3f, 1f, 0, 1));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(selectChars.Count > 0)
            {
                selectChars[0].IsMagicMode = true;
                selectChars[0].CurMagicCast = selectChars[0].MagicSkills[0];
            }
        }
    }
}
