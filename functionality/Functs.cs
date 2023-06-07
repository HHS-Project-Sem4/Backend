public static class Functionality
{
    public static double calcGrowth (double _old, double _new) 
    {
        var growth = (double) (_new - _old) / _old * 100;
        var val = (double) Math.Round(growth, 2);
        return Double.IsInfinity(val) ? 0 : val;
    }

    public static DateTime[] splitDates(string dateString)
    {
        var date = dateString.Replace("-","/");
        var dates = date.Split("X");
        var realDates = new DateTime[2];
        realDates[0] = DateTime.Parse(dates[0]);
        realDates[1] = DateTime.Parse(dates[1]);
        return realDates;
    }
}

