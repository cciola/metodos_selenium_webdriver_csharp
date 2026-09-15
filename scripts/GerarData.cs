public DateTime GerarData()
{
    Random rnd = new Random();

    int ano = rnd.Next(1950, 2016);
    int mes = rnd.Next(1, 13);

    int ultimoDia =
        DateTime.DaysInMonth(ano, mes);

    int dia =
        rnd.Next(1, ultimoDia + 1);

    return new DateTime(ano, mes, dia);
}