@ModelType Model.LoginModel 
@Code
    ViewData("Title") = "Login"
End Code

<h2>Login</h2>
<section id="loginForm">
<h2>使用本地帐户登录。</h2>
@Using Html.BeginForm(New With { .ReturnUrl = ViewData("ReturnUrl") })
    @Html.AntiForgeryToken()
    

    @<fieldset>
        <legend>“登录”表单</legend>
        <ol>
            <li>  
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.Password)
                @Html.PasswordFor(Function(m) m.Password)
                @Html.ValidationMessageFor(Function(m) m.Password)
            </li>
            <li>
                @Html.CheckBoxFor(Function(m) m.RememberMe)
                @Html.LabelFor(Function(m) m.RememberMe, New With { .Class = "checkbox" })
            </li>
        </ol>
        <input type="submit" value="登录" />
        @Html.ValidationSummary(true)
    </fieldset>
    @<p>
        @Html.ActionLink("Register", "Register") (如果你没有帐户)。
    </p>
End Using
</section>



@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section


