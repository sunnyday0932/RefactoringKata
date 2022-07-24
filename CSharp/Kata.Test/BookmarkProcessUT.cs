using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using RefactorKata;

namespace Kata.Test
{
    [TestFixture]
    public class BookmarkProcessUT
    {
        private BookmarkProcess _bookmarkProcess;

        [SetUp]
        public void SetUp()
        {
            _bookmarkProcess = new BookmarkProcess();
        }

        [Test]
        public void RemoveTracingCode_Should_Remove_utm()
        {
            var url = "https://www.cheers.com.tw/article/article.action?id=5095437&utm_referral=dailypost";
            var expected = "https://www.cheers.com.tw/article/article.action?id=5095437";

            var actual = _bookmarkProcess.RemoveTracingCode(url, "utm");

            actual.Should().Be(expected);
        }

        [Test]
        public void RemoveTracingCode_Should_Remove_fbclid()
        {
            var url = "https://blog.darkthread.net/blog/chrome-timer-throttling/?fbclid=IwAR0Tlqz8_XmxlICfu8Z9Mzxnu1dpn-8SAiDjjxg62ufUlGFLISCieHvoKc0";
            var expected = "https://blog.darkthread.net/blog/chrome-timer-throttling/";

            var actual = _bookmarkProcess.RemoveTracingCode(url, "fbclid");

            actual.Should().Be(expected);
        }
        
        [Test]
        public void RemoveTracingCode_Should_Remove_ptc()
        {
            var url = "https://www.test.com/article/view/2450284?ptc_source=134Cda3ge&ptc_info=qz8mxlICf";
            var expected = "https://www.test.com/article/view/2450284";

            var actual = _bookmarkProcess.RemoveTracingCode(url, "ptc");

            actual.Should().Be(expected);
        }
    }
}
