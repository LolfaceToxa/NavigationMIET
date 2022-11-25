using NUnit.Framework;
using Altom.AltDriver;
public class NewAltTest
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();

    }

    [Test]
    public void TestStartButtonLoadsMainScene()
    {
        // ����� ������ "������" + ���� �� ���
        altDriver.LoadScene("MainMenu");
        System.Threading.Thread.Sleep(1500);
        var startButtonObject = altDriver.FindObject(By.NAME, "StartButton");
        // �������� �� �������������

        Assert.NotNull(startButtonObject);
        Assert.AreEqual("StartButton", startButtonObject.name);
        altDriver.FindObject(By.NAME, "StartButton").Click();

        //��������� ����� ����� ������� ������
        altDriver.WaitForCurrentSceneToBe("SampleScene");
        System.Threading.Thread.Sleep(1500);

        // ����� ������ ����� + �������� �� ������������� + ���� �� ���
        var pauseButtonObject = altDriver.FindObject(By.NAME, "PauseButton");
        Assert.NotNull(pauseButtonObject);
        Assert.AreEqual("PauseButton", pauseButtonObject.name);
        altDriver.FindObject(By.NAME, "PauseButton").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ ���� + �������� �� ������������� + ���� �� ���
        var mainMenuButtonObject = altDriver.FindObject(By.NAME, "MainMenuButton");
        Assert.NotNull(mainMenuButtonObject);
        Assert.AreEqual("MainMenuButton", mainMenuButtonObject.name);
        altDriver.FindObject(By.NAME, "MainMenuButton").Click();
        //��������� ����� MainMenu
        altDriver.WaitForCurrentSceneToBe("MainMenu");
        System.Threading.Thread.Sleep(1500);

        // ����� ������ ������� + �������� �� ������������� + ���� �� ���
        var infoButtonObject = altDriver.FindObject(By.NAME, "InfoButton");
        Assert.NotNull(infoButtonObject);
        Assert.AreEqual("InfoButton", infoButtonObject.name);
        altDriver.FindObject(By.NAME, "InfoButton").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ �������� � ������� ���� + �������� �� ������������� + ���� �� ���
        var backToMainMenuButtonObject = altDriver.FindObject(By.NAME, "BackToMainMenuButton");
        Assert.NotNull(backToMainMenuButtonObject);
        Assert.AreEqual("BackToMainMenuButton", backToMainMenuButtonObject.name);
        altDriver.FindObject(By.NAME, "BackToMainMenuButton").Click();
        System.Threading.Thread.Sleep(1500);
        // ����� ���� ������
        altDriver.FindObject(By.NAME, "StartButton").Click();
        System.Threading.Thread.Sleep(1500);
        // ������ �����
        altDriver.FindObject(By.NAME, "PauseButton").Click();
        System.Threading.Thread.Sleep(1500);
        // ������ ����������

        var resumeButtonObject = altDriver.FindObject(By.NAME, "ResumeButton");
        Assert.NotNull(resumeButtonObject);
        Assert.AreEqual("ResumeButton", resumeButtonObject.name);
        altDriver.FindObject(By.NAME, "ResumeButton").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ ����� ���� + �������� �� ������������� + ���� �� ���

        var selectWayButtonObject = altDriver.FindObject(By.NAME, "SelectWayButton");
        Assert.NotNull(selectWayButtonObject);
        Assert.AreEqual("SelectWayButton", selectWayButtonObject.name);
        altDriver.FindObject(By.NAME, "SelectWayButton").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ ����� + �������� �� ������������� + ���� �� ���

        var backFromSelectWayButtonObject = altDriver.FindObject(By.NAME, "Button");
        Assert.NotNull(backFromSelectWayButtonObject);
        Assert.AreEqual("Button", backFromSelectWayButtonObject.name);
        altDriver.FindObject(By.NAME, "Button").Click();
        System.Threading.Thread.Sleep(1500);


        // ����� ������ ����� ���� + ���� �� ���
        altDriver.FindObject(By.NAME, "SelectWayButton").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ �� �������� ��� ������ ��������� + �������� �� ������������� + ���� �� ���

        var ArrowBtnObject = altDriver.FindObject(By.NAME, "ArrowBtn");
        Assert.NotNull(ArrowBtnObject);
        Assert.AreEqual("ArrowBtn", ArrowBtnObject.name);
        altDriver.FindObject(By.NAME, "ArrowBtn").Click();
        System.Threading.Thread.Sleep(1500);



        // ����� ������ � ����������  + �������� �� ������������� + ���� �� ���

        var placeObject = altDriver.FindObject(By.NAME, "Item 0 3112");
        Assert.NotNull(placeObject);
        Assert.AreEqual("Item 0 3112", placeObject.name);
        altDriver.FindObject(By.NAME, "Item 0 3112").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ ��������� � ������  + �������� �� ������������� + ���� �� ���
        var backToChoiceObject = altDriver.FindObject(By.NAME, "NoButton");
        Assert.NotNull(backToChoiceObject);
        Assert.AreEqual("NoButton", backToChoiceObject.name);
        altDriver.FindObject(By.NAME, "NoButton").Click();
        System.Threading.Thread.Sleep(1500);
      // altDriver.FindObject(By.NAME, "Text1");
      // altDriver.PressKey(AltKeyCode.Clear, 1f);

        // ������� + ��������� 3120
        altDriver.FindObject(By.NAME, "ArrowBtn").Click();
        System.Threading.Thread.Sleep(1500);

        altDriver.FindObject(By.NAME, "Item 0 3112").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ �� + �������� �� ������������� + ���� �� ���
        var nextChoiceObject = altDriver.FindObject(By.NAME, "YesButton");
        Assert.NotNull(nextChoiceObject);
        Assert.AreEqual("YesButton", nextChoiceObject.name);
        altDriver.FindObject(By.NAME, "YesButton").Click();
        System.Threading.Thread.Sleep(1500);

        // ����� ������ �� �������� ��� ������ ��������� + �������� �� ������������� + ���� �� ���

     
        altDriver.FindObject(By.NAME, "ArrowBtn").Click();
        System.Threading.Thread.Sleep(1500);



        // ����� ������ � ����������  + �������� �� ������������� + ���� �� ���

    
        altDriver.FindObject(By.NAME, "Item 1 3120").Click();
        System.Threading.Thread.Sleep(1500);

        altDriver.FindObject(By.NAME, "YesButton2").Click();
        System.Threading.Thread.Sleep(1500);

        altDriver.FindObject(By.NAME, "PauseButton").Click();
        System.Threading.Thread.Sleep(1500);

        altDriver.FindObject(By.NAME, "MainMenuButton").Click();
        //��������� ����� MainMenu
        altDriver.WaitForCurrentSceneToBe("MainMenu");
        System.Threading.Thread.Sleep(1500);

        var exitButtonObject = altDriver.FindObject(By.NAME, "ExitButton");
        Assert.NotNull(exitButtonObject);
        Assert.AreEqual("ExitButton", exitButtonObject.name);
        altDriver.FindObject(By.NAME, "ExitButton").Click();
        System.Threading.Thread.Sleep(1500);





    }

}