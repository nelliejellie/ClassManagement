namespace ClassManagement.Api.Helpers
{
    public static class Utils
    {
        public static bool IsOver21(DateTime? dateOfBirth)
        {
            // Check if the date of birth is null
            if (dateOfBirth == null)
            {
                return false;
            }

            int currentYear = DateTime.Now.Year;
            int birthYear = dateOfBirth.Value.Year;
            int age = currentYear - birthYear;

            // Check if the person is at least 21 years old
            if (age >= 21)
            {
                return true;
            }

            // Check if the person will turn 21 this year
            DateTime nextBirthday = dateOfBirth.Value.AddYears(21);
            if (nextBirthday.Year == currentYear)
            {
                return true;
            }
            return false;

        }

        public static bool IsOver22(DateTime? dateOfBirth)
        {
            // Check if the date of birth is null
            if (dateOfBirth == null)
            {
                return false;
            }

            int currentYear = DateTime.Now.Year;
            int birthYear = dateOfBirth.Value.Year;
            int age = currentYear - birthYear;

            // Check if the person is more than 22 years old
            if (age > 22)
            {
                return true;
            }

            // Check if the person will turn 22 this year
            DateTime nextBirthday = dateOfBirth.Value.AddYears(22);
            if (nextBirthday.Year == currentYear)
            {
                return true;
            }

            return false;
        }
    }
}
