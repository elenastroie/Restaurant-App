USE [master]
GO
/****** Object:  Database [RestaurantOnline]    Script Date: 6/2/2020 11:54:08 PM ******/
CREATE DATABASE [RestaurantOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestaurantOnline', FILENAME = N'C:\Users\elena\Desktop\MVP-SQL\sql2019\MSSQL15.SQLEXPRESS01\MSSQL\DATA\RestaurantOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestaurantOnline_log', FILENAME = N'C:\Users\elena\Desktop\MVP-SQL\sql2019\MSSQL15.SQLEXPRESS01\MSSQL\DATA\RestaurantOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RestaurantOnline] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestaurantOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RestaurantOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestaurantOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RestaurantOnline] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestaurantOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestaurantOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RestaurantOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RestaurantOnline] SET QUERY_STORE = OFF
GO
USE [RestaurantOnline]
GO
/****** Object:  Table [dbo].[Alergeni]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alergeni](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Alergeni] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlergeniPreparat]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlergeniPreparat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_preparat] [int] NOT NULL,
	[fk_alergeni] [int] NOT NULL,
 CONSTRAINT [PK_AlergeniPreparat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_utilizator] [int] NOT NULL,
	[stare] [varchar](150) NOT NULL,
	[timp_inregistrare] [datetime] NOT NULL,
	[discount] [float] NOT NULL,
	[cost_transport] [float] NOT NULL,
	[pret_total] [float] NOT NULL,
 CONSTRAINT [PK_Comanda] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComandaMeniu]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComandaMeniu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_comanda] [int] NOT NULL,
	[fk_meniu] [int] NOT NULL,
	[cantitate] [int] NOT NULL,
 CONSTRAINT [PK_ComandaMeniu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComandaPreparat]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComandaPreparat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_comanda] [int] NOT NULL,
	[fk_preparat] [int] NOT NULL,
	[cantitate] [int] NOT NULL,
 CONSTRAINT [PK_ComandaPreparat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](150) NOT NULL,
	[fk_categorie] [int] NOT NULL,
 CONSTRAINT [PK_Meniu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeniuPreparat]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeniuPreparat](
	[id1] [int] IDENTITY(1,1) NOT NULL,
	[fk_meniu] [int] NOT NULL,
	[fk_preparat] [int] NOT NULL,
	[cantitate] [int] NOT NULL,
 CONSTRAINT [PK_MeniuPreparat] PRIMARY KEY CLUSTERED 
(
	[id1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparat]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](150) NOT NULL,
	[pret] [float] NOT NULL,
	[unitate_masura] [varchar](150) NOT NULL,
	[cantitate_per_portie] [int] NOT NULL,
	[cantitate_totala] [int] NOT NULL,
	[fk_categorie] [int] NOT NULL,
 CONSTRAINT [PK_Preparat_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizator]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizator](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prenume] [varchar](150) NOT NULL,
	[nume] [varchar](150) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[parola] [varchar](150) NOT NULL,
	[telefon] [varchar](150) NOT NULL,
	[adresa] [varchar](150) NOT NULL,
	[angajat] [bit] NOT NULL,
 CONSTRAINT [PK_Utilizator] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Utilizator] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlergeniPreparat]  WITH CHECK ADD  CONSTRAINT [FK_AlergeniPreparat_Alergeni] FOREIGN KEY([fk_alergeni])
REFERENCES [dbo].[Alergeni] ([id])
GO
ALTER TABLE [dbo].[AlergeniPreparat] CHECK CONSTRAINT [FK_AlergeniPreparat_Alergeni]
GO
ALTER TABLE [dbo].[AlergeniPreparat]  WITH CHECK ADD  CONSTRAINT [FK_AlergeniPreparat_Preparat] FOREIGN KEY([fk_preparat])
REFERENCES [dbo].[Preparat] ([id])
GO
ALTER TABLE [dbo].[AlergeniPreparat] CHECK CONSTRAINT [FK_AlergeniPreparat_Preparat]
GO
ALTER TABLE [dbo].[Comanda]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Utilizator] FOREIGN KEY([fk_utilizator])
REFERENCES [dbo].[Utilizator] ([id])
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [FK_Comanda_Utilizator]
GO
ALTER TABLE [dbo].[ComandaMeniu]  WITH CHECK ADD  CONSTRAINT [FK_ComandaMeniu_Comanda] FOREIGN KEY([fk_comanda])
REFERENCES [dbo].[Comanda] ([id])
GO
ALTER TABLE [dbo].[ComandaMeniu] CHECK CONSTRAINT [FK_ComandaMeniu_Comanda]
GO
ALTER TABLE [dbo].[ComandaMeniu]  WITH CHECK ADD  CONSTRAINT [FK_ComandaMeniu_Meniu] FOREIGN KEY([fk_meniu])
REFERENCES [dbo].[Meniu] ([id])
GO
ALTER TABLE [dbo].[ComandaMeniu] CHECK CONSTRAINT [FK_ComandaMeniu_Meniu]
GO
ALTER TABLE [dbo].[ComandaPreparat]  WITH CHECK ADD  CONSTRAINT [FK_ComandaPreparat_Comanda] FOREIGN KEY([fk_comanda])
REFERENCES [dbo].[Comanda] ([id])
GO
ALTER TABLE [dbo].[ComandaPreparat] CHECK CONSTRAINT [FK_ComandaPreparat_Comanda]
GO
ALTER TABLE [dbo].[ComandaPreparat]  WITH CHECK ADD  CONSTRAINT [FK_ComandaPreparat_Preparat] FOREIGN KEY([fk_preparat])
REFERENCES [dbo].[Preparat] ([id])
GO
ALTER TABLE [dbo].[ComandaPreparat] CHECK CONSTRAINT [FK_ComandaPreparat_Preparat]
GO
ALTER TABLE [dbo].[Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Categorie] FOREIGN KEY([fk_categorie])
REFERENCES [dbo].[Categorie] ([id])
GO
ALTER TABLE [dbo].[Meniu] CHECK CONSTRAINT [FK_Meniu_Categorie]
GO
ALTER TABLE [dbo].[MeniuPreparat]  WITH CHECK ADD  CONSTRAINT [FK_MeniuPreparat_Meniu] FOREIGN KEY([fk_meniu])
REFERENCES [dbo].[Meniu] ([id])
GO
ALTER TABLE [dbo].[MeniuPreparat] CHECK CONSTRAINT [FK_MeniuPreparat_Meniu]
GO
ALTER TABLE [dbo].[MeniuPreparat]  WITH CHECK ADD  CONSTRAINT [FK_MeniuPreparat_Preparat] FOREIGN KEY([fk_preparat])
REFERENCES [dbo].[Preparat] ([id])
GO
ALTER TABLE [dbo].[MeniuPreparat] CHECK CONSTRAINT [FK_MeniuPreparat_Preparat]
GO
ALTER TABLE [dbo].[Preparat]  WITH CHECK ADD  CONSTRAINT [FK_Preparat_Categorie1] FOREIGN KEY([fk_categorie])
REFERENCES [dbo].[Categorie] ([id])
GO
ALTER TABLE [dbo].[Preparat] CHECK CONSTRAINT [FK_Preparat_Categorie1]
GO
ALTER TABLE [dbo].[Preparat]  WITH CHECK ADD  CONSTRAINT [FK_Preparat_Preparat] FOREIGN KEY([id])
REFERENCES [dbo].[Preparat] ([id])
GO
ALTER TABLE [dbo].[Preparat] CHECK CONSTRAINT [FK_Preparat_Preparat]
GO
/****** Object:  StoredProcedure [dbo].[spAddOrder]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddOrder]
	@Id int,
	@TimpInregistrare datetime,
    @Discount float,
	@CostTransport float,
	@PretTotal float
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
    INSERT INTO dbo.Comanda (fk_utilizator,stare,timp_inregistrare,discount,cost_transport,pret_total)
	SELECT Utilizator.id, "Inregistrata", @TimpInregistrare, @Discount, @CostTransport, @PretTotal 
	FROM Utilizator
	WHERE Utilizator.email = @Email';
    SET @params = N'
	@Id INT,
    @TimpInregistrare DATETIME,
    @Discount FLOAT,
	@CostTransport FLOAT,
	@PretTotal FLOAT'
    EXECUTE sp_executesql @sqlcmd, @params,@Id,@TimpInregistrare,@Discount,@CostTransport,@PretTotal;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAlergensName]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAlergensName]
AS
BEGIN
 DECLARE @sqlcmd NVARCHAR(MAX);
    SET @sqlcmd = N'
	SELECT nume
	FROM dbo.Alergeni';
	EXECUTE sp_executesql @sqlcmd;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCategoriesName]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCategoriesName]
AS
BEGIN
 DECLARE @sqlcmd NVARCHAR(MAX);
    SET @sqlcmd = N'
	SELECT nume
	FROM dbo.Categorie';
	EXECUTE sp_executesql @sqlcmd;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuCategory]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMenuCategory]
    @Id int
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
    SELECT nume
    FROM dbo.Categorie
    WHERE id = @Id';
    SET @params = N'
    @Id int';
    EXECUTE sp_executesql @sqlcmd, @params, @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMenuProducts]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMenuProducts]
	@Id int
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
	SELECT *
	FROM dbo.Preparat
	INNER JOIN dbo.MeniuPreparat
	ON dbo.Preparat.id = dbo.MeniuPreparat.fk_preparat
	WHERE dbo.MeniuPreparat.fk_meniu = @Id';
	SET @params = N'
    @Id int';
    EXECUTE sp_executesql @sqlcmd, @params, @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMenus]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMenus]
AS
BEGIN
 DECLARE @sqlcmd NVARCHAR(MAX);
    SET @sqlcmd = N'
	SELECT *
	FROM dbo.Meniu';
	EXECUTE sp_executesql @sqlcmd;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetOrders]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetOrders]
    @Id int
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
    SELECT *
    FROM dbo.Comanda
    WHERE fk_utilizator = @Id';
    SET @params = N'
    @Id int';
    EXECUTE sp_executesql @sqlcmd, @params, @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductAlergens]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProductAlergens]
	@Id int
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
	SELECT nume
	FROM dbo.Alergeni
	INNER JOIN dbo.AlergeniPreparat
	ON dbo.AlergeniPreparat.fk_alergeni = dbo.Alergeni.id
	WHERE dbo.AlergeniPreparat.fk_preparat = @Id';
	SET @params = N'
    @Id int';
    EXECUTE sp_executesql @sqlcmd, @params, @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductCategory]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProductCategory]
    @Id int
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
    SELECT nume
    FROM dbo.Categorie
    WHERE id = @Id';
    SET @params = N'
    @Id int';
    EXECUTE sp_executesql @sqlcmd, @params, @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProducts]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProducts]
AS
BEGIN
 DECLARE @sqlcmd NVARCHAR(MAX);
    SET @sqlcmd = N'
	SELECT *
	FROM dbo.Preparat';
	EXECUTE sp_executesql @sqlcmd;
END
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLogin]
    @Email varchar(150),
    @Parola varchar(150)
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
    SELECT *
    FROM dbo.Utilizator
    WHERE email = @Email
        AND parola = @Parola';
    SET @params = N'
    @Email VARCHAR(150),
    @Parola VARCHAR(150)';
    EXECUTE sp_executesql @sqlcmd, @params, @Email, @Parola;
END
GO
/****** Object:  StoredProcedure [dbo].[spRegister]    Script Date: 6/2/2020 11:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRegister]
    @Prenume varchar(150),
    @Nume varchar(150),
	@Email varchar(150),
	@Parola varchar(150),
	@Telefon varchar(150),
	@Adresa varchar(150)
AS
BEGIN
    DECLARE @sqlcmd NVARCHAR(MAX);
    DECLARE @params NVARCHAR(MAX);
    SET @sqlcmd = N'
    INSERT INTO dbo.Utilizator (prenume, nume, email, parola, telefon, adresa, angajat)
	VALUES (@Prenume, @Nume, @Email, @Parola, @Telefon, @Adresa, 0)';
    SET @params = N'
    @Prenume VARCHAR(150),
    @Nume VARCHAR(150),
	@Email VARCHAR(150),
	@Parola VARCHAR(150),
	@Telefon VARCHAR(150),
	@Adresa VARCHAR(150)';
    EXECUTE sp_executesql @sqlcmd, @params,@Prenume,@Nume,@Email,@Parola,@Telefon,@Adresa;
END
GO
USE [master]
GO
ALTER DATABASE [RestaurantOnline] SET  READ_WRITE 
GO
