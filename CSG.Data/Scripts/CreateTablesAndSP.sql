USE [CSG]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 2021/03/25 13:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Class](
	[ClassId] [varchar](50) NOT NULL,
	[ClassName] [varchar](30) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2021/03/25 13:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Login](
	[LoginId] [varchar](50) NOT NULL,
	[LoginTime] [datetime] NULL,
	[LogOutTime] [datetime] NULL,
	[UserId] [varchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 2021/03/25 13:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registration]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Registration](
	[RegId] [varchar](50) NOT NULL,
	[StudentId] [varchar](50) NOT NULL,
	[TeacherId] [varchar](50) NOT NULL,
	[ClassId] [varchar](50) NOT NULL,
	[AttendanceStatusId] [int] NOT NULL,
	[Grade] [decimal](18, 2) NOT NULL,
	[AttendanceDate] [date] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2021/03/25 13:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Status](
	[StatusId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2021/03/25 13:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Student](
	[StudentId] [varchar](50) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[DateRegistered] [date] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2021/03/25 13:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teacher]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [varchar](50) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[DateRegistered] [date] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserEntity]    Script Date: 2021/03/25 13:30:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEntity]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserEntity](
	[UserId] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](100) NOT NULL,
	[Role] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[Class] ([ClassId], [ClassName], [Description]) VALUES (N'2805faa5-c84e-4778-8ce4-1c8c68706a28', N'English', N'English Poetry')
INSERT [dbo].[Class] ([ClassId], [ClassName], [Description]) VALUES (N'8ad32368-8f1a-4795-87e4-c900bad8f621', N'biography', N'Higher Grade')
INSERT [dbo].[Registration] ([RegId], [StudentId], [TeacherId], [ClassId], [AttendanceStatusId], [Grade], [AttendanceDate]) VALUES (N'6a1e6e51-742d-4d41-aa3a-db13dfae323d', N'f7bc6ca8-17bd-45d6-857c-b764791e49a4', N'a3e0db51-bedb-45f9-b148-3d8148c7f480', N'2805faa5-c84e-4778-8ce4-1c8c68706a28', 0, CAST(55.00 AS Decimal(18, 2)), CAST(N'2021-03-22' AS Date))
INSERT [dbo].[Registration] ([RegId], [StudentId], [TeacherId], [ClassId], [AttendanceStatusId], [Grade], [AttendanceDate]) VALUES (N'b67ddfcc-69ec-4e51-819c-ff63283ce9f8', N'6b1a4cc8-0839-4876-988a-aaaa51d7df4e', N'a3e0db51-bedb-45f9-b148-3d8148c7f480', N'2805faa5-c84e-4778-8ce4-1c8c68706a28', 0, CAST(76.00 AS Decimal(18, 2)), CAST(N'2021-03-22' AS Date))
INSERT [dbo].[Registration] ([RegId], [StudentId], [TeacherId], [ClassId], [AttendanceStatusId], [Grade], [AttendanceDate]) VALUES (N'b713740f-75e0-4134-8408-394c5cc61802', N'0db176c7-701f-4ab2-affb-a0b4ab1b5180', N'a3e0db51-bedb-45f9-b148-3d8148c7f480', N'2805faa5-c84e-4778-8ce4-1c8c68706a28', 0, CAST(78.00 AS Decimal(18, 2)), CAST(N'2021-03-22' AS Date))
INSERT [dbo].[Student] ([StudentId], [Name], [Surname], [DateRegistered]) VALUES (N'0db176c7-701f-4ab2-affb-a0b4ab1b5180', N'Johan', N'Potgieter', CAST(N'2021-03-20' AS Date))
INSERT [dbo].[Student] ([StudentId], [Name], [Surname], [DateRegistered]) VALUES (N'6b1a4cc8-0839-4876-988a-aaaa51d7df4e', N'Gert', N'Pieterse', CAST(N'2021-03-22' AS Date))
INSERT [dbo].[Student] ([StudentId], [Name], [Surname], [DateRegistered]) VALUES (N'f7bc6ca8-17bd-45d6-857c-b764791e49a4', N'Nikki', N'Heck', CAST(N'2021-03-21' AS Date))
INSERT [dbo].[Teacher] ([TeacherId], [Name], [Surname], [DateRegistered]) VALUES (N'a3e0db51-bedb-45f9-b148-3d8148c7f480', N'Johan', N'Potgieter', CAST(N'2021-03-22' AS Date))
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Registration_AttendanceStatusId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_AttendanceStatusId]  DEFAULT ((0)) FOR [AttendanceStatusId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Registration_Grade]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Grade]  DEFAULT ((0)) FOR [Grade]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Registration_AttendanceDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_AttendanceDate]  DEFAULT (getdate()) FOR [AttendanceDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Student_DateRegistered]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_DateRegistered]  DEFAULT (getdate()) FOR [DateRegistered]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Teacher_DateRegistered]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_DateRegistered]  DEFAULT (getdate()) FOR [DateRegistered]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Class_Class]') AND parent_object_id = OBJECT_ID(N'[dbo].[Class]'))
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Class_Class]') AND parent_object_id = OBJECT_ID(N'[dbo].[Class]'))
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Class]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Login_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Login]'))
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserEntity] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Login_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Login]'))
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Registration_Class]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Registration_Class]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Class]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Registration_Student]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Registration_Student]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Student]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Registration_Teacher]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Registration_Teacher]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Teacher]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_GradeGreaterThanZero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [CK_GradeGreaterThanZero] CHECK  (([Grade]>(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_GradeGreaterThanZero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Registration]'))
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [CK_GradeGreaterThanZero]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAllClasses]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteAllClasses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteAllClasses] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteAllClasses]

