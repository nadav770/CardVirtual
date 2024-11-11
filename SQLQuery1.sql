CREATE TABLE [dbo].[SeriesActions] (
    [SeriesActionId]   INT  IDENTITY (1,3) NOT  NULL,
    [SeriesActionName] NVARCHAR (50)  NULL,
    [SeriesActionDesc] NVARCHAR (500) NULL,
    [ChronoloyActions] INT            NULL
)
