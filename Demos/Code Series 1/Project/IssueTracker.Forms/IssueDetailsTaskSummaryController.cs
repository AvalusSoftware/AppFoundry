using AppFoundry.Forms;
using IssueTracker.Business;

namespace IssueTracker.Forms
{
    //Since these controllers are embedded in a details form the name is a concatenation of the parent form name and the summary form name. This makes it unique.
    public partial class IssueDetailsTaskSummaryController<BUSINESS_OBJECT>
    {
        protected override void EventCreateNewObject(SummaryCreateNewBusinessObjectArgs<Task> args)
        {
            //Now that tasks no longer have a public default constructor we need write some code to explicity create them.
            args.NewBusinessObject = new Task((Issue)ParentBusinessObject);
        }
    }
}
