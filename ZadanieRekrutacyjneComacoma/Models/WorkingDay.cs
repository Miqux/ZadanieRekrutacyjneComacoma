namespace ZadanieRekrutacyjneComacoma.Models
{
    public class WorkingDay
    {
        public string EmployeeCode { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan OutTime { get; set; }

        public override string ToString()
        {
            return $"Code = {EmployeeCode} Date = {Date.ToShortDateString()} EntryTyime = {EntryTime} OutTime = {OutTime}";
        }
    }
}
