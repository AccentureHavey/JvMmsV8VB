Imports System.Globalization
Imports System.Threading
Public Class LocalizationAttribute
    Inherits ActionFilterAttribute
    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        If filterContext.RouteData.Values("lang") <> Nothing AndAlso String.IsNullOrWhiteSpace(filterContext.RouteData.Values("lang").ToString()) <> True Then
            Dim lang = filterContext.RouteData.Values("lang").ToString()
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang)
        Else
            Dim cookie = filterContext.HttpContext.Request.Cookies("ShaunXu.MvcLocalization.CurrentUICulture")
            Dim langHeader As String = Nothing
            If cookie IsNot Nothing Then
                langHeader = cookie.Value
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader)
            Else
                langHeader = filterContext.HttpContext.Request.UserLanguages(0)
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader)
            End If
            filterContext.RouteData.Values("lang") = langHeader
        End If

        Dim _cookie As HttpCookie = New HttpCookie("ShaunXu.MvcLocalization.CurrentUICulture", Thread.CurrentThread.CurrentUICulture.Name)
        _cookie.Expires = DateTime.Now.AddYears(1)
        filterContext.HttpContext.Response.SetCookie(_cookie)
        MyBase.OnActionExecuting(filterContext)
    End Sub


End Class
