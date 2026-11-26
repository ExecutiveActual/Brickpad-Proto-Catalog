using NUnit.Framework;

namespace Brickpad.ProtoCatalog.Tests
{
    /// <summary>
    /// Proves the Play Mode test assembly references Brickpad.ProtoCatalog.
    /// </summary>
    public class CatalogSmokeTests
    {
        [Test]
        public void RuntimeAssembly_IsTheCatalog()
        {
            Assert.That(typeof(ProtoCatalogInfo).Assembly.GetName().Name, Is.EqualTo("Brickpad.ProtoCatalog"));
            Assert.That(string.IsNullOrEmpty(ProtoCatalogInfo.Version), Is.False);
        }
    }
}
