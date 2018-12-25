Imports System.Runtime.InteropServices.WindowsRuntime
Imports Model
Imports BLL
Imports WebMatrix.WebData
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth

Namespace UI

    <Authorize()>
    <InitializeSimpleMembership()>
    Public Class AccountController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Account

        Function Index() As ActionResult
            Return View()
        End Function



        <AllowAnonymous>
        Public Function Login(returnUrl As String) As ActionResult
            If (Request.IsAuthenticated) Then
                Return RedirectToAction("Index", "Home")
            End If
            ViewBag.ReturnUrl = returnUrl
            Return View()

        End Function

        <HttpPost>
        <AllowAnonymous()>
        <ValidateAntiForgeryToken()>
        Function Login(model As LoginModel, returnUrl As String) As ActionResult
            If ModelState.IsValid Then
                Dim db = New JvDBContext()
                Dim uc = db.Users.Count(Function(a) a.UsName = model.UserName AndAlso a.State = EnumTypes.AccountState.Normal)
                If uc = 0 Then
                    ModelState.AddModelError("UsName", ErrorCodeToString(MembershipCreateStatus.InvalidUserName))
                ElseIf WebSecurity.Login(model.UserName, model.Password, persistCookie:=model.RememberMe) Then
                    LogHelper.Log(db, model.UserName, EnumTypes.LogLevelType.Info, EnumTypes.LogEvenType.Login, "")
                    Return RedirectToLocal(returnUrl)
                End If

            End If
            ModelState.AddModelError("", "提供的用户名或密码不正确")
            Return View()

        End Function

        <AllowAnonymous()>
        Public Function Register() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        <AllowAnonymous()>
        <ValidateAntiForgeryToken()>
        Public Function Register(ByVal model As RegisterModel) As ActionResult
            If ModelState.IsValid Then
                Try
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password)
                    WebSecurity.Login(model.UserName, model.Password)
                    Return RedirectToAction("Index", "Home")
                Catch ex As MembershipCreateUserException
                    ModelState.AddModelError("", ErrorCodeToString(ex.StatusCode))
                End Try
            End If
            Return View(model)
        End Function

        Private Function RedirectToLocal(retrunUrl As String) As ActionResult
            If Url.IsLocalUrl(retrunUrl) Then
                Return Redirect(retrunUrl)
            Else
                Return RedirectToAction("Index ", "Home ")
            End If
        End Function


        Private Function ErrorCodeToString(createStatus As MembershipCreateStatus) As String
            Select Case createStatus
                Case MembershipCreateStatus.DuplicateUserName
                    Return "用户名已存在。请输入其他用户名。"
                Case MembershipCreateStatus.DuplicateEmail
                    Return "该电子邮件地址的用户名已存在。请输入其他电子邮件地址。"
                Case MembershipCreateStatus.InvalidPassword
                    Return "提供的密码无效。请输入有效的密码值。"
                Case MembershipCreateStatus.InvalidEmail
                    Return "提供的电子邮件地址无效。请检查该值并重试。"
                Case MembershipCreateStatus.InvalidAnswer
                    Return "提供的密码取回答案无效。请检查该值并重试。"
                Case MembershipCreateStatus.InvalidQuestion
                    Return "提供的密码取回问题无效。请检查该值并重试。"
                Case MembershipCreateStatus.InvalidUserName
                    Return "提供的用户名无效。请检查该值并重试。"
                Case MembershipCreateStatus.ProviderError
                    Return "身份验证提供程序返回了错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。"
                Case MembershipCreateStatus.UserRejected
                    Return "已取消用户创建请求。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。"
            End Select
            Return "发生未知错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。"
        End Function

    End Class
End Namespace