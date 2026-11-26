using NUnit.Framework;
using UnityEditor;

namespace Brickpad.ProtoCatalog.Editor.Tests
{
    /// <summary>
    /// Proves the Edit Mode test assembly references the editor and runtime catalog assemblies.
    /// </summary>
    public class EditorSmokeTests
    {
        [Test]
        public void EditorAssembly_SeesTheRuntimeVersion()
        {
            Assert.That(EditorApplication.isPlaying, Is.False);
            Assert.That(
                typeof(ProtoCatalogEditor).Assembly.GetName().Name,
                Is.EqualTo("Brickpad.ProtoCatalog.Editor"));
            Assert.That(ProtoCatalogEditor.RuntimeVersion, Is.EqualTo(ProtoCatalogInfo.Version));
        }
    }
}
