using NUnit.Framework;
using Altom.AltDriver;
public class NewAltTest
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver =new AltDriver();
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
        // Поиск кнопки "Начало" + Клик по ней
        altDriver.LoadScene("MainMenu");
        System.Threading.Thread.Sleep(2000);
        var startButtonObject = altDriver.FindObject(By.NAME, "StartButton");
        // Проверка на существование
      
        Assert.NotNull(startButtonObject);
        Assert.AreEqual("StartButton", startButtonObject.name);
        altDriver.FindObject(By.NAME, "StartButton").Click();

        //Ожидаемая сцена после нажатия кнопки
        altDriver.WaitForCurrentSceneToBe("SampleScene");
        System.Threading.Thread.Sleep(2000);

        // Поиск кнопки ПАУЗЫ + проверка на существование + клик по ней
        var pauseButtonObject = altDriver.FindObject(By.NAME, "PauseButton");
        Assert.NotNull(pauseButtonObject);
        Assert.AreEqual("PauseButton", pauseButtonObject.name);
        altDriver.FindObject(By.NAME, "PauseButton").Click();
        System.Threading.Thread.Sleep(2000);

        // Поиск кнопки Меню + проверка на существование + клик по ней
        var mainMenuButtonObject = altDriver.FindObject(By.NAME, "MainMenuButton");
        Assert.NotNull(mainMenuButtonObject);
        Assert.AreEqual("MainMenuButton", mainMenuButtonObject.name);
        altDriver.FindObject(By.NAME, "MainMenuButton").Click();
        //Ожидаемая сцена MainMenu
        altDriver.WaitForCurrentSceneToBe("MainMenu");
        System.Threading.Thread.Sleep(2000);

        // Поиск кнопки Справка + проверка на существование + клик по ней
        var infoButtonObject = altDriver.FindObject(By.NAME, "InfoButton");
        Assert.NotNull(infoButtonObject);
        Assert.AreEqual("InfoButton", infoButtonObject.name);
        altDriver.FindObject(By.NAME, "InfoButton").Click();
        System.Threading.Thread.Sleep(2000);

        // Поиск кнопки ВОЗВРАТА В ГЛАВНОЕ МЕНЮ + проверка на существование + клик по ней
        var backToMainMenuButtonObject = altDriver.FindObject(By.NAME, "BackToMainMenuButton");
        Assert.NotNull(backToMainMenuButtonObject);
        Assert.AreEqual("BackToMainMenuButton", backToMainMenuButtonObject.name);
        altDriver.FindObject(By.NAME, "BackToMainMenuButton").Click();
        System.Threading.Thread.Sleep(2000);

        // Снова жмем начать
        altDriver.FindObject(By.NAME, "StartButton").Click();
        System.Threading.Thread.Sleep(2000);
        // Кнопка паузы
        altDriver.FindObject(By.NAME, "PauseButton").Click();
        System.Threading.Thread.Sleep(2000);
        // Кнопка продолжить
   
        var resumeButtonObject = altDriver.FindObject(By.NAME, "ResumeButton");
        Assert.NotNull(resumeButtonObject);
        Assert.AreEqual("ResumeButton", resumeButtonObject.name);
        altDriver.FindObject(By.NAME, "ResumeButton").Click();
        System.Threading.Thread.Sleep(2000);

        // Поиск кнопки Выбор пути + проверка на существование + клик по ней

        var selectWayButtonObject = altDriver.FindObject(By.NAME, "SelectWayButton");
        Assert.NotNull(selectWayButtonObject);
        Assert.AreEqual("SelectWayButton", selectWayButtonObject.name);
        altDriver.FindObject(By.NAME, "SelectWayButton").Click();
        System.Threading.Thread.Sleep(2000);

    }

}