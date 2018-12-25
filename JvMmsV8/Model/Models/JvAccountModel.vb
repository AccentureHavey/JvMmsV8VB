Imports System.ComponentModel.DataAnnotations

Public Class LocalPasswordModel
    <DataType(DataType.Password)>
    <Display(Name:="当前密码")>
    <Required()>
    Public Property OldPassword() As String

    <StringLength(100, ErrorMessage:="", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="新密码")>
    <Required()>
    Public Property NewPassword() As String


    <DataType(DataType.Password)>
    <Display(Name:="确认密码")>
    <Compare("NewPassword", ErrorMessage:="新密码和确认密码不匹配。")>
    <Required()>
    Public Property ConfirmPassword() As String


End Class

Public Class LoginModel
    <Display(Name:="用户名")>
    Public Property UserName() As String
    <Display(Name:="密码")>
    Public Property Password() As String
    <Display(Name:="记住我？")>
    Public Property RememberMe() As Boolean

End Class

Public Class RegisterModel
    <Required()> _
    <Display(Name:="用户名")> _
    Public Property UserName As String

    <Required()> _
    <StringLength(100, ErrorMessage:="{0} 必须至少包含 {2} 个字符。", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(Name:="密码")> _
    Public Property Password As String

    <DataType(DataType.Password)> _
    <Display(Name:="确认密码")> _
    <Compare("Password", ErrorMessage:="密码和确认密码不匹配。")> _
    Public Property ConfirmPassword As String

    <Display(Name:="真实姓名")>
    <StringLength(20, MinimumLength:=2)>
    Public Property RealName As String
    <Display(Name:="用户角色")>
    Public Property UserRole As Int32

End Class
