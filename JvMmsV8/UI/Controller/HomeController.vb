Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc


Namespace UI
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Home
        <Authorize(Roles:="管理员")>
        Function Index() As ActionResult
            Return View()
        End Function

        <Authorize(Roles:="财务")>
        Function Finaltial() As ActionResult
            Return View()
        End Function

        <Authorize(Roles:="采购")>
        Function Buyer() As ActionResult
            Return View()
        End Function

        <Authorize(Roles:="仓库")>
        Function Depots() As ActionResult
            Return View()
        End Function

        <Authorize(Roles:="模具")>
        Function Model() As ActionResult
            Return View()
        End Function

    End Class
End Namespace