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
        public void Compare()
        {
            _bookmarkProcess.ClearTracingCode(@"bookmarks.txt");

            var acutual = TestTool.GetFileHash("bookmarks_clear.txt");
            var expected = TestTool.GetFileHash("expectedbookmarks.txt");

            acutual.Should().Be(expected);
        }
    }
}
