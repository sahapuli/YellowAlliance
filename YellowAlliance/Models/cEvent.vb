'----------------------------------------------------------------------
'Class Name:    cEvent 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the events table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cEvent
    ' Locale Variables 
    Private m_EventID As String
    Private m_EventDescription As String
    Private m_Venue As String
    Private m_StartDate As Date
    Private m_IsActive As Boolean

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property EventID As String
        Get
            Return m_EventID
        End Get
        Set(value As String)
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
    Public Property IsActive As Boolean
        Get
            Return m_IsActive
        End Get
        Set(value As Boolean)
            m_IsActive = value
        End Set
    End Property
End Class
