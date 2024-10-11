namespace SD.pesel;

public class PersonId
{
    private readonly string _id;

    public PersonId(string Id)
    {
        _id = Id;
    }
    /// <summary>
    /// Get full year from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYear()
    {
        if (int.Parse(_id.Substring(2, 2)) > 12)
        {
            return 2000 + int.Parse(_id.Substring(0, 2));
        }
        else
        {
            return 1900 + int.Parse(_id.Substring(0, 2));
        }

    }

    /// <summary>
    /// Get month from PESEL
    /// </summary>
    public int GetMonth()
    {
        if (int.Parse(_id.Substring(2, 2)) > 12)
        {
            return int.Parse(_id.Substring(2, 2)) - 20;
        }

        return int.Parse(_id.Substring(2, 2));
    }

    /// <summary>
    /// Get day from PESEL
    /// </summary>
    /// <returns></returns>
    /// // 9307181235
    public int GetDay()
    {
        return int.Parse(_id.Substring(4, 2));
    }

    /// <summary>
    /// Get year of birth from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYearOfBirth()
    {
        return GetYear();
    }

    /// <summary>
    /// Get gender from PESEL
    /// </summary>
    /// <returns>m</returns>
    /// <returns>f</returns>
    public string GetGender()
    {
        string gender = int.Parse(_id.Substring(9, 1)) % 2 == 0 ? "k" : "m";
        return gender;
    }

    /// <summary>
    /// check if PESEL is valid
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        if (_id.Length != 11)
        {
            return false;
        }


        int peselIsCorrect = 0;
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        int temp = 0;
        for (int i = 0; i < 10; i++)
        {
            
            temp = weights[i] * int.Parse(_id[i].ToString());
            if (temp > 9)
            {
                temp %= 10;
            }
            peselIsCorrect += temp;

        }

        Console.WriteLine(10 - (peselIsCorrect % 10));

        return 10 - (peselIsCorrect % 10) == int.Parse(_id[10].ToString());

        // 44051401359




    }
}