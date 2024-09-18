namespace TrophyLibrary
{
    public class Trophy
    {
        public int Id { get; set; }
        public string? Competition { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Id} {Competition} {Year}";

        }

        public void ValidateYear()
        {
            if (Year <= 1970 || Year >= 2024)
            {
                throw new ArgumentOutOfRangeException(nameof(Year), "Year must be between 1970 and 2024");
            }
        }
        public void ValidateCompetition()
        {

            if (Competition == null)
            {
                throw new ArgumentNullException(nameof(Competition), "Title cannot be null");
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentException("Competition name must be at least 3 characters", nameof(Competition));
            }
        }
        public void Validate()
        {
            ValidateYear();
            ValidateCompetition();
        }
    }
}
