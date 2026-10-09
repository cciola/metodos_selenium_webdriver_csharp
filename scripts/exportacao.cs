public bool VerificaArquivoBaixado(string nomeArquivo)
{
    bool existe = false;

    string pathUser = Environment.GetFolderPath(
        Environment.SpecialFolder.UserProfile
    );

    string pathDownload = Path.Combine(pathUser, @"Downloads\");

    File.Delete(pathDownload + nomeArquivo + ".pdf");

    IWebElement btnDownload = driver.FindElement(By.Id("idBotao"));
    btnDownload.Click();

    Thread.Sleep(1000);

    string[] filePaths = Directory.GetFiles(pathDownload);

    foreach (string p in filePaths)
    {
        if (p.Contains(nomeArquivo + ".pdf"))
        {
            existe = true;

            // Deleta o arquivo gerado
            File.Delete(pathDownload + nomeArquivo + ".pdf");

            break;
        }
    }

    if (existe == false)
    {
        driver.Quit();
    }

    return existe;
}