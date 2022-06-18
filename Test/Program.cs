namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var workdays = NumberOfWorkdays(new DateOnly(2022, 1, 1), new DateOnly(2022, 2, 1));
            Console.WriteLine(workdays == 21 ? "Passed" : "Failed");
            workdays = NumberOfWorkdays(new DateOnly(2022, 1, 3), new DateOnly(2022, 1, 7));
            Console.WriteLine(workdays == 4 ? "Passed" : "Failed");
            workdays = NumberOfWorkdays(new DateOnly(2022, 1, 7), new DateOnly(2022, 1, 7));
            Console.WriteLine(workdays == 0 ? "Passed" : "Failed");
            workdays = NumberOfWorkdays(new DateOnly(2022, 1, 8), new DateOnly(2022, 1, 10));
            Console.WriteLine(workdays == 0 ? "Passed" : "Failed");
            try
            {
                NumberOfWorkdays(new DateOnly(2022, 1, 18), new DateOnly(2022, 1, 10));
                Console.WriteLine("Failed");
            }
            catch (Exception)
            {
                Console.WriteLine("Passed");
            }
        }


        /// <summary>
        /// This method should return the number of workdays (monday to friday) between the specified dates
        /// You do not need to take holidays into account.
        /// The start date is included in the range, the end date is excluded
        /// Using external libraries is not allowed.
        /// </summary>
        public static int NumberOfWorkdays(DateOnly start, DateOnly end)
        {
            start = RemoveWeekendFromTrailingAndEndingDate(start,WeekDateType.StartDate);
            end = RemoveWeekendFromTrailingAndEndingDate(end,WeekDateType.EndDate);
            int numberOfDays, numberOfweekendInBetween;
            int numberOfWeekDays=0;
            if (end.CompareTo(start)==1)
            {
                numberOfDays = end.DayNumber - start.DayNumber;
                numberOfweekendInBetween = Convert.ToInt32(Math.Floor(numberOfDays / 7.00))*2;
                numberOfWeekDays = numberOfDays - numberOfweekendInBetween;
            }
            //var numberOfdays = end - start;
           
            return numberOfWeekDays;
        }

        private static DateOnly RemoveWeekendFromTrailingAndEndingDate(DateOnly date , WeekDateType dateType)
        {
            
            if (date.DayOfWeek == DayOfWeek.Saturday && dateType== WeekDateType.StartDate)
            {
                date= date.AddDays(2);
            }               
            else if(date.DayOfWeek == DayOfWeek.Sunday && dateType == WeekDateType.StartDate)
            {
                date = date.AddDays(1);
            }
            if (date.DayOfWeek == DayOfWeek.Saturday && dateType == WeekDateType.EndDate)
            {
                date = date.AddDays(-1);
            }
            else if (date.DayOfWeek == DayOfWeek.Saturday && dateType == WeekDateType.EndDate)
            {
                date = date.AddDays(-2);
            }
            return date;
        }      
    }
}