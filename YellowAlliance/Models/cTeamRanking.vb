'----------------------------------------------------------------------
'Class Name:    cTeamRanking 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Team Ranking table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cTeamRanking
    ' Locale Variables 
    Private m_TeamRankingID As String
    Private m_EventID As String
    Private m_TeamID As String
    Private m_Rank As Integer
    Private m_RankingPoints As Integer
    Private m_RankingScore As Integer
    Private m_HighScore As Integer
    Private m_DQ As Integer
    Private m_Plays As Integer

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------
    Public Property TeamRankingID As String
        Get
            Return m_TeamRankingID
        End Get
        Set(value As String)
            m_TeamRankingID = value
        End Set
    End Property

    Public Property EventID As String
        Get
            Return m_EventID
        End Get
        Set(value As String)
            m_EventID = value
        End Set
    End Property
    Public Property TeamID As String
        Get
            Return m_TeamID
        End Get
        Set(value As String)
            m_TeamID = value
        End Set
    End Property

    Public Property Rank As Integer
        Get
            Return m_Rank
        End Get
        Set(value As Integer)
            m_Rank = value
        End Set
    End Property

    Public Property RankingPoints As Integer
        Get
            Return m_RankingPoints
        End Get
        Set(value As Integer)
            m_RankingPoints = value
        End Set
    End Property
    Public Property RankingScore As Integer
        Get
            Return m_RankingScore
        End Get
        Set(value As Integer)
            m_RankingScore = value
        End Set
    End Property
    Public Property HighScore As Integer
        Get
            Return m_HighScore
        End Get
        Set(value As Integer)
            m_HighScore = value
        End Set
    End Property
    Public Property DQ As Integer
        Get
            Return m_DQ
        End Get
        Set(value As Integer)
            m_DQ = value
        End Set
    End Property
    Public Property Plays As Integer
        Get
            Return m_Plays
        End Get
        Set(value As Integer)
            m_Plays = value
        End Set
    End Property

End Class