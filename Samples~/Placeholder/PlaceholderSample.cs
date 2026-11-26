using UnityEngine;

namespace Brickpad.ProtoCatalog.Samples.Placeholder
{
    /// <summary>
    /// Logs the catalog version once so you can confirm the package reference compiled.
    /// </summary>
    public sealed class PlaceholderSample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(
                "Brickpad Proto-Catalog " + ProtoCatalogInfo.Version + " placeholder sample is running.",
                this);
        }
    }
}
