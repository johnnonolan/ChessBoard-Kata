using System;
using NUnit.Framework;

namespace ChessBoard.Specifications.Tests
{
    [TestFixture]
    public class KnightMovmentTests
    {
        [TestCase("D4","B3")]
        [TestCase("D4","B5")]
        [TestCase("D4","C2")]
        [TestCase("D4","E2")]
        [TestCase("D4","C6")]
        [TestCase("D4","E6")]
        [TestCase("D4","F3")]
        [TestCase("D4","F5")]
        public void MovingTheKnightCorrectly(string startPos, string endPos)
        {
            var knight = new Knight(startPos);
            Assert.DoesNotThrow(()=> knight.Move(endPos, "A1"));
            Assert.That(knight.Position, Is.EqualTo(endPos));

        }
        [Test]
        public void MovingTheKnightTooClose()
        {
            var knight = new Knight("D4");
            Assert.Throws<InvalidOperationException>(()=>knight.Move("D3","A1"));
        }
    }
}
