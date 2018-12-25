Imports System


Public Class EnumTypes
    Public Enum RoleType
        <JvEnum(Name:="管理员")>
        admin
        <JvEnum(Name:="会计")>
        Accounter


    End Enum

    Public Enum AccountState
        <JvEnum(Name:="正常")>
        Normal = 0
        <JvEnum(Name:="失效")>
        Disable = 1
        <JvEnum(Name:="添加")>
        Insert = 10
        <JvEnum(Name:="更改")>
        Update = 20
        <JvEnum(Name:="删除")>
        Delete = 30

    End Enum


    Public Enum LogLevelType
        <JvEnum(Name:="严重")>
        Fatal = 1
        <JvEnum(Name:="错误")>
        Wrong = 1
        <JvEnum(Name:="警告")>
        Warning = 3
        <JvEnum(Name:="信息")>
        Info = 4
        <JvEnum(Name:="调试")>
        Debug = 5

    End Enum

    Public Enum LogEvenType
        <JvEnum(Name:="登入")>
        Login = 1
        <JvEnum(Name:="注销")>
        Logout
        <JvEnum(Name:="注册")>
        Register
        <JvEnum(Name:="添加")>
        Insert
        <JvEnum(Name:="更改")>
        Update
        <JvEnum(Name:="删除")>
        Delete
        <JvEnum(Name:="其他")>
        Other

    End Enum


End Class
