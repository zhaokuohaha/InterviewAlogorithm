# 面试常用算法 - C#实现

## 工具介绍
* 语言: C# 
* 平台: .Net Core (> 2.0.0)
* 开发工具: VisualStudio Code

## 运行方法: 

> 注: 确保机器上安装了 .net core [传送门](https://www.microsoft.com/net/core#windowscmd)

    1. 克隆本项目  `git clone git@github.com:zhaokuohaha/InterviewAlogorithm.git`
    2. 进入项目 `cd InterviewAlogorithm`
    3. 运行: `dotnet run`

## 开发方法

* **ITemplate.cs** 项目模板接口, 按照该模板来编写代码, 其中:
    * `print()` 为测试方法, 所有测试用例, 包括输出
    * 定义自己的私有方法来实现算法细节
    
* **Program.cs:** 
    * 项目总控制器, 需要测试某个算法(类), 在Main方法中创建该类对象, 然后执行print()方法即可.

* **项目结构:**
    * Alogrithm: 经典算法
    * Common: 公共类型， 工具等
    * DataStructure: 经典数据结构
    * InterviewQuestion： 面试问题， 遇到便协商一个

* **开发步骤:**
    1. 新增一个类， 并实现 ITemplate, 实现算法细节， 在`print()`方法中运行测试
    2. 在`Program.cs` Main 方法中新增一行调用 print() 方法

* **调试:**
    * 直接运行 vscode 中的调试按钮
    * 如果调试报错， 请检查配置文件 `luanch.json` 中的的程序路径是否正确, 修改配置后重新运行即可