@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS

BEGIN Tran
Begin Try
	SET NOCOUNT ON;
	Delete From Class;

	Commit Tran

END Try
Begin Catch

SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

End Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAllRegistrations]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteAllRegistrations]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteAllRegistrations] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteAllRegistrations]

@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT


AS
BEGIN Tran
Begin Try

	SET NOCOUNT ON;
	Delete From  Registration;

	Commit Tran

END Try

Begin Catch

SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

End Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAllTeachers]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteAllTeachers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteAllTeachers] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteAllTeachers]

@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try	
	Delete From Teacher;

	Commit Tran

END Try
Begin Catch

SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran


End Catch

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteClassByID]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteClassByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteClassByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteClassByID]
@classId         varchar(50),
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS

BEGIN Tran
Begin Try
	Delete From Class where ClassId = @classId;

	Commit Tran

END Try
Begin Catch

SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

End Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRegistrationByID]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteRegistrationByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteRegistrationByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteRegistrationByID]
@regId			 varchar(50),
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT
AS
BEGIN Tran
Begin Try
	
	Delete From  Registration where RegId = @regId;

	Commit Tran

END Try
Begin Catch


SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

End Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudentById]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteStudentById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteStudentById] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteStudentById]
@studentId       varchar(50),
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS

BEGIN Tran
Begin Try	
	Delete From Student where StudentId = @studentId;

	Commit Tran
End Try
Begin Catch
	SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran


END Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTeacherById]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteTeacherById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_DeleteTeacherById] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_DeleteTeacherById]

@classId         varchar(50),
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	
	Delete From Teacher;

	Commit Tran
END Try

Begin Catch

SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

End Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_GetClass]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetClass]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_GetClass] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_GetClass]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From Class
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLogins]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetLogins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_GetLogins] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_GetLogins]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From Login
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRegistrations]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetRegistrations]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_GetRegistrations] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_GetRegistrations]

AS
BEGIN 
	
	SELECT * From Registration;

END 
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudents]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetStudents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_GetStudents] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_GetStudents]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From Student;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTeacher]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetTeacher]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_GetTeacher] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_GetTeacher]

AS
BEGIN 
	SELECT * From Teacher
END 
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsers]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_GetUsers] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_GetUsers]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From UserEntity
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertClass]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertClass]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertClass] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_InsertClass]

@classId       varchar(50),
@className	   varchar(30),
@description   varchar(100),
@errorMessage   varchar(Max) OUTPUT,
@errorNumber    varchar(10)  OUTPUT,
@errorSeverity  varchar(100) OUTPUT,
@errorState     varchar(100) OUTPUT,
@errorProcedure varchar(100) OUTPUT,
@errorLine      varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	
	Insert into Class (ClassId, ClassName, Description)
	Values
	(@classId, @className, @description)

	Commit Tran
	
