namespace MeetDown.Core
{
    public class Result
    {
        public static Result Success() => new Result();
        public static Result Failure() => new Result();
        public bool IsSuccessful() => true;
    }
}