namespace Api.Models;

public class UserScore
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public int Score { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public UserScore(Guid userId, int score)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Score = score;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
