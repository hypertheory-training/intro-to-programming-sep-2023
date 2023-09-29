namespace BusinessClockApi.Models;

public record ClockResponse
{
    public bool Open { get; init; }
    public DateTime? OpensNext { get; init; } = null;
    public string SecretMessage { get; } = "Jeff Was Here";

    public static ClockResponse CreateOpen() => new ClockResponse { Open = true };
    public static ClockResponse CreateClosed(DateTime whenOpen) => new ClockResponse { Open = false, OpensNext = whenOpen };
}