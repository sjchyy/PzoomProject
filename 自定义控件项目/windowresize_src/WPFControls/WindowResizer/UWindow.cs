using System.Windows;
using System.Windows.Shapes;

namespace UserWindow
{

[TemplatePart(Name=UWindow.ElementLeftSizeGrip,Type = typeof(UWindow))]

    public  class UWindow :Window
{
    public Resizer Wr { get; private set; }

    public UWindow()
    {
       Wr = new Resizer(this);
       TaskShow.RepairWpfWindowFullScreenBehavior(this);
    }

        static UWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UWindow), new FrameworkPropertyMetadata(typeof(UWindow)));
        }

        private const string ElementLeftSizeGrip = "PART_LeftSizeGrip";
        private const string ElementRightSizeGrip = "PART_RightSizeGrip";
        private const string ElementTopSizeGrip = "PART_TopSizeGrip";
        private const string ElementBottomSizeGrip = "PART_BottomSizeGrip";


        private const string ElementTopLeftSizeGrip = "PART_TopLeftSizeGrip";
        private const string ElementTopRightSizeGrip = "PART_TopRightSizeGrip";
        private const string ElementBottomLeftSizeGrip = "PART_BottomLeftSizeGrip";
        private const string ElementBottomRightSizeGrip = "PART_BottomRightSizeGrip";


        private Rectangle _leftSizeGrip;
        private Rectangle _rightSizeGrip;
        private Rectangle _topSizeGrip;
        private Rectangle _bottomSizeGrip;

        private Rectangle _topLeftSizeGrip;
        private Rectangle _topRightSizeGrip;
        private Rectangle _bottomLeftSizeGrip;
        private Rectangle _bottomRightSizeGrip;


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _leftSizeGrip = (Rectangle)GetTemplateChild(ElementLeftSizeGrip);
            _rightSizeGrip = (Rectangle)GetTemplateChild(ElementRightSizeGrip);
            _topSizeGrip = (Rectangle)GetTemplateChild(ElementTopSizeGrip);
            _bottomSizeGrip = (Rectangle)GetTemplateChild(ElementBottomSizeGrip);
            _topLeftSizeGrip = (Rectangle)GetTemplateChild(ElementTopLeftSizeGrip);
            _topRightSizeGrip = (Rectangle)GetTemplateChild(ElementTopRightSizeGrip);
            _bottomLeftSizeGrip = (Rectangle)GetTemplateChild(ElementBottomLeftSizeGrip);
            _bottomRightSizeGrip = (Rectangle)GetTemplateChild(ElementBottomRightSizeGrip);
            InitBorderUiElement();

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
    }
}
