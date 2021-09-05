using Modding;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar
{
    public class Stellar : Mod
    {
        internal static Stellar Instance;

        public Stellar() : base("Stellar") { }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Instance = this;

            Log("poggers");
        }
    }
}
