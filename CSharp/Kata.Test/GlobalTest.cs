using FluentAssertions;
using RefactorKata;

namespace Kata.Test
{
    [TestFixture]
    public class GlobalTest
    {
        private BookmarkProcess _bookmarkProcess;
        [SetUp]
        public void SetUp()
        {
            _bookmarkProcess = new BookmarkProcess();
        }

        [Test]
        public void Comare()
        {
            _bookmarkProcess.TranseFerFile();

            var acutual = TestTool.GetFileHash("bookmarks_clear.txt");
            var expected = TestTool.GetFileHash("expectedbookmarks.txt");

            acutual.Should().Be(expected);
        }
    }
}
