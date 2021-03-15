USE [CSG]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [uniqueidentifier] NOT NULL,
	[ClassName] [varchar](30) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegId] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[ClassId] [uniqueidentifier] NOT NULL,
	[AttendanceStatusId] [int] NOT NULL,
	[Grade] [decimal](18, 2) NOT NULL,
	[AttendanceDate] [date] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[DateRegistered] [date] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[DateRegistered] [date] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_AttendanceStatusId]  DEFAULT ((0)) FOR [AttendanceStatusId]
GO
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Grade]  DEFAULT ((0)) FOR [Grade]
GO
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_AttendanceDate]  DEFAULT (getdate()) FOR [AttendanceDate]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_DateRegistered]  DEFAULT (getdate()) FOR [DateRegistered]
GO
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_DateRegistered]  DEFAULT (getdate()) FOR [DateRegistered]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [CK_AttendanceDate] CHECK  (([AttendanceDate]>=getdate()))
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [CK_AttendanceDate]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [CK_GradeGreaterThanZero] CHECK  (([Grade]>(0)))
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [CK_GradeGreaterThanZero]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteClasses]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_DeleteClasses]

AS
BEGIN
	SET NOCOUNT ON;
	Delete From Class;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudents]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_DeleteStudents]

AS
BEGIN
	SET NOCOUNT ON;
	Delete From Student;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTeachers]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_DeleteTeachers]

AS
BEGIN
	SET NOCOUNT ON;
	Delete From Teacher;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetClass]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetClass]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From Class
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStudents]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetStudents]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From Student;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTeacher]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTeacher]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * From Teacher
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertClass]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertClass]

@classId       uniqueidentifier,
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
	
	SET NOCOUNT ON;
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
/****** Object:  StoredProcedure [dbo].[sp_InsertRegistration]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_InsertRegistration]

@regId					uniqueidentifier,
@teacherId				uniqueidentifier,
@studentId				uniqueIdentifier,
@classId				uniqueIdentifier,
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

	SET NOCOUNT ON;
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
/****** Object:  StoredProcedure [dbo].[sp_InsertStudent]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertStudent]

@studentId       uniqueidentifier,
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

	SET NOCOUNT ON;
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
/****** Object:  StoredProcedure [dbo].[sp_InsertTeacher]    Script Date: 2021/03/15 11:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertTeacher]

@teacherId       uniqueidentifier,
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

	SET NOCOUNT ON;
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
