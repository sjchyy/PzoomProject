using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UserWindow
{
  public  class NormalWindow:Window
    {
        public Resizer Wr { get; private set; }

    public NormalWindow()
    {
       Wr = new Resizer(this);
       TaskShow.RepairWpfWindowFullScreenBehavior(this);
    }

    public static readonly DependencyProperty NormalWindowHeaderBackgroundProperty = DependencyProperty.Register("NormalWindowHeaderBackground", typeof(Brush), typeof(NormalWindow), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(22, 238, 238, 238))));
    public Brush NormalWindowHeaderBackground
    {
        get { return (Brush)GetValue(NormalWindowHeaderBackgroundProperty); }
        set { SetValue(NormalWindowHeaderBackgroundProperty, value); }
    }

    static NormalWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NormalWindow), new FrameworkPropertyMetadata(typeof(NormalWindow)));
        }

        private const string ElementLeftSizeGrip = "PART_LeftSizeGrip";
        private const string ElementRightSizeGrip = "PART_RightSizeGrip";
        private const string ElementTopSizeGrip = "PART_TopSizeGrip";
        private const string ElementBottomSizeGrip = "PART_BottomSizeGrip";


        private const string ElementTopLeftSizeGrip = "PART_TopLeftSizeGrip";
        private const string ElementTopRightSizeGrip = "PART_TopRightSizeGrip";
        private const string ElementBottomLeftSizeGrip = "PART_BottomLeftSizeGrip";
        private const string ElementBottomRightSizeGrip = "PART_BottomRightSizeGrip";

        private const string ElementNormalWindowHeader = "PART_NormalWindowHeader";
        private const string ElementNormalWindowMinButton = "PART_NormalWindowMinButton";
        private const string ElementNormalWindowMaxButton = "PART_NormalWindowMaxButton";
        private const string ElementNormalWindowCloseButton = "PART_NormalWindowCloseButton";



        private Rectangle _leftSizeGrip;
        private Rectangle _rightSizeGrip;
        private Rectangle _topSizeGrip;
        private Rectangle _bottomSizeGrip;

        private Rectangle _topLeftSizeGrip;
        private Rectangle _topRightSizeGrip;
        private Rectangle _bottomLeftSizeGrip;
        private Rectangle _bottomRightSizeGrip;


      private Label _normalWindowHeader;
      private Button _normalWindowMinButton;
      private ToggleButton _normalWindowMaxButton;
      private Button _normalWindowCloseButton;



      public override void OnApplyTemplate()
      {
          base.OnApplyTemplate();

          _leftSizeGrip = (Rectangle) GetTemplateChild(ElementLeftSizeGrip);
          _rightSizeGrip = (Rectangle) GetTemplateChild(ElementRightSizeGrip);
          _topSizeGrip = (Rectangle) GetTemplateChild(ElementTopSizeGrip);
          _bottomSizeGrip = (Rectangle) GetTemplateChild(ElementBottomSizeGrip);
          _topLeftSizeGrip = (Rectangle) GetTemplateChild(ElementTopLeftSizeGrip);
          _topRightSizeGrip = (Rectangle) GetTemplateChild(ElementTopRightSizeGrip);
          _bottomLeftSizeGrip = (Rectangle) GetTemplateChild(ElementBottomLeftSizeGrip);
          _bottomRightSizeGrip = (Rectangle) GetTemplateChild(ElementBottomRightSizeGrip);
          InitBorderUiElement();
          _normalWindowHeader = (Label)GetTemplateChild(ElementNormalWindowHeader);
          _normalWindowMinButton = (Button) GetTemplateChild(ElementNormalWindowMinButton);
          _normalWindowMaxButton = (ToggleButton) GetTemplateChild(ElementNormalWindowMaxButton);
          _normalWindowCloseButton = (Button)GetTemplateChild(ElementNormalWindowCloseButton);

          InitNormalWindowElement();
      }

      private void InitBorderUiElement()
    {
        if(null == Wr)
            Wr = new Resizer(this);
        Wr.addResizerRight(_rightSizeGrip);
        Wr.addResizerLeft(_leftSizeGrip);
        Wr.addResizerUp(_topSizeGrip);
        Wr.addResizerDown(_bottomSizeGrip);
        Wr.addResizerLeftUp(_topLeftSizeGrip);
        Wr.addResizerRightUp(_topRightSizeGrip);
        Wr.addResizerLeftDown(_bottomLeftSizeGrip);
        Wr.addResizerRightDown(_bottomRightSizeGrip);
    }

      private void InitNormalWindowElement()
      {
          if (null == Wr)
              Wr = new Resizer(this);

          Wr.addWindowHeader(_normalWindowHeader);
          Wr.addWindowMinButton(_normalWindowMinButton);
          Wr.addWindowMaxButton(_normalWindowMaxButton);
          Wr.addWindowCloseButton(_normalWindowCloseButton);
      }

    }
}
