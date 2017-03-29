using System.Collections.Generic;
using AppFoundry.Business.Core;
using AppFoundry.Core;

namespace IssueTracker.Business
{
    #region Generated Classes
    [BusinessObject("IssueTracker", "Issue")]
    public partial class Issue : BusinessObject
    {
        public static readonly StaticProperty PropertyCreatedByUserID = new StaticProperty("CreatedByUserID");
        public static readonly StaticProperty PropertyCreatedDate = new StaticProperty("CreatedDate");
        public static readonly StaticProperty PropertyDescription = new StaticProperty("Description");
        public static readonly StaticProperty PropertyIssueID = new StaticProperty("IssueID");
        public static readonly StaticProperty PropertyIssueNumber = new StaticProperty("IssueNumber");
        public static readonly StaticProperty PropertyIssueVersion = new StaticProperty("IssueVersion");
        public static readonly StaticRelationalProperty PropertyPriorityID = new StaticRelationalProperty("PriorityID");
        public static readonly StaticRelationalProperty PropertyStatusID = new StaticRelationalProperty("StatusID");
        public static readonly StaticProperty PropertyStepsToReproduce = new StaticProperty("StepsToReproduce");
        public static readonly StaticRelationalProperty PropertyTypeID = new StaticRelationalProperty("TypeID");
        public int CreatedByUserID
        {
            get
            {
                return ((int)GetValue(PropertyCreatedByUserID));
            }
            protected set
            {
                SetValue(PropertyCreatedByUserID, value);
            }
        }
        public int? CreatedByUserIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyCreatedByUserID));
            }
        }
        public User CreatedByUser
        {
            get
            {
                return ((User)GetValue(PropertyValueType.Object, PropertyCreatedByUserID));
            }
            protected set
            {
                if (!ReferenceEquals(value, null))
                {
                    CreatedByUserID = value.UserID;
                }
                else
                {
                    SetValue(PropertyCreatedByUserID, null);
                }
            }
        }
        public User CreatedByUserOriginalValue
        {
            get
            {
                return ((User)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyCreatedByUserID));
            }
        }
        public Date CreatedDate
        {
            get
            {
                return ((Date)GetValue(PropertyCreatedDate));
            }
            protected set
            {
                SetValue(PropertyCreatedDate, value);
            }
        }
        public Date? CreatedDateOriginalValue
        {
            get
            {
                return ((Date?)GetValue(PropertyValueVersion.Original, PropertyCreatedDate));
            }
        }
        public string Description
        {
            get
            {
                return ((string)GetValue(PropertyDescription));
            }
            set
            {
                SetValue(PropertyDescription, value);
            }
        }
        public string DescriptionOriginalValue
        {
            get
            {
                return ((string)GetValue(PropertyValueVersion.Original, PropertyDescription));
            }
        }
        public int IssueID
        {
            get
            {
                return ((int)GetValue(PropertyIssueID));
            }
        }
        public string IssueNumber
        {
            get
            {
                return ((string)GetValue(PropertyIssueNumber));
            }
            protected set
            {
                SetValue(PropertyIssueNumber, value);
            }
        }
        public string IssueNumberOriginalValue
        {
            get
            {
                return ((string)GetValue(PropertyValueVersion.Original, PropertyIssueNumber));
            }
        }
        public int IssueVersion
        {
            get
            {
                return ((int)GetValue(PropertyIssueVersion));
            }
        }
        public int PriorityID
        {
            get
            {
                return ((int)GetValue(PropertyPriorityID));
            }
            set
            {
                SetValue(PropertyPriorityID, value);
            }
        }
        public int? PriorityIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyPriorityID));
            }
        }
        public IssuePriority Priority
        {
            get
            {
                return ((IssuePriority)GetValue(PropertyValueType.Object, PropertyPriorityID));
            }
            set
            {
                if (!ReferenceEquals(value, null))
                {
                    PriorityID = value.IssuePriorityID;
                }
                else
                {
                    SetValue(PropertyPriorityID, null);
                }
            }
        }
        public IssuePriority PriorityOriginalValue
        {
            get
            {
                return ((IssuePriority)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyPriorityID));
            }
        }
        public int StatusID
        {
            get
            {
                return ((int)GetValue(PropertyStatusID));
            }
            protected set
            {
                SetValue(PropertyStatusID, value);
            }
        }
        public int? StatusIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyStatusID));
            }
        }
        public IssueStatus Status
        {
            get
            {
                return ((IssueStatus)GetValue(PropertyValueType.Object, PropertyStatusID));
            }
            protected set
            {
                if (!ReferenceEquals(value, null))
                {
                    StatusID = value.IssueStatusID;
                }
                else
                {
                    SetValue(PropertyStatusID, null);
                }
            }
        }
        public IssueStatus StatusOriginalValue
        {
            get
            {
                return ((IssueStatus)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyStatusID));
            }
        }
        public string StepsToReproduce
        {
            get
            {
                return ((string)GetValue(PropertyStepsToReproduce));
            }
            set
            {
                SetValue(PropertyStepsToReproduce, value);
            }
        }
        public string StepsToReproduceOriginalValue
        {
            get
            {
                return ((string)GetValue(PropertyValueVersion.Original, PropertyStepsToReproduce));
            }
        }
        public int TypeID
        {
            get
            {
                return ((int)GetValue(PropertyTypeID));
            }
            set
            {
                SetValue(PropertyTypeID, value);
            }
        }
        public int? TypeIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyTypeID));
            }
        }
        public IssueType Type
        {
            get
            {
                return ((IssueType)GetValue(PropertyValueType.Object, PropertyTypeID));
            }
            set
            {
                if (!ReferenceEquals(value, null))
                {
                    TypeID = value.IssueTypeID;
                }
                else
                {
                    SetValue(PropertyTypeID, null);
                }
            }
        }
        public IssueType TypeOriginalValue
        {
            get
            {
                return ((IssueType)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyTypeID));
            }
        }
        public static List<Issue> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<Issue>(filter, sortParameters));
        }
        public static List<Issue> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<Issue>(filter));
        }
        public static int Count()
        {
            return (Count(null));
        }
        public static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<Issue>());
        }
    }
    [BusinessObject("IssueTracker", "IssueDocument")]
    public partial class IssueDocument : UserDocument
    {
        public static readonly StaticProperty PropertyIssueDocumentID = new StaticProperty("IssueDocumentID");
        public static readonly StaticProperty PropertyIssueDocumentVersion = new StaticProperty("IssueDocumentVersion");
        public static readonly StaticProperty PropertyIssueID = new StaticProperty("IssueID");
        public int IssueDocumentID
        {
            get
            {
                return ((int)GetValue(PropertyIssueDocumentID));
            }
        }
        public int IssueDocumentVersion
        {
            get
            {
                return ((int)GetValue(PropertyIssueDocumentVersion));
            }
        }
        public int IssueID
        {
            get
            {
                return ((int)GetValue(PropertyIssueID));
            }
            protected set
            {
                SetValue(PropertyIssueID, value);
            }
        }
        public int? IssueIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyIssueID));
            }
        }
        public Issue Issue
        {
            get
            {
                return ((Issue)GetValue(PropertyValueType.Object, PropertyIssueID));
            }
            protected set
            {
                if (!ReferenceEquals(value, null))
                {
                    IssueID = value.IssueID;
                }
                else
                {
                    SetValue(PropertyIssueID, null);
                }
            }
        }
        public Issue IssueOriginalValue
        {
            get
            {
                return ((Issue)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyIssueID));
            }
        }
        public new static List<IssueDocument> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<IssueDocument>(filter, sortParameters));
        }
        public new static List<IssueDocument> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public new static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<IssueDocument>(filter));
        }
        public new static int Count()
        {
            return (Count(null));
        }
        public new static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<IssueDocument>());
        }
    }
    [BusinessObject("IssueTracker", "IssueHistory")]
    public partial class IssueHistory : BusinessObject
    {
        public static readonly StaticProperty PropertyChanges = new StaticProperty("Changes");
        public static readonly StaticProperty PropertyCreatedByUserID = new StaticProperty("CreatedByUserID");
        public static readonly StaticProperty PropertyCreatedDate = new StaticProperty("CreatedDate");
        public static readonly StaticProperty PropertyCreatedTime = new StaticProperty("CreatedTime");
        public static readonly StaticProperty PropertyIssueHistoryID = new StaticProperty("IssueHistoryID");
        public static readonly StaticProperty PropertyIssueHistoryVersion = new StaticProperty("IssueHistoryVersion");
        public static readonly StaticProperty PropertyIssueID = new StaticProperty("IssueID");
        public string Changes
        {
            get
            {
                return ((string)GetValue(PropertyChanges));
            }
            protected set
            {
                SetValue(PropertyChanges, value);
            }
        }
        public string ChangesOriginalValue
        {
            get
            {
                return ((string)GetValue(PropertyValueVersion.Original, PropertyChanges));
            }
        }
        public int CreatedByUserID
        {
            get
            {
                return ((int)GetValue(PropertyCreatedByUserID));
            }
            protected set
            {
                SetValue(PropertyCreatedByUserID, value);
            }
        }
        public int? CreatedByUserIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyCreatedByUserID));
            }
        }
        public User CreatedByUser
        {
            get
            {
                return ((User)GetValue(PropertyValueType.Object, PropertyCreatedByUserID));
            }
            protected set
            {
                if (!ReferenceEquals(value, null))
                {
                    CreatedByUserID = value.UserID;
                }
                else
                {
                    SetValue(PropertyCreatedByUserID, null);
                }
            }
        }
        public User CreatedByUserOriginalValue
        {
            get
            {
                return ((User)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyCreatedByUserID));
            }
        }
        public Date CreatedDate
        {
            get
            {
                return ((Date)GetValue(PropertyCreatedDate));
            }
            protected set
            {
                SetValue(PropertyCreatedDate, value);
            }
        }
        public Date? CreatedDateOriginalValue
        {
            get
            {
                return ((Date?)GetValue(PropertyValueVersion.Original, PropertyCreatedDate));
            }
        }
        public Time CreatedTime
        {
            get
            {
                return ((Time)GetValue(PropertyCreatedTime));
            }
            protected set
            {
                SetValue(PropertyCreatedTime, value);
            }
        }
        public Time? CreatedTimeOriginalValue
        {
            get
            {
                return ((Time?)GetValue(PropertyValueVersion.Original, PropertyCreatedTime));
            }
        }
        public int IssueHistoryID
        {
            get
            {
                return ((int)GetValue(PropertyIssueHistoryID));
            }
        }
        public int IssueHistoryVersion
        {
            get
            {
                return ((int)GetValue(PropertyIssueHistoryVersion));
            }
        }
        public int IssueID
        {
            get
            {
                return ((int)GetValue(PropertyIssueID));
            }
            protected set
            {
                SetValue(PropertyIssueID, value);
            }
        }
        public int? IssueIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyIssueID));
            }
        }
        public Issue Issue
        {
            get
            {
                return ((Issue)GetValue(PropertyValueType.Object, PropertyIssueID));
            }
            protected set
            {
                if (!ReferenceEquals(value, null))
                {
                    IssueID = value.IssueID;
                }
                else
                {
                    SetValue(PropertyIssueID, null);
                }
            }
        }
        public Issue IssueOriginalValue
        {
            get
            {
                return ((Issue)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyIssueID));
            }
        }
        public static List<IssueHistory> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<IssueHistory>(filter, sortParameters));
        }
        public static List<IssueHistory> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<IssueHistory>(filter));
        }
        public static int Count()
        {
            return (Count(null));
        }
        public static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<IssueHistory>());
        }
    }
    [BusinessObject("IssueTracker", "IssuePriority")]
    public partial class IssuePriority : Lookup
    {
        public static readonly StaticProperty PropertyIssuePriorityID = new StaticProperty("IssuePriorityID");
        public static readonly StaticProperty PropertyIssuePriorityVersion = new StaticProperty("IssuePriorityVersion");
        public int IssuePriorityID
        {
            get
            {
                return ((int)GetValue(PropertyIssuePriorityID));
            }
        }
        public int IssuePriorityVersion
        {
            get
            {
                return ((int)GetValue(PropertyIssuePriorityVersion));
            }
        }
        public new static List<IssuePriority> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<IssuePriority>(filter, sortParameters));
        }
        public new static List<IssuePriority> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public new static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<IssuePriority>(filter));
        }
        public new static int Count()
        {
            return (Count(null));
        }
        public new static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<IssuePriority>());
        }
    }
    [BusinessObject("IssueTracker", "IssueStatus")]
    public partial class IssueStatus : Lookup
    {
        public static readonly StaticProperty PropertyIssueStatusID = new StaticProperty("IssueStatusID");
        public static readonly StaticProperty PropertyIssueStatusVersion = new StaticProperty("IssueStatusVersion");
        public int IssueStatusID
        {
            get
            {
                return ((int)GetValue(PropertyIssueStatusID));
            }
        }
        public int IssueStatusVersion
        {
            get
            {
                return ((int)GetValue(PropertyIssueStatusVersion));
            }
        }
        public new static List<IssueStatus> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<IssueStatus>(filter, sortParameters));
        }
        public new static List<IssueStatus> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public new static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<IssueStatus>(filter));
        }
        public new static int Count()
        {
            return (Count(null));
        }
        public new static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<IssueStatus>());
        }
    }
    [BusinessObject("IssueTracker", "IssueType")]
    public partial class IssueType : Lookup
    {
        public static readonly StaticProperty PropertyIssueTypeID = new StaticProperty("IssueTypeID");
        public static readonly StaticProperty PropertyIssueTypeVersion = new StaticProperty("IssueTypeVersion");
        public int IssueTypeID
        {
            get
            {
                return ((int)GetValue(PropertyIssueTypeID));
            }
        }
        public int IssueTypeVersion
        {
            get
            {
                return ((int)GetValue(PropertyIssueTypeVersion));
            }
        }
        public new static List<IssueType> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<IssueType>(filter, sortParameters));
        }
        public new static List<IssueType> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public new static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<IssueType>(filter));
        }
        public new static int Count()
        {
            return (Count(null));
        }
        public new static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<IssueType>());
        }
    }
    [BusinessObject("IssueTracker", "Task")]
    public partial class Task : BusinessObject
    {
        public static readonly StaticProperty PropertyAssignedUserID = new StaticProperty("AssignedUserID");
        public static readonly StaticProperty PropertyCreatedDate = new StaticProperty("CreatedDate");
        public static readonly StaticProperty PropertyDescription = new StaticProperty("Description");
        public static readonly StaticProperty PropertyIssueID = new StaticProperty("IssueID");
        public static readonly StaticRelationalProperty PropertyStatusID = new StaticRelationalProperty("StatusID");
        public static readonly StaticProperty PropertyTaskID = new StaticProperty("TaskID");
        public static readonly StaticProperty PropertyTaskNumber = new StaticProperty("TaskNumber");
        public static readonly StaticProperty PropertyTaskVersion = new StaticProperty("TaskVersion");
        public int AssignedUserID
        {
            get
            {
                return ((int)GetValue(PropertyAssignedUserID));
            }
            set
            {
                SetValue(PropertyAssignedUserID, value);
            }
        }
        public int? AssignedUserIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyAssignedUserID));
            }
        }
        public User AssignedUser
        {
            get
            {
                return ((User)GetValue(PropertyValueType.Object, PropertyAssignedUserID));
            }
            set
            {
                if (!ReferenceEquals(value, null))
                {
                    AssignedUserID = value.UserID;
                }
                else
                {
                    SetValue(PropertyAssignedUserID, null);
                }
            }
        }
        public User AssignedUserOriginalValue
        {
            get
            {
                return ((User)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyAssignedUserID));
            }
        }
        public Date CreatedDate
        {
            get
            {
                return ((Date)GetValue(PropertyCreatedDate));
            }
            protected set
            {
                SetValue(PropertyCreatedDate, value);
            }
        }
        public Date? CreatedDateOriginalValue
        {
            get
            {
                return ((Date?)GetValue(PropertyValueVersion.Original, PropertyCreatedDate));
            }
        }
        public string Description
        {
            get
            {
                return ((string)GetValue(PropertyDescription));
            }
            set
            {
                SetValue(PropertyDescription, value);
            }
        }
        public string DescriptionOriginalValue
        {
            get
            {
                return ((string)GetValue(PropertyValueVersion.Original, PropertyDescription));
            }
        }
        public int IssueID
        {
            get
            {
                return ((int)GetValue(PropertyIssueID));
            }
            protected set
            {
                SetValue(PropertyIssueID, value);
            }
        }
        public int? IssueIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyIssueID));
            }
        }
        public Issue Issue
        {
            get
            {
                return ((Issue)GetValue(PropertyValueType.Object, PropertyIssueID));
            }
            protected set
            {
                if (!ReferenceEquals(value, null))
                {
                    IssueID = value.IssueID;
                }
                else
                {
                    SetValue(PropertyIssueID, null);
                }
            }
        }
        public Issue IssueOriginalValue
        {
            get
            {
                return ((Issue)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyIssueID));
            }
        }
        public int StatusID
        {
            get
            {
                return ((int)GetValue(PropertyStatusID));
            }
            set
            {
                SetValue(PropertyStatusID, value);
            }
        }
        public int? StatusIDOriginalValue
        {
            get
            {
                return ((int?)GetValue(PropertyValueVersion.Original, PropertyStatusID));
            }
        }
        public TaskStatus Status
        {
            get
            {
                return ((TaskStatus)GetValue(PropertyValueType.Object, PropertyStatusID));
            }
            set
            {
                if (!ReferenceEquals(value, null))
                {
                    StatusID = value.TaskStatusID;
                }
                else
                {
                    SetValue(PropertyStatusID, null);
                }
            }
        }
        public TaskStatus StatusOriginalValue
        {
            get
            {
                return ((TaskStatus)GetValue(PropertyValueType.Object, PropertyValueVersion.Original, PropertyStatusID));
            }
        }
        public int TaskID
        {
            get
            {
                return ((int)GetValue(PropertyTaskID));
            }
        }
        public string TaskNumber
        {
            get
            {
                return ((string)GetValue(PropertyTaskNumber));
            }
            protected set
            {
                SetValue(PropertyTaskNumber, value);
            }
        }
        public string TaskNumberOriginalValue
        {
            get
            {
                return ((string)GetValue(PropertyValueVersion.Original, PropertyTaskNumber));
            }
        }
        public int TaskVersion
        {
            get
            {
                return ((int)GetValue(PropertyTaskVersion));
            }
        }
        public static List<Task> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<Task>(filter, sortParameters));
        }
        public static List<Task> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<Task>(filter));
        }
        public static int Count()
        {
            return (Count(null));
        }
        public static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<Task>());
        }
    }
    [BusinessObject("IssueTracker", "TaskStatus")]
    public partial class TaskStatus : Lookup
    {
        public static readonly StaticProperty PropertyTaskStatusID = new StaticProperty("TaskStatusID");
        public static readonly StaticProperty PropertyTaskStatusVersion = new StaticProperty("TaskStatusVersion");
        public int TaskStatusID
        {
            get
            {
                return ((int)GetValue(PropertyTaskStatusID));
            }
        }
        public int TaskStatusVersion
        {
            get
            {
                return ((int)GetValue(PropertyTaskStatusVersion));
            }
        }
        public new static List<TaskStatus> Load(Filter filter, params SortParameter[] sortParameters)
        {
            return (BusinessObjectManager.Instance.Load<TaskStatus>(filter, sortParameters));
        }
        public new static List<TaskStatus> Load(params SortParameter[] sortParameters)
        {
            return (Load(null, sortParameters));
        }
        public new static int Count(Filter filter)
        {
            return (BusinessObjectManager.Instance.Count<TaskStatus>(filter));
        }
        public new static int Count()
        {
            return (Count(null));
        }
        public new static Query CreateQuery()
        {
            return (BusinessObjectManager.Instance.CreateQuery<TaskStatus>());
        }
    }
    #endregion



}
