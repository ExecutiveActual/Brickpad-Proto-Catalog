namespace Brickpad.ProtoCatalog.Editor
{
    /// <summary>
    /// Editor-side anchor for Brickpad Proto-Catalog.
    /// Module inspectors and menu items belong in each module's <c>.Editor</c> namespace, not here.
    /// </summary>
    public static class ProtoCatalogEditor
    {
        /// <summary>
        /// Runtime package version this editor assembly was compiled against.
        /// </summary>
        public static string RuntimeVersion => ProtoCatalogInfo.Version;
    }
}
