-- Single Query
SELECT [c].[Id], [c].[Credits], [c].[DepartmentID], [c].[Title], [t].[CourseId], [t].[InstructorId], [t].[Id], [t].[FirstName], [t].[HireDate], [t].[LastName]
FROM [courses] AS [c]
LEFT JOIN (
    SELECT [c0].[CourseId], [c0].[InstructorId], [i].[Id], [i].[FirstName], [i].[HireDate], [i].[LastName]
    FROM [courses_instructors] AS [c0]
    INNER JOIN [instructors] AS [i] ON [c0].[InstructorId] = [i].[Id]
) AS [t] ON [c].[Id] = [t].[CourseId]

------------------------------------------------------------
-- Split Query
-- Courses Query
SELECT [c].[Id], [c].[Credits], [c].[DepartmentID], [c].[Title]
FROM [courses] AS [c]
ORDER BY [c].[Id]

-- Departments Query
SELECT [t].[CourseId], [t].[InstructorId], [t].[Id], [t].[FirstName], [t].[HireDate], [t].[LastName], [c].[Id]
FROM [courses] AS [c]
INNER JOIN (
    SELECT [c0].[CourseId], [c0].[InstructorId], [i].[Id], [i].[FirstName], [i].[HireDate], [i].[LastName]
    FROM [courses_instructors] AS [c0]
    INNER JOIN [instructors] AS [i] ON [c0].[InstructorId] = [i].[Id]
) AS [t] ON [c].[Id] = [t].[CourseId]
ORDER BY [c].[Id]