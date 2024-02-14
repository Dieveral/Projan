using ClassFinder;
using ClassFinder.Entities;

namespace ClassFinderTests
{
    public class CodeParserTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void EmptyLineTest()
        {
            // Arrange
            string codeLine = string.Empty;

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Null);
        }

        [Test]
        public void WhitespaceLineTest()
        {
            // Arrange
            string codeLine = " ";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Null);
        }

        [Test]
        public void ClassTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"class {name}";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void WhitespaceClassTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"    class {name}";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void PublicClassTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"public class {name}";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void PublicStaticClassTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"public static class {name}";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void InheritedBaseClassTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"class {name} : BaseClass";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void PublicInheritedBaseClassTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"public class {name} : BaseClass";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void InheritedBaseClassWithInterfaceTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"class {name} : BaseClass, ISomeInterface";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }

        [Test]
        public void PublicInheritedBaseClassWithInterfaceTest()
        {
            // Arrange
            string name = "Test";
            string codeLine = $"public class {name} : BaseClass, ISomeInterface";

            // Act
            ClassInfo? classInfo = CodeParser.ParseCodeLine(codeLine);

            // Assert
            Assert.That(classInfo, Is.Not.Null);
            Assert.That(classInfo.Name, Is.EqualTo(name));
            Assert.That(classInfo.DataType, Is.EqualTo(DataType.Class));
        }
    }
}
