CREATE TABLE [dbo].[Shift]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ShiftId] INT NULL, 
    [StartTime] DATETIME NULL, 
    [EndTime] DATETIME NULL, 
    [TypeOfAssignment] NVARCHAR(MAX) NULL, 
    [Location] NVARCHAR(MAX) NULL
)