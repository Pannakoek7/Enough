using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    internal enum State
    {
        Start,
        Sail,
        BrokenRadio,
        Receive,
        Magneticwaves,
        RadioWorking,
        SpinningWheel,
        Seagull,
        Throwing
    }

    internal State myState = State.Start;
}
