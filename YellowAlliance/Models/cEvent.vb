'----------------------------------------------------------------------
'Class Name:    cEvent 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the events table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cEvent
    ' Locale Variables 
    Private m_EventID As Long
    Private m_EventDescription As String
    Private m_Venue As String
    Private m_StartDate As Date
    Private m_EndDate As Date
    Private m_IsActive As Boolean
    Private m_EventTypeID As Integer
    Private m_EventTypeDescription As String
    Private m_City As String
    Private m_State As String
    Private m_Country As String

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property EventID As Long
        Get
            Return m_EventID
        End Get
        Set(value As Long)
            m_EventID = value
        End Set
    End Property

    Public Property EventDescription As String
        Get
            Return m_EventDescription
        End Get
        Set(value As String)
            m_EventDescription = value
        End Set
    End Property
    Public Property Venue As String
        Get
            Return m_Venue
        End Get
        Set(value As String)
            m_Venue = value
        End Set
    End Property
    Public Property StartDate As Date
        Get
            Return m_StartDate
        End Get
        Set(value As Date)
            m_StartDate = value
        End Set
    End Property
    Public Property EndDate As Date
        Get
            Return m_EndDate
        End Get
        Set(value As Date)
            m_EndDate = value
        End Set
    End Property
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
    Public Property EventTypeID As Long
        Get
            Return m_EventTypeID
        End Get
        Set(value As Long)
            m_EventTypeID = value
        End Set
    End Property
    Public Property EventTypeDescription As String
        Get
            Return m_EventTypeDescription
        End Get
        Set(value As String)
            m_EventTypeDescription = value
        End Set
    End Property
    Public Property City As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = value
        End Set
    End Property
    Public Property State As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = value
        End Set
    End Property
    Public Property Country As String
        Get
            Return m_Country
        End Get
        Set(value As String)
            m_Country = value
        End Set
    End Property
End Class
