namespace IssueTracker.Forms
{
    //Since these controllers are embedded in a details form the name is a concatenation of the parent form name and the summary form name. This makes it unique.
    public partial class IssueDetailsIssueHistorySummaryController<BUSINESS_OBJECT>
    {
        protected override void EventInitialize()
        {
            SetAddNewButtonVisibility(false);
            SetRemoveButtonVisibility(false);
        }
    }
}
