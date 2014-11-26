using strange.extensions.signal.impl;
using UnityEngine;

namespace AST.Game
{
    public class GameStartSignal : Signal { }
    public class GameUpdateSignal : Signal<float> { }
    public class SpawnSignal : Signal { }
    public class ReparentSpawnedObjectSignal : Signal<GameObject> { }
}
