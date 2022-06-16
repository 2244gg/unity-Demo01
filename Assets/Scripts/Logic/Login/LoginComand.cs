using FrameworkDesign;
public enum ELoginBtnAction { None, Login, Register, Visitor ,Exit ,EnterGame}
public struct S_LoginBtnAction {
    public ELoginBtnAction btnAction;
}

//×¢²á
public class LoginRegisterInfoCommand : AbstractCommand
{
    private RegisterData registerData;
    public LoginRegisterInfoCommand(RegisterData registerData)
    {
        this.registerData = registerData;
    }
    protected override void OnExecute()
    {
        LoginModel model = (LoginModel)this.GetModel<ILoginModel>();
        model.SetRegisterInfo(this.registerData);
       // model.RegisterReq();
        //int a = model.userGender.Value;
        LogTool.Print(this, "OnExecute");
    }
}
// µÇÂ¼
public class LoginPeqInfoCommand : AbstractCommand
{
    private LoginData loginData;
    public LoginPeqInfoCommand(LoginData loginData)
    {
        this.loginData = loginData;
    }
    protected override void OnExecute()
    {
        LoginModel model = (LoginModel)this.GetModel<ILoginModel>();
        model.SetLoginInfo(this.loginData);
       // model.LoginReq();
        //int a = model.userGender.Value;
        LogTool.Print(this, "OnExecute");
    }
}