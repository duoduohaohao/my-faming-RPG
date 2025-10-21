public enum ToolEffect//用于定义工具效果的枚举类型-该枚举被应用于角色动画系统的事件处理机制中，通过 EventHandler 类的委托参数传递工具效果信息，
                      //从而触发对应的动画状态这种设计模式实现了工具使用与动画播放的解耦，提高了代码的可维护性和扩展性

{
    none,
    watering

}

public enum Direction//用于表示方向的简单枚举类型。(Direction枚举是一个包含五个方向的简单枚举类型，通常用于表示基本的移动或导航方向。)
{
    up,
    down,
    left,
    right,
    none
}