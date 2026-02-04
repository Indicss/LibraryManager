public class Book
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsBorrowed { get; set; }
    public DateTime? BorrowedAt { get; set; }

    public void Borrow()
    {
        IsBorrowed = true;
        BorrowedAt = DateTime.Now;
    }

    public void Return()
    {
        IsBorrowed = false;
        BorrowedAt = null;
    }

    public bool IsOverdue()
    {
        return IsBorrowed && BorrowedAt.HasValue &&
               (DateTime.Now - BorrowedAt.Value).Days > 14;
    }
}
