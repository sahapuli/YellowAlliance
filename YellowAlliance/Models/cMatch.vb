'----------------------------------------------------------------------
'Class Name:    cMatch 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Match table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cMatch
    ' Locale Variables 
    Private m_EventID As String
    Private m_MatchID As String
    Private m_MatchName As String
    Private m_ScheduleTime As Date
    Private m_RedAuto As Integer
    Private m_BlueAuto As Integer
    Private m_RedDriver As Integer
    Private m_BlueDriver As Integer
    Private m_RedEndGame As Integer
    Private m_BlueEndGame As Integer
    Private m_RedPen As Integer
    Private m_BluePen As Integer

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

    Public Property MatchID As String
        Get
            Return m_MatchID
        End Get
        Set(value As String)
            m_MatchID = value
        End Set
    End Property
    Public Property MatchName As String
        Get
            Return m_MatchName
        End Get
        Set(value As String)
            m_MatchName = value
        End Set
    End Property
    Public Property ScheduleTime As Date
        Get
            Return m_ScheduleTime
        End Get
        Set(value As Date)
            m_ScheduleTime = value
        End Set
    End Property
    Public Property RedAuto As Integer
        Get
            Return m_RedAuto
        End Get
        Set(value As Integer)
            m_RedAuto = value
        End Set
    End Property
    Public Property BlueAuto As Integer
        Get
            Return m_BlueAuto
        End Get
        Set(value As Integer)
            m_BlueAuto = value
        End Set
    End Property
    Public Property RedDriver As Integer
        Get
            Return m_RedDriver
        End Get
        Set(value As Integer)
            m_RedDriver = value
        End Set
    End Property
    Public Property BlueDriver As Integer
        Get
            Return m_BlueDriver
        End Get
        Set(value As Integer)
            m_BlueDriver = value
        End Set
    End Property
    Public Property RedPen As Integer
        Get
            Return m_RedPen
        End Get
        Set(value As Integer)
            m_RedPen = value
        End Set
    End Property
    Public Property BluePen As Integer
        Get
            Return m_BluePen
        End Get
        Set(value As Integer)
            m_BluePen = value
        End Set
    End Property

End Class
