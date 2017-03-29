using AppFoundry.Forms;
using IssueTracker.Business;

namespace IssueTracker.Forms
{
    //Since these controllers are embedded in a details form the name is a concatenation of the parent form name and the summary form name. This makes it unique.
    public partial class IssueDetailsIssueDocumentSummaryController<BUSINESS_OBJECT>
    {
        /// <summary>
        /// This event gets called when the summary control is trying to build a new object.
        /// </summary>
        protected override void EventCreateNewObject(SummaryCreateNewBusinessObjectArgs<IssueDocument> args)
        {
            //Now that issue documents no longer have a public default constructor we need write some code to explicity create them.
            args.NewBusinessObject = new IssueDocument((Issue)ParentBusinessObject);
        }
    }
}
