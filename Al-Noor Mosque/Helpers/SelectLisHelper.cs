public class SelectListHelper
{
    private readonly AppDbContext _context;

    public SelectListHelper(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<SelectListItem>> GetActivitiesSelectListAsync()
    {
        var activities = await _context.Activities.ToListAsync();
        return activities.Select(a => new SelectListItem
        {
            Value = a.Id.ToString(),
            Text = a.Name
        });
    }
}
