'----------------------------------------------------------------------
'Class Name:    cMatchSchedule 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Match Schedule table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cMatchSchedule
    ' Locale Variables 
    Private m_EventID As Long
    Private m_EventName As String
    Private m_MatchID As Long
    Private m_MatchName As String
    Private m_ScheduleTime As Date
    Private m_RedScore As Integer
    Private m_BlueScore As Integer
    Private m_AllianceType As Integer
    Private m_RedTeamID1 As Integer
    Private m_RedTeamID2 As Integer
    Private m_RedTeamID3 As Integer
    Private m_BlueTeamID1 As Integer
    Private m_BlueTeamID2 As Integer
    Private m_BlueTeamID3 As Integer

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
    Public Property EventName As String
        Get
            Return m_EventName
        End Get
        Set(value As String)
            m_EventName = value
        End Set
    End Property

    Public Property MatchID As Long
        Get
            Return m_MatchID
        End Get
        Set(value As Long)
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

    Public Property RedScore As Integer
        Get
            Return m_RedScore
        End Get
        Set(value As Integer)
            m_RedScore = value
        End Set
    End Property
    Public Property BlueScore As Integer
        Get
            Return m_BlueScore
        End Get
        Set(value As Integer)
            m_BlueScore = value
        End Set
    End Property

    Public Property AllianceType As Integer
        Get
            Return m_AllianceType
        End Get
        Set(value As Integer)
            m_AllianceType = value
        End Set
    End Property
    Public Property RedTeamID1 As Integer
        Get
            Return m_RedTeamID1
        End Get
        Set(value As Integer)
            m_RedTeamID1 = value
        End Set
    End Property
    Public Property RedTeamID2 As Integer
        Get
            Return m_RedTeamID2
        End Get
        Set(value As Integer)
            m_RedTeamID2 = value
        End Set
    End Property
    Public Property RedTeamID3 As Integer
        Get
            Return m_RedTeamID3
        End Get
        Set(value As Integer)
            m_RedTeamID3 = value
        End Set
    End Property
    Public Property BlueTeamID1 As Integer
        Get
            Return m_BlueTeamID1
        End Get
        Set(value As Integer)
            m_BlueTeamID1 = value
        End Set
    End Property
    Public Property BlueTeamID2 As Integer
        Get
            Return m_BlueTeamID2
        End Get
        Set(value As Integer)
            m_BlueTeamID2 = value
        End Set
    End Property
    Public Property BlueTeamID3 As Integer
        Get
            Return m_BlueTeamID3
        End Get
        Set(value As Integer)
            m_BlueTeamID3 = value
        End Set
    End Property
End Class
