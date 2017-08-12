using System;
using System.Collections.Immutable;
using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using FoldingRenderer.Drawing;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Drawing {
  public class TestsForPanelRectangleFactory {
    readonly IRootPanelPositioner _rootPanelPositioner;
    readonly IPanelPositioner _panelPositioner;
    readonly PanelRectangleFactory _sut;

    protected TestsForPanelRectangleFactory() {
      _rootPanelPositioner = A.Fake<IRootPanelPositioner>();
      _panelPositioner = A.Fake<IPanelPositioner>();
      _sut = new PanelRectangleFactory(_rootPanelPositioner, _panelPositioner);
    }

    public class Create : TestsForPanelRectangleFactory {
      readonly Panel _rootPanel;
      readonly Position _rootPanelHinge;
      readonly Panel _panel1A;
      readonly Panel _panel1B;
      readonly Panel _panel1;
      readonly Panel _panel2A;
      readonly Panel _panel2B;
      readonly Panel _panel2;

      public Create() {
        _panel1A = new Panel().WithName("Panel 1 A");
        _panel1B = new Panel().WithName("Panel 1 B");
        _panel1 = new Panel().WithName("Panel 1")
          .WithAttachedPanels(ImmutableList.Create(_panel1A, _panel1B));

        _panel2A = new Panel().WithName("Panel 2 A");
        _panel2B = new Panel().WithName("Panel 2 B");
        _panel2 = new Panel().WithName("Panel 2")
          .WithAttachedPanels(ImmutableList.Create(_panel2A, _panel2B));
        _rootPanel = new Panel().WithName("Root panel")
          .WithAttachedPanels(ImmutableList.Create(_panel1, _panel2));
        _rootPanelHinge = new Position();
      }

      [Fact]
      public void ShouldThrowWhenRootPanelIsNull() {
        new Action(() => _sut.Create(null, _rootPanelHinge)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldThrowWhenRootPanelHingeIsNull() {
        new Action(() => _sut.Create(_rootPanel, null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldRecursivelyProducePanelRectangles() {
        A.CallTo(() => _rootPanelPositioner.Position(_rootPanel, _rootPanelHinge))
          .Returns(new PanelRectangle(_rootPanel, A.Dummy<Rectangle>(), Rotation.None));
        A.CallTo(() => _panelPositioner.Position(A<PanelRectangle>._, A<Panel>._))
          .ReturnsLazily(call => {
            var panel = call.GetArgument<Panel>(1);
            return new PanelRectangle(panel, A.Dummy<Rectangle>(), Rotation.None);
          });

        var actualPanelRectangles = _sut.Create(_rootPanel, _rootPanelHinge);

        var expectedPanelRectangles = ImmutableList.Create(
          new PanelRectangle(_rootPanel, A.Dummy<Rectangle>(), Rotation.None),
          new PanelRectangle(_panel1, A.Dummy<Rectangle>(), Rotation.None),
          new PanelRectangle(_panel1A, A.Dummy<Rectangle>(), Rotation.None),
          new PanelRectangle(_panel1B, A.Dummy<Rectangle>(), Rotation.None),
          new PanelRectangle(_panel2, A.Dummy<Rectangle>(), Rotation.None),
          new PanelRectangle(_panel2A, A.Dummy<Rectangle>(), Rotation.None),
          new PanelRectangle(_panel2B, A.Dummy<Rectangle>(), Rotation.None)
        );

        actualPanelRectangles.ShouldBeEquivalentTo(expectedPanelRectangles);
      }
    }
  }
}