END Try
Begin Catch

SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

End Catch
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLogin]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertLogin] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_InsertLogin]

@loginId				varchar(50),
@loginTime				varchar(50),
@logoutTime				varchar(50),
@userId   				varchar(50),
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	Insert into Login (loginId, LoginTime, LogoutTime, UserId)
	Values
	(@loginId, @loginTime, @logoutTime, @userId)

	Commit tran

End Try

Begin Catch

   SELECT @errorMessage = ERROR_MESSAGE(),
	      @errorNumber = ERROR_NUMBER(),
	      @errorSeverity = ERROR_SEVERITY(),
	      @errorState = ERROR_STATE(),
	      @errorProcedure = ERROR_PROCEDURE(),
	      @errorLine = ERROR_LINE()
 Rollback Tran

END Catch 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertRegistration]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertRegistration]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertRegistration] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_InsertRegistration]

@regId					varchar(50),
@teacherId				varchar(50),
@studentId				varchar(50),
@classId				varchar(50),
@attendanceStatusId     integer,
@grade					decimal(18,2),
@attendanceDate			date,
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	Insert into Registration (regId, StudentId, TeacherId, ClassId, AttendanceStatusId, Grade, AttendanceDate)
	Values
	(@regId, @studentId, @teacherId, @classId, @attendanceStatusId, @grade, @attendanceDate)

	Commit tran

End Try

Begin Catch

   SELECT @errorMessage = ERROR_MESSAGE(),
	      @errorNumber = ERROR_NUMBER(),
	      @errorSeverity = ERROR_SEVERITY(),
	      @errorState = ERROR_STATE(),
	      @errorProcedure = ERROR_PROCEDURE(),
	      @errorLine = ERROR_LINE()
 Rollback Tran

END Catch 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertStudent]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertStudent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertStudent] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_InsertStudent]

@studentId       varchar(50),
@name	         varchar(30),
@surname         varchar(100),
@dateRegistered  date,
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	Insert into Student (StudentId, Name, Surname, DateRegistered)
	Values
	(@studentId, @name, @surname, @dateRegistered)

	Commit tran

End Try

Begin Catch

   SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

END Catch 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTeacher]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertTeacher]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertTeacher] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_InsertTeacher]

@teacherId       varchar(50),
@name	         varchar(30),
@surname         varchar(100),
@dateRegistered  date,
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	Insert into Teacher (TeacherId, Name, Surname, DateRegistered)
	Values
	(@teacherId, @name, @surname, @dateRegistered)

	Commit tran

End Try

Begin Catch

   SELECT @errorMessage = ERROR_MESSAGE(),
	   @errorNumber = ERROR_NUMBER(),
	   @errorSeverity = ERROR_SEVERITY(),
	   @errorState = ERROR_STATE(),
	   @errorProcedure = ERROR_PROCEDURE(),
	   @errorLine = ERROR_LINE()
 Rollback Tran

END Catch 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 2021/03/25 13:30:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertUser] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_InsertUser]

@userId					varchar(50),
@name   				varchar(50),
@surname				varchar(50),
@role   				varchar(50),
@errorMessage    varchar(Max) OUTPUT,
@errorNumber     varchar(10)  OUTPUT,
@errorSeverity   varchar(100) OUTPUT,
@errorState      varchar(100) OUTPUT,
@errorProcedure  varchar(100) OUTPUT,
@errorLine       varchar(100) OUTPUT

AS
BEGIN Tran
Begin Try
	Insert into UserEntity (userId, Name, Surname, Role)
	Values
	(@userId, @name, @surname, @role)

	Commit tran

End Try

Begin Catch

   SELECT @errorMessage = ERROR_MESSAGE(),
	      @errorNumber = ERROR_NUMBER(),
	      @errorSeverity = ERROR_SEVERITY(),
	      @errorState = ERROR_STATE(),
	      @errorProcedure = ERROR_PROCEDURE(),
	      @errorLine = ERROR_LINE()
 Rollback Tran

END Catch 
GO
