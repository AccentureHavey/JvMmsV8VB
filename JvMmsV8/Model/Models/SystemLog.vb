Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Logs")>
Public Class SystemLog
    <Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), ScaffoldColumn(False)>
    Public Property LogId() As Int32

    <Display(Name:="时间")>
    Public Property Time() As DateTime

    <Display(Name:="用户")>
    Public Property User() As User

    <Display(Name:="级别")>
    Public Property Level() As SystemLogLevel

    <Display(Name:="事件")>
    Public Property Objects() As SystemLogObject

    <Display(Name:="对象")>
    Public Property Events() As SystemLogEvent

    <Display(Name:="信息")>
    Public Property Text() As String

End Class