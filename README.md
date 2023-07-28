#About this game
The main content of this game is that the player guards a frontline position, where there are various buildings such as mines, barracks, factories, etc. The player’s income depends on airdrop supplies and minecarts to obtain resources.

#函数命名规则
Unity 代码的命名规范包括以下几点：
1. 类（class）、结构（struct）、枚举（enum）、标签（Attribute）名：静态、私有、保护、公有。单词首字母大写，比如：Main、CharacterController。
2. 接口（interface）名：静态、私有、保护、公有。首字符I开头，单词首字母大写，比如：IParse、IState。
3. 常量（const）：静态、私有、保护、公有。全体单词大写，单词与单词之间用_隔开，比如：NAME_GAME_OBJECT。
4. 变量（field）和属性（property）名：静态私有。首字符s_开头，后面单词首字母大写，比如：s_Transform、s_GameObject。私有、保护。首字符m_开头，后面单词首字母大写，比如：m_Transform、m_GameObject。其他。首字母小写，后面单词首字母大写，比如：transform、gameObject。
5. 委托（delegate）和事件（event）名：静态私有。首字符s_开头，后面单词首字母大写，比如：s_OnDownloadComplete。私有、保护。首字符m_开头，后面单词首字母大写，比如：m_OnDownloadComplete。其他。首单词on开头，后面单词首字母大写，比如：onDownloadComplete。
6. 函数名：静态、私有、保护、公有。单词首字母大写，比如：Update、OnGUI。
参考:为包命名 - Unity 手册. https://docs.unity.cn/cn/2019.4/Manual/cus-naming.html.