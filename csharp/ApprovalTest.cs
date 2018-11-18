using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\ThirtyDays.txt";
            var lines = File.ReadAllLines(filePath);

            var fakeOutput = new StringBuilder();
            var stringWriter = new StringWriter(fakeOutput)
            {
                NewLine = "\n"
            };

            Console.SetOut(stringWriter);
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeOutput.ToString();

            var outputLines = output.Split('\n');
            for (var i = 0; i < Math.Min(lines.Length, outputLines.Length); i++)
            {
                Assert.AreEqual(lines[i], outputLines[i]);
            }
        }
    }
}
