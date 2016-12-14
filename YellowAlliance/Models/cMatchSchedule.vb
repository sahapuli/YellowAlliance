'----------------------------------------------------------------------
'Class Name:    cMatchSchedule 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Match Schedule table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cMatchSchedule
    ' Locale Variables 
    Private m_EventID As String
    Private m_MatchID As String
    Private m_RedScore As Integer
    Private m_BlueScore As Integer
    Private m_RedTeamID1 As Integer
    Private m_RedTeamID2 As Integer
    Private m_RedTeamID3 As Integer
    Private m_BlueTeamID1 As Integer
    Private m_BlueTeamID2 As Integer
    Private m_BlueTeamID3 As Integer

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
