# 面试常用算法 - C#实现

## 工具介绍
* 语言: C# 
* 平台: .Net Core (> 1.0.0)
* 开发工具: VisualStudio Code

## 运行方法: 

> 注: 确保机器上安装了.net core [传送门](https://www.microsoft.com/net/core#windowscmd)

1. 克隆本项目  `git clone git@github.com:zhaokuohaha/InterviewAlogorithm.git`
2. 进入项目 `cd InterviewAlogorithm`
3. 运行: `dotnet run`

## 开发方法

* **Template.cs** 项目模板, 按照该模板来编写代码, 其中:
    >* `print()` 为测试方法, 所有测试用例, 包括输出
    >* `_classname_()` 为算法主方法, 算法的主逻辑在这里实现
    >* 定义自己的私有方法来实现算法细节
    
* **Program.cs:** 项目总控制器, 需要测试某个算法(类), 在Main方法中创建该类对象, 然后执行print()方法即可.