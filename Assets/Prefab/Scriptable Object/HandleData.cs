using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="HandleData", menuName="ScriptableObject")]

public class HandleData : ScriptableObject
{
    public bool topHandle;
    public bool bottomHandle;
    public bool leftHandle;
    public bool rightHandle;
    public bool frontHandle;
    public bool backHandle;

    public int numberHandle = 2;
    private int count = 0;
    public bool canMove = false ; 

    // Update is called once per frame
    public void countHandle()
    {
        count = 0;
        if (topHandle){count +=1;}
        if (bottomHandle) {count +=1;}
        if (leftHandle) {count +=1;}
        if (rightHandle) {count +=1;}
        if (frontHandle) {count +=1;}
        if (backHandle) {count +=1;}

        if (count >= numberHandle){
            canMove = true;
        }
        else{ canMove = false;}
    }
}
