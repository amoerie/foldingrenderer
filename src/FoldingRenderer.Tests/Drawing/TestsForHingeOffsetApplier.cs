using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Drawing;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Drawing {
  public class TestsForHingeOffsetApplier {
    readonly HingeOffsetApplier _sut;

    protected TestsForHingeOffsetApplier() {
      _sut = new HingeOffsetApplier();
    }

    public class Apply : TestsForHingeOffsetApplier {
      readonly Rectangle _rectangle;

      public Apply() {
        /*
         *                             300px
         *           <--------------------------------------->
         *         (0,0)                                 (300,0) 
         *       ^   o---------------------------------------o
         *       |   |                                       |
         *       |   |                                       |
         * 100px |   |                                       |
         *       |   |                                       |
         *       |   |                                       |
         *       v   o---------------------------------------o
         *         (0,100)                               (300,100)
         *                          
         */
        _rectangle = new Rectangle(new Point(0, 0), new Size(300, 100));
      }

      // ReSharper disable MemberCanBePrivate.Global
      public static readonly object[][] TestScenarios = {
        new object[] { Rotation.None, +10, new Point(+10, 0) },
        new object[] { Rotation.None, -10, new Point(-10, 0) },
        new object[] { Rotation.Right, +10, new Point(0, +10) },
        new object[] { Rotation.Right, -10, new Point(0, -10) },
        new object[] { Rotation.Down, +10, new Point(-10, 0) },
        new object[] { Rotation.Down, -10, new Point(+10, 0) },
        new object[] { Rotation.Left, +10, new Point(0, -10) },
        new object[] { Rotation.Left, -10, new Point(0, +10) },
      };

      [Theory]
      [MemberData(nameof(TestScenarios))]
      public void ShouldApplyCorrectMove(Rotation rotation, int hingeOffset, Point expectedTopLeftPosition) {
        var rectangle = _sut.Apply(_rectangle, rotation, hingeOffset);
        rectangle.Size.ShouldBeEquivalentTo(_rectangle.Size); // size should not change
        rectangle.Location.ShouldBeEquivalentTo(expectedTopLeftPosition);
      }
    }
  }
}