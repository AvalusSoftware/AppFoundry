using System.Collections.Generic;

namespace IssueTracker.Business.Enums
{
    #region Generated Enumeration Helpers

    public enum IssuePriorityEnum
    {
        High,
        Low,
        Medium
    }

    public static class IssuePriorityEnums
    {
        private static readonly object _Lock = new object();
        public const string CODE_HIGH = "High";
        public const string CODE_LOW = "Low";
        public const string CODE_MEDIUM = "Medium";
        private static Dictionary<IssuePriority, IssuePriorityEnum> _EnumerationByIssuePriority;
        private static List<IssuePriority> _IssuePriorityByEnumeration;
        public static IssuePriority High
        {
            get
            {
                FillEnumerationMappings();
                return (_IssuePriorityByEnumeration[(int)IssuePriorityEnum.High]);
            }
        }
        public static IssuePriority Low
        {
            get
            {
                FillEnumerationMappings();
                return (_IssuePriorityByEnumeration[(int)IssuePriorityEnum.Low]);
            }
        }
        public static IssuePriority Medium
        {
            get
            {
                FillEnumerationMappings();
                return (_IssuePriorityByEnumeration[(int)IssuePriorityEnum.Medium]);
            }
        }
        public static IssuePriority Load(IssuePriorityEnum enumeration)
        {
            FillEnumerationMappings();
            return (_IssuePriorityByEnumeration[(int)enumeration]);
        }
        public static IssuePriorityEnum ToEnum(this IssuePriority value)
        {
            FillEnumerationMappings();
            return (_EnumerationByIssuePriority[value]);
        }
        private static void FillEnumerationMappings()
        {
            lock (_Lock)
            {
                if (_EnumerationByIssuePriority == null)
                {
                    _EnumerationByIssuePriority = new Dictionary<IssuePriority, IssuePriorityEnum>();
                    _IssuePriorityByEnumeration = new List<IssuePriority>(3) { null, null, null };
                    List<IssuePriority> businessObjects = IssuePriority.Load();
                    foreach (IssuePriority businessObject in businessObjects)
                    {
                        if (businessObject.Code == CODE_HIGH)
                        {
                            _EnumerationByIssuePriority.Add(businessObject, IssuePriorityEnum.High);
                            _IssuePriorityByEnumeration[(int)IssuePriorityEnum.High] = businessObject;
                        }
                        else if (businessObject.Code == CODE_LOW)
                        {
                            _EnumerationByIssuePriority.Add(businessObject, IssuePriorityEnum.Low);
                            _IssuePriorityByEnumeration[(int)IssuePriorityEnum.Low] = businessObject;
                        }
                        else if (businessObject.Code == CODE_MEDIUM)
                        {
                            _EnumerationByIssuePriority.Add(businessObject, IssuePriorityEnum.Medium);
                            _IssuePriorityByEnumeration[(int)IssuePriorityEnum.Medium] = businessObject;
                        }
                    }
                }
            }
        }
    }

    public enum IssueStatusEnum
    {
        Closed,
        Open
    }

    public static class IssueStatusEnums
    {
        private static readonly object _Lock = new object();
        public const string CODE_CLOSED = "Closed";
        public const string CODE_OPEN = "Open";
        private static Dictionary<IssueStatus, IssueStatusEnum> _EnumerationByIssueStatus;
        private static List<IssueStatus> _IssueStatusByEnumeration;
        public static IssueStatus Closed
        {
            get
            {
                FillEnumerationMappings();
                return (_IssueStatusByEnumeration[(int)IssueStatusEnum.Closed]);
            }
        }
        public static IssueStatus Open
        {
            get
            {
                FillEnumerationMappings();
                return (_IssueStatusByEnumeration[(int)IssueStatusEnum.Open]);
            }
        }
        public static IssueStatus Load(IssueStatusEnum enumeration)
        {
            FillEnumerationMappings();
            return (_IssueStatusByEnumeration[(int)enumeration]);
        }
        public static IssueStatusEnum ToEnum(this IssueStatus value)
        {
            FillEnumerationMappings();
            return (_EnumerationByIssueStatus[value]);
        }
        private static void FillEnumerationMappings()
        {
            lock (_Lock)
            {
                if (_EnumerationByIssueStatus == null)
                {
                    _EnumerationByIssueStatus = new Dictionary<IssueStatus, IssueStatusEnum>();
                    _IssueStatusByEnumeration = new List<IssueStatus>(2) { null, null };
                    List<IssueStatus> businessObjects = IssueStatus.Load();
                    foreach (IssueStatus businessObject in businessObjects)
                    {
                        if (businessObject.Code == CODE_CLOSED)
                        {
                            _EnumerationByIssueStatus.Add(businessObject, IssueStatusEnum.Closed);
                            _IssueStatusByEnumeration[(int)IssueStatusEnum.Closed] = businessObject;
                        }
                        else if (businessObject.Code == CODE_OPEN)
                        {
                            _EnumerationByIssueStatus.Add(businessObject, IssueStatusEnum.Open);
                            _IssueStatusByEnumeration[(int)IssueStatusEnum.Open] = businessObject;
                        }
                    }
                }
            }
        }
    }

    public enum IssueTypeEnum
    {
        Bug,
        ChangeRequest,
        Other
    }

