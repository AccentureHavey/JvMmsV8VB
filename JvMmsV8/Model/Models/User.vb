Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Us_Info")>
Public Class User
    <Key>
    Public Property UsId() As Int32
    <Display(Name:="账号")>
    Public Property UsName() As String
    <Display(Name:="真实姓名")>
    Public Property RealName() As String
    <Display(Name:="邮箱")>
    Public Property Email() As String
    <Display(Name:="部门")>
    Public Property Department() As Department
    <Display(Name:="状态")>
    Public Property State() As String
End Class