using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCollection : MonoBehaviour
{
    internal enum State
    {
        Start,
        Sail,
        BrokenRadio,
        Receive,
        Magneticwaves,
        RadioWorking
    }

    internal State myState = State.Start;
}