    public static class IssueTypeEnums
    {
        private static readonly object _Lock = new object();
        public const string CODE_BUG = "Bug";
        public const string CODE_CHANGEREQUEST = "ChangeRequest";
        public const string CODE_OTHER = "Other";
        private static Dictionary<IssueType, IssueTypeEnum> _EnumerationByIssueType;
        private static List<IssueType> _IssueTypeByEnumeration;
        public static IssueType Bug
        {
            get
            {
                FillEnumerationMappings();
                return (_IssueTypeByEnumeration[(int)IssueTypeEnum.Bug]);
            }
        }
        public static IssueType ChangeRequest
        {
            get
            {
                FillEnumerationMappings();
                return (_IssueTypeByEnumeration[(int)IssueTypeEnum.ChangeRequest]);
            }
        }
        public static IssueType Other
        {
            get
            {
                FillEnumerationMappings();
                return (_IssueTypeByEnumeration[(int)IssueTypeEnum.Other]);
            }
        }
        public static IssueType Load(IssueTypeEnum enumeration)
        {
            FillEnumerationMappings();
            return (_IssueTypeByEnumeration[(int)enumeration]);
        }
        public static IssueTypeEnum ToEnum(this IssueType value)
        {
            FillEnumerationMappings();
            return (_EnumerationByIssueType[value]);
        }
        private static void FillEnumerationMappings()
        {
            lock (_Lock)
            {
                if (_EnumerationByIssueType == null)
                {
                    _EnumerationByIssueType = new Dictionary<IssueType, IssueTypeEnum>();
                    _IssueTypeByEnumeration = new List<IssueType>(3) { null, null, null };
                    List<IssueType> businessObjects = IssueType.Load();
                    foreach (IssueType businessObject in businessObjects)
                    {
                        if (businessObject.Code == CODE_BUG)
                        {
                            _EnumerationByIssueType.Add(businessObject, IssueTypeEnum.Bug);
                            _IssueTypeByEnumeration[(int)IssueTypeEnum.Bug] = businessObject;
                        }
                        else if (businessObject.Code == CODE_CHANGEREQUEST)
                        {
                            _EnumerationByIssueType.Add(businessObject, IssueTypeEnum.ChangeRequest);
                            _IssueTypeByEnumeration[(int)IssueTypeEnum.ChangeRequest] = businessObject;
                        }
                        else if (businessObject.Code == CODE_OTHER)
                        {
                            _EnumerationByIssueType.Add(businessObject, IssueTypeEnum.Other);
                            _IssueTypeByEnumeration[(int)IssueTypeEnum.Other] = businessObject;
                        }
                    }
                }
            }
        }
    }

    public enum TaskStatusEnum
    {
        Closed,
        Completed,
        InProgress,
        New
    }

    public static class TaskStatusEnums
    {
        private static readonly object _Lock = new object();
        public const string CODE_CLOSED = "Closed";
        public const string CODE_COMPLETED = "Completed";
        public const string CODE_INPROGRESS = "InProgress";
        public const string CODE_NEW = "New";
        private static Dictionary<TaskStatus, TaskStatusEnum> _EnumerationByTaskStatus;
        private static List<TaskStatus> _TaskStatusByEnumeration;
        public static TaskStatus Closed
        {
            get
            {
                FillEnumerationMappings();
                return (_TaskStatusByEnumeration[(int)TaskStatusEnum.Closed]);
            }
        }
        public static TaskStatus Completed
        {
            get
            {
                FillEnumerationMappings();
                return (_TaskStatusByEnumeration[(int)TaskStatusEnum.Completed]);
            }
        }
        public static TaskStatus InProgress
        {
            get
            {
                FillEnumerationMappings();
                return (_TaskStatusByEnumeration[(int)TaskStatusEnum.InProgress]);
            }
        }
        public static TaskStatus New
        {
            get
            {
                FillEnumerationMappings();
                return (_TaskStatusByEnumeration[(int)TaskStatusEnum.New]);
            }
        }
        public static TaskStatus Load(TaskStatusEnum enumeration)
        {
            FillEnumerationMappings();
            return (_TaskStatusByEnumeration[(int)enumeration]);
        }
        public static TaskStatusEnum ToEnum(this TaskStatus value)
        {
            FillEnumerationMappings();
            return (_EnumerationByTaskStatus[value]);
        }
        private static void FillEnumerationMappings()
        {
            lock (_Lock)
            {
                if (_EnumerationByTaskStatus == null)
                {
                    _EnumerationByTaskStatus = new Dictionary<TaskStatus, TaskStatusEnum>();
                    _TaskStatusByEnumeration = new List<TaskStatus>(4) { null, null, null, null };
                    List<TaskStatus> businessObjects = TaskStatus.Load();
                    foreach (TaskStatus businessObject in businessObjects)
                    {
                        if (businessObject.Code == CODE_CLOSED)
                        {
                            _EnumerationByTaskStatus.Add(businessObject, TaskStatusEnum.Closed);
                            _TaskStatusByEnumeration[(int)TaskStatusEnum.Closed] = businessObject;
                        }
                        else if (businessObject.Code == CODE_COMPLETED)
                        {
                            _EnumerationByTaskStatus.Add(businessObject, TaskStatusEnum.Completed);
                            _TaskStatusByEnumeration[(int)TaskStatusEnum.Completed] = businessObject;
                        }
                        else if (businessObject.Code == CODE_INPROGRESS)
                        {
                            _EnumerationByTaskStatus.Add(businessObject, TaskStatusEnum.InProgress);
                            _TaskStatusByEnumeration[(int)TaskStatusEnum.InProgress] = businessObject;
                        }
                        else if (businessObject.Code == CODE_NEW)
                        {
                            _EnumerationByTaskStatus.Add(businessObject, TaskStatusEnum.New);
                            _TaskStatusByEnumeration[(int)TaskStatusEnum.New] = businessObject;
                        }
                    }
                }
            }
        }
    }


    #endregion




}
