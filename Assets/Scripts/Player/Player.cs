
using System;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
//Player 类使用了 public 访问修饰符，这表示该类是公开的，可以被项目中的其他类访问
//拓展在 Unity 中，如果一个类需要作为组件挂载到游戏对象上，它通常需要是公开的
//其次，代码中的 : 符号表示继承关系Player 类继承自SingletonMonobehaviour<Player>
//旨在确保 Player 类在整个游戏运行期间只有一个实例存在

{
    // Movement Parameters-运动参数
    private float xInput;//浮点型变量，用于存储水平和垂直方向的输入值，常见于角色移动、相机控制或物体拖拽
    private float yInput;
    private bool isCarrying = false;//布尔型变量，初始值为false，用于标识角色是否正在携带物品
    private bool isIdle; //布尔型变量，用于判断角色是否处于空闲状态
    private bool isLiftingToolRight;
    private bool isLiftingToolLeft;
    private bool isLiftingToolUp;
    private bool isLiftingToolDown;
    private bool isRunning;
    private bool isUsingToolRight;
    private bool isUsingToolLeft;
    private bool isUsingToolUp;
    private bool isUsingToolDown;
    private bool isSwingingToolRight;
    private bool isSwingingToolLeft;
    private bool isSwingingToolUp;
    private bool isSwingingToolDown;
    private bool isWalking;
    private bool isPickingRight;
    private bool isPickingLeft;
    private bool isPickingUp;
    private bool isPickingDown;
    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidBody2D;//声明了一个 Rigidbody2D 类型的私有变量 rigidBody2D
    //具体作用如下：
    //组件引用：用于获取和存储游戏对象的 Rigidbody2D 组件引用
    //物理控制：通过该变量可以控制游戏对象的物理行为，如速度、重力、碰撞等
    //运动管理：能够施加力、扭矩，设置速度，实现基于物理的运动效果
    //碰撞检测：配合碰撞器组件实现物理碰撞响应

    private Direction playerDirection;//声明了一个名为 playerDirection的变量，其类型为Direction
    //用途：用于存储和表示游戏或应用程序中玩家角色的当前朝向或移动方向。
    //状态管理：通过改变这个变量的值，可以控制角色的朝向、移动逻辑或播放对应的动画。

    private float movementSpeed;

    private bool _playerInputIsDisabled=false;//playerInputIsDisabled 的私有bool，并将其初始值设为 false。
    //这个变量通常用于游戏开发中，作为一个"开关"来控制是否接收玩家的输入。当值为：false（默认）：允许玩家输入 true：禁止玩家输入

    public bool playerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }
    ////使用=>简化了传统的{ get { return ... } }写法
    //get => _playerInputIsDisabled;这是属性的 “读取” 功能，当其他脚本想检查玩家输入是否被禁用时就会执行这部分代码。
    //set => _playerInputIsDisabled = value;属性的 “写入” 功能，当其他脚本想改变玩家输入状态时就会执行这部分代码
    //value 是一个关键字，代表等号右边赋予的新值。所以这行的作用是：将接收到的新值 value 赋给私有字段 _playerInputIsDisabled。}
    protected override void Awake()//声明一个受保护的、重写的Awake方法
    {
        base.Awake();//调用父类的Awake方法，确保父类的初始化逻辑被执行

        rigidBody2D = GetComponent<Rigidbody2D>();
        //    获取当前游戏对象上的Rigidbody2D组件并赋值给rigidBody2D变量
    }

    private void Update()
    {
        #region Player Input 

        ResetAnimationTriggers();

        PlayerMovementInput();

        PlayerWalkInput();

        // Send event to any listeners for player movement input 将玩家移动输入事件发送给所有监听器 
        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
        isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
        isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
        isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
        isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
        false, false, false, false);

        #endregion
        //在视觉上将代码分割开来每一个region都有一个end region来标记其结束（区域region仅仅是允许折叠代码块）
    }

    private void FixedUpdate()//玩家在屏幕上的具体移动 并非动画效果
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        rigidBody2D.MovePosition(rigidBody2D.position + move);
    }




    private void ResetAnimationTriggers()//重置动画触发器-遍历所有动画触发器变量，并将它们初始化为false
    {
        isPickingRight = false;
        isPickingLeft = false;
        isPickingUp = false;
        isPickingDown = false;
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolDown = false;
        isLiftingToolRight = false;
        isLiftingToolLeft = false;
        isLiftingToolUp = false;
        isLiftingToolDown = false;
        isSwingingToolRight = false;
        isSwingingToolLeft = false;
        isSwingingToolUp = false;
        isSwingingToolDown = false;
        toolEffect = ToolEffect.none;//工具效果设置为无 确保触发器效果已经被重置
    }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        //斜着移动
        if (xInput != 0 && yInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        // 在移动
        if (xInput != 0 || yInput != 0)
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            // Capture player direction for save game记录玩家方向用于存档
            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if (yInput < 0)
            {
                playerDirection = Direction.down;
            }
            else
            {
                playerDirection = Direction.up;
            }

        }
        else if (xInput == 0 && yInput == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }


    }

    // 按住Shift键移动为walk
    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }


}
