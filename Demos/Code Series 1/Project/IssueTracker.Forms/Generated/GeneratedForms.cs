using AppFoundry.Business.Core;
using AppFoundry.Forms;
using IssueTracker.Business;

namespace IssueTracker.Forms
{
    #region Generated Classes
    [FormController("IssueTracker", "IssueDetails")]
    public partial class IssueDetailsController<BUSINESS_OBJECT> : DetailsFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : Issue
    {
        [FormElement("ButtonCloseIssue")]
        private Button _ButtonCloseIssue;
        [FormElement("ButtonOpenIssue")]
        private Button _ButtonOpenIssue;
        [FormElement("Canvas1")]
        private Canvas _Canvas1;
        [FormElement("CanvasDetails")]
        private Canvas _CanvasDetails;
        [FormElement("CanvasStepsToReproduce")]
        private Canvas _CanvasStepsToReproduce;
        [FormElement("ComboBoxCreatedByUserID")]
        private BusinessObjectComboBoxControl<User> _ComboBoxCreatedByUserID;
        [FormElement("ComboBoxPriorityID")]
        private BusinessObjectComboBoxControl<IssuePriority> _ComboBoxPriorityID;
        [FormElement("ComboBoxStatusID")]
        private BusinessObjectComboBoxControl<IssueStatus> _ComboBoxStatusID;
        [FormElement("ComboBoxTypeID")]
        private BusinessObjectComboBoxControl<IssueType> _ComboBoxTypeID;
        [FormElement("DateCreatedDate")]
        private DateControl _DateCreatedDate;
        [FormElement("LabelCreatedByUserID")]
        private Label _LabelCreatedByUserID;
        [FormElement("LabelCreatedDate")]
        private Label _LabelCreatedDate;
        [FormElement("LabelDescription")]
        private Label _LabelDescription;
        [FormElement("LabelIssueNumber")]
        private Label _LabelIssueNumber;
        [FormElement("LabelPriorityID")]
        private Label _LabelPriorityID;
        [FormElement("LabelStatusID")]
        private Label _LabelStatusID;
        [FormElement("LabelStepsToReproduce")]
        private Label _LabelStepsToReproduce;
        [FormElement("LabelTypeID")]
        private Label _LabelTypeID;
        [FormElement("Panel1")]
        private Panel _Panel1;
        [FormElement("Panel2")]
        private Panel _Panel2;
        [FormElement("Panel3")]
        private Panel _Panel3;
        [FormElement("Panel4")]
        private Panel _Panel4;
        [FormElement("Panel5")]
        private Panel _Panel5;
        [FormElement("PanelCloseIssue")]
        private Panel _PanelCloseIssue;
        [FormElement("PanelOpenIssue")]
        private Panel _PanelOpenIssue;
        [FormElement("PanelStepsToReproduce")]
        private Panel _PanelStepsToReproduce;
        [FormElement("TabControl1")]
        private TabControl _TabControl1;
        [FormElement("TabPanel1")]
        private TabPanel _TabPanel1;
        [FormElement("TabPanel2")]
        private TabPanel _TabPanel2;
        [FormElement("TabPanel3")]
        private TabPanel _TabPanel3;
        [FormElement("TextDescription")]
        private TextControl _TextDescription;
        [FormElement("TextIssueNumber")]
        private TextControl _TextIssueNumber;
        [FormElement("TextStepsToReproduce")]
        private TextControl _TextStepsToReproduce;
        protected IssueDetailsTaskSummaryController TaskSummaryController
        {
            get
            {
                return ((IssueDetailsTaskSummaryController)ChildFormControllers["IssueDetailsTaskSummary"]);
            }
        }
        protected IssueDetailsIssueDocumentSummaryController IssueDocumentSummaryController
        {
            get
            {
                return ((IssueDetailsIssueDocumentSummaryController)ChildFormControllers["IssueDetailsIssueDocumentSummary"]);
            }
        }
        protected IssueDetailsIssueHistorySummaryController IssueHistorySummaryController
        {
            get
            {
                return ((IssueDetailsIssueHistorySummaryController)ChildFormControllers["IssueDetailsIssueHistorySummary"]);
            }
        }
    }
    [FormController("IssueTracker", "IssueDetails")]
    public class IssueDetailsController : IssueDetailsController<Issue>
    {
    }
    [FormController("IssueTracker", "IssueDetailsTaskSummary")]
    public partial class IssueDetailsTaskSummaryController<BUSINESS_OBJECT> : SummaryFormController<Task>
    {
        [FormElement("GridColumnAssignedUserID")]
        private GridBusinessObjectComboBoxColumn _GridColumnAssignedUserID;
        [FormElement("GridColumnCreatedDate")]
        private GridDateColumn _GridColumnCreatedDate;
        [FormElement("GridColumnDescription")]
        private GridTextColumn _GridColumnDescription;
        [FormElement("GridColumnStatusID")]
        private GridBusinessObjectComboBoxColumn _GridColumnStatusID;
        [FormElement("GridColumnTaskNumber")]
        private GridTextColumn _GridColumnTaskNumber;
    }
    [FormController("IssueTracker", "IssueDetailsTaskSummary")]
    public class IssueDetailsTaskSummaryController : IssueDetailsTaskSummaryController<Task>
    {
    }
    [FormController("IssueTracker", "IssueDetailsIssueDocumentSummary")]
    public partial class IssueDetailsIssueDocumentSummaryController<BUSINESS_OBJECT> : SummaryFormController<IssueDocument>
    {
        [FormElement("GridColumnAddedByID")]
        private GridBusinessObjectComboBoxColumn _GridColumnAddedByID;
        [FormElement("GridColumnAddedDate")]
        private GridDateColumn _GridColumnAddedDate;
        [FormElement("GridColumnAddedTime")]
        private GridTimeColumn _GridColumnAddedTime;
        [FormElement("GridColumnFileName")]
        private GridTextColumn _GridColumnFileName;
    }
    [FormController("IssueTracker", "IssueDetailsIssueDocumentSummary")]
    public class IssueDetailsIssueDocumentSummaryController : IssueDetailsIssueDocumentSummaryController<IssueDocument>
    {
    }
    [FormController("IssueTracker", "IssueDetailsIssueHistorySummary")]
    public partial class IssueDetailsIssueHistorySummaryController<BUSINESS_OBJECT> : SummaryFormController<IssueHistory>
    {
        [FormElement("GridColumnChanges")]
        private GridTextColumn _GridColumnChanges;
        [FormElement("GridColumnCreatedByUserID")]
        private GridBusinessObjectComboBoxColumn _GridColumnCreatedByUserID;
        [FormElement("GridColumnCreatedDate1")]
        private GridDateColumn _GridColumnCreatedDate1;
        [FormElement("GridColumnCreatedTime")]
        private GridTimeColumn _GridColumnCreatedTime;
    }
    [FormController("IssueTracker", "IssueDetailsIssueHistorySummary")]
    public class IssueDetailsIssueHistorySummaryController : IssueDetailsIssueHistorySummaryController<IssueHistory>
    {
    }
    [FormController("IssueTracker", "IssueSummary")]
    public partial class IssueSummaryController<BUSINESS_OBJECT> : SummaryFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : Issue
    {
        [FormElement("GridColumnCreatedByUserID")]
        private GridBusinessObjectComboBoxColumn _GridColumnCreatedByUserID;
        [FormElement("GridColumnCreatedDate")]
        private GridDateColumn _GridColumnCreatedDate;
        [FormElement("GridColumnDescription")]
        private GridTextColumn _GridColumnDescription;
        [FormElement("GridColumnIssueNumber")]
        private GridTextColumn _GridColumnIssueNumber;
        [FormElement("GridColumnPriorityID")]
        private GridBusinessObjectComboBoxColumn _GridColumnPriorityID;
        [FormElement("GridColumnStatusID")]
        private GridBusinessObjectComboBoxColumn _GridColumnStatusID;
        [FormElement("GridColumnTypeID")]
        private GridBusinessObjectComboBoxColumn _GridColumnTypeID;
    }
    [FormController("IssueTracker", "IssueSummary")]
    public class IssueSummaryController : IssueSummaryController<Issue>
    {
    }
    [FormController("IssueTracker", "IssueSearchParameters")]
    public partial class IssueSearchParametersController<BUSINESS_OBJECT> : SearchParametersFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : Issue
    {
        [FormElement("ComboBoxPriorityID")]
        private BusinessObjectComboBoxControl<IssuePriority> _ComboBoxPriorityID;
        [FormElement("ComboBoxStatusID")]
        private BusinessObjectComboBoxControl<IssueStatus> _ComboBoxStatusID;
        [FormElement("ComboBoxTypeID")]
        private BusinessObjectComboBoxControl<IssueType> _ComboBoxTypeID;
        [FormElement("LabelDescription")]
        private Label _LabelDescription;
        [FormElement("LabelIssueNumber")]
        private Label _LabelIssueNumber;
        [FormElement("LabelPriorityID")]
        private Label _LabelPriorityID;
        [FormElement("LabelStatusID")]
        private Label _LabelStatusID;
        [FormElement("LabelTypeID")]
        private Label _LabelTypeID;
        [FormElement("TextDescription")]
        private TextControl _TextDescription;
        [FormElement("TextIssueNumber")]
        private TextControl _TextIssueNumber;
    }
    [FormController("IssueTracker", "IssueSearchParameters")]
    public class IssueSearchParametersController : IssueSearchParametersController<Issue>
    {
    }
    [FormController("IssueTracker", "TaskDetails")]
    public partial class TaskDetailsController<BUSINESS_OBJECT> : DetailsFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : Task
    {
        [FormElement("CanvasDetails")]
        private Canvas _CanvasDetails;
        [FormElement("ComboBoxAssignedUserID")]
        private BusinessObjectComboBoxControl<User> _ComboBoxAssignedUserID;
        [FormElement("ComboBoxStatusID")]
        private BusinessObjectComboBoxControl<TaskStatus> _ComboBoxStatusID;
        [FormElement("DateCreatedDate")]
        private DateControl _DateCreatedDate;
        [FormElement("LabelAssignedUserID")]
        private Label _LabelAssignedUserID;
        [FormElement("LabelCreatedDate")]
        private Label _LabelCreatedDate;
        [FormElement("LabelDescription")]
        private Label _LabelDescription;
        [FormElement("LabelStatusID")]
        private Label _LabelStatusID;
        [FormElement("LabelTaskNumber")]
        private Label _LabelTaskNumber;
        [FormElement("TextDescription")]
        private TextControl _TextDescription;
        [FormElement("TextTaskNumber")]
        private TextControl _TextTaskNumber;
    }
    [FormController("IssueTracker", "TaskDetails")]
    public class TaskDetailsController : TaskDetailsController<Task>
    {
    }
    [FormController("IssueTracker", "TaskSummary")]
    public partial class TaskSummaryController<BUSINESS_OBJECT> : SummaryFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : Task
    {
        [FormElement("GridColumnAssignedUserID")]
        private GridBusinessObjectComboBoxColumn _GridColumnAssignedUserID;
        [FormElement("GridColumnCreatedDate")]
        private GridDateColumn _GridColumnCreatedDate;
        [FormElement("GridColumnDescription")]
        private GridTextColumn _GridColumnDescription;
        [FormElement("GridColumnStatusID")]
        private GridBusinessObjectComboBoxColumn _GridColumnStatusID;
        [FormElement("GridColumnTaskNumber")]
        private GridTextColumn _GridColumnTaskNumber;
    }
    [FormController("IssueTracker", "TaskSummary")]
    public class TaskSummaryController : TaskSummaryController<Task>
    {
    }
    [FormController("IssueTracker", "TaskSearchParameters")]
    public partial class TaskSearchParametersController<BUSINESS_OBJECT> : SearchParametersFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : Task
    {
        [FormElement("ComboBoxStatusID")]
        private BusinessObjectComboBoxControl<TaskStatus> _ComboBoxStatusID;
        [FormElement("LabelDescription")]
        private Label _LabelDescription;
        [FormElement("LabelStatusID")]
        private Label _LabelStatusID;
        [FormElement("LabelTaskNumber")]
        private Label _LabelTaskNumber;
        [FormElement("TextDescription")]
        private TextControl _TextDescription;
        [FormElement("TextTaskNumber")]
        private TextControl _TextTaskNumber;
    }
    [FormController("IssueTracker", "TaskSearchParameters")]
    public class TaskSearchParametersController : TaskSearchParametersController<Task>
    {
    }
    [FormController("IssueTracker", "IssueHistoryDetails")]
    public partial class IssueHistoryDetailsController<BUSINESS_OBJECT> : DetailsFormController<BUSINESS_OBJECT> where BUSINESS_OBJECT : IssueHistory
    {
        [FormElement("CanvasDetails")]
        private Canvas _CanvasDetails;
        [FormElement("ComboBoxCreatedByUserID")]
        private BusinessObjectComboBoxControl<User> _ComboBoxCreatedByUserID;
        [FormElement("DateCreatedDate")]
        private DateControl _DateCreatedDate;
        [FormElement("LabelChanges")]
        private Label _LabelChanges;
        [FormElement("LabelCreatedByUserID")]
        private Label _LabelCreatedByUserID;
        [FormElement("LabelCreatedDate")]
        private Label _LabelCreatedDate;
        [FormElement("LabelCreatedTime")]
        private Label _LabelCreatedTime;
        [FormElement("TextChanges")]
        private TextControl _TextChanges;
        [FormElement("TimeCreatedTime")]
        private TimeControl _TimeCreatedTime;
    }
    [FormController("IssueTracker", "IssueHistoryDetails")]
    public class IssueHistoryDetailsController : IssueHistoryDetailsController<IssueHistory>
    {
    }
    #endregion


}